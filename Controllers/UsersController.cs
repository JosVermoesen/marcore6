using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using MailKit.Net.Smtp;
using MimeKit;

using marcore.api.Data;
using marcore.api.Dtos.User;
using marcore.api.Helpers;
using marcore.Entities;
using marcore.Extensions;

namespace marcore.api.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]    
    public class UsersController : BaseApiController
    {
        private const string mailSubject = @"Wijziging gebruikersprofiel";        
        private const string bodyText = @"Hallo, Wij hebben de wijzigingen en/of voorkeuren binnen uw profiel goed ontvangen.
                                Voor bijkomende vragen aarzel niet met ons contact op te nemen";
        private const string bodyHtml = @"<p>Hallo,<p>
                <p>Wij hebben de wijzigingen en/of voorkeuren binnen uw profiel goed ontvangen.</p>
                <p>Voor bijkomende vragen aarzel niet met ons contact op te nemen.</p>";

        private readonly ICompanyRepository _repo;
        private readonly IOptions<MailSettings> _mailConfig;
        private readonly IMapper _mapper;
        public UsersController(ICompanyRepository repo, IOptions<MailSettings> mailConfig, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
            _mailConfig = mailConfig;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery]UserParams userParams)
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var userFromRepo = await _repo.GetUserByIdAsync(currentUserId);

            userParams.UserId = currentUserId;

            if (string.IsNullOrEmpty(userParams.Gender))
            {
                userParams.Gender = userFromRepo.Gender == "male" ? "female" : "male";
            }

            var users = await _repo.GetUsers(userParams);

            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

            Response.AddPagination(users.CurrentPage, users.PageSize,
                users.TotalCount, users.TotalPages);

            return Ok(usersToReturn);
        }

        [HttpGet("{username}", Name = "GetUser")]
        public async Task<ActionResult> GetUser(string username)
        {
            var user = await _repo.GetUserByUsernameAsync(username);

            var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            // return await _userRepository.GetMemberAsync(username);
            return Ok(userToReturn);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(UserForUpdateDto userForUpdateDto)
        {
            var user = await _repo.GetUserByUsernameAsync(User.GetUsername());

            /* if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await _repo.GetUser(id, true); */
            
            _mapper.Map(userForUpdateDto, user);

            _repo.Update(user);
                        
            if (await _repo.SaveAllAsync())
                // SendMailConfirmation(userFromRepo);
                return NoContent();

            // throw new Exception($"UpCompany user {id} failed on save");
            return BadRequest("Failed to update user");
        }

        [HttpPost("{id}/like/{recipientId}")]
        public async Task<IActionResult> LikeUser(int id, int recipientId)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var like = await _repo.GetLike(id, recipientId);

            if (like != null)
                return BadRequest("You already like this user");

            if (await _repo.GetUserByIdAsync(recipientId) == null)
                return NotFound();

            like = new Like
            {
                LikerId = id,
                LikeeId = recipientId
            };

            _repo.Add<Like>(like);

            if (await _repo.SaveAllAsync())
                return Ok();

            return BadRequest("Failed to like user");
        }

        private void SendMailConfirmation(User thisUser)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(
                _mailConfig.Value.SendMailAddress,
                _mailConfig.Value.SendMailAddress));

            message.To.Add(new MailboxAddress(
                thisUser.UserName,
                thisUser.Email));

            message.To.Add(new MailboxAddress(
                _mailConfig.Value.AdminCCFullName,
                _mailConfig.Value.AdminCCMailAddress));

            message.Subject = mailSubject;

            var builder = new BodyBuilder();

            // Set the plain-text version of the message text
            builder.TextBody = bodyText
                + " Groeten, Admin";

            // Set the html version of the message text
            builder.HtmlBody = string.Format(bodyHtml
                + "<p>Groeten, Admin</p>");

            // HOWTO attach ??
            // builder.Attachments.Add(@"http://www.rv.be/docserver/!pdfDocumenten/mar/ODBC-MARDSN10-Instellen.pdf");

            // Now we just need to set the message body and we're done
            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect(
                    _mailConfig.Value.SendMailUrl, 587, false);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(
                    _mailConfig.Value.SendMailAddress,
                    _mailConfig.Value.SendMailPassword);

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}