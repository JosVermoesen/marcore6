using System.Threading.Tasks;
using System.Linq;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using AutoMapper;

using MailKit.Net.Smtp;
using MimeKit;

using marcore.api.Dtos.User;
using marcore.api.Helpers;
using marcore.api.Dtos.Contactmail;
using marcore.Entities;
using marcore.Interfaces;
using marcore.Dtos.User;

namespace marcore.api.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseApiController
    {
        private const string mailSubject = @"Nieuwe gebruikersregistratie";
        private const string bodyText = @"Hallo, U registreerde zich zo-even voor de portfolio app (en webtoepassing rv-services.be).
                                Na controle van deze registratie, ontvangt U als klant mailbevestiging en toegang tot alle functies.
                                Controle op: Identiteitskaart rijksregister nummer: ";
        private const string bodyHtml = @"<p>Hallo,<br>
                <p>U registreerde zich zo-even voor de portfolio app (en webtoepassing rv-services.be).
                Na controle van deze registratie, ontvangt U als klant mailbevestiging en toegang tot alle functies.<br>
                <p>Controle op:<br> * Identiteitskaart rijksregister nummer: ";
        private readonly IConfiguration _config;
        private readonly IOptions<MailSettings> _mailConfig;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IConfiguration config,
            IOptions<MailSettings> mailConfig,
            ITokenService tokenService,
            IMapper mapper,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _tokenService = tokenService;
            _config = config;
            _mailConfig = mailConfig;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(UserForRegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("400: User already exists!");

            var user = _mapper.Map<User>(registerDto);
            user.UserName = registerDto.Username.ToLower();
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Member");
            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            SendMailConfirmation(user);
            return new UserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = await _tokenService.CreateToken(user),
                KnownAs = user.KnownAs,
                BerNumber = user.BerNumber,
                ClientNumber = user.ClientNumber
            };

            /* var userToReturn = _mapper.Map<UserForDetailedDto>(user);
            SendMailConfirmation(user);

            return CreatedAtRoute("GetUser",
                new { controller = "Users", id = user.Id }, userToReturn); */
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _userManager.Users
                .Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.UserName == userForLoginDto.Username.ToLower());

            if (user == null) return Unauthorized("Invalid user");

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, userForLoginDto.Password, false);

            if (!result.Succeeded) return Unauthorized();

            return new UserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = await _tokenService.CreateToken(user),
                PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain)?.Url,
                KnownAs = user.KnownAs,
                BerNumber = user.BerNumber,
                ClientNumber = user.ClientNumber
            };

            /* if (result.Succeeded)
            {
                var appUser = await _userManager.Users.Include(p => p.Photos)
                    .FirstOrDefaultAsync(u => u.NormalizedUserName == userForLoginDto.Username.ToUpper());

                var userToReturn = _mapper.Map<UserForListDto>(appUser);

                return Ok(new
                {
                    token = GenerateJwtToken(appUser).Result,
                    user = userToReturn
                });
            } */

            // return Unauthorized("Invalid password");
        }

        [HttpPost("contactmail")]
        public IActionResult contactmail(ContactmailForDto contactmailForDto)
        {
            try
            {
                var mailToCreate = _mapper.Map<Contactmail>(contactmailForDto);
                // if (contactmailForDto.ApiGuid == "5205fa57-766f-4af0-9207-d993d81d759b")
                if (contactmailForDto.ApiGuid == _mailConfig.Value.MailGuid)
                {
                    SendContactMail(contactmailForDto);
                    return Ok(mailToCreate);
                }
                return BadRequest();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        /* private async Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddYears(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        } */

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
        }

        private void SendContactMail(ContactmailForDto contactmail)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(
                _mailConfig.Value.SendMailUrl,
                _mailConfig.Value.SendMailAddress));

            message.To.Add(new MailboxAddress(
                contactmail.ApiNameKey,
                contactmail.ApiMailKey));

            if (contactmail.CopySender)
            {
                message.To.Add(new MailboxAddress(
                    contactmail.Name,
                    contactmail.Email));
            }

            /* message.To.Add(new MailboxAddress(
                _mailKitConfig.Value.AdminCCFullName,
                _mailKitConfig.Value.AdminCCMailAddress)); */

            message.Subject = contactmail.Subject;
            var builder = new BodyBuilder();

            if (contactmail.Template == null)
            {
                // Set the html version of the message text
                builder.HtmlBody = string.Format("Ontvangen bericht vanwege:<br>"
                   + "<br> * Rijksregister: "
                   + contactmail.RR
                   + "<br> * Naam: "
                   + contactmail.Name
                   + "<br> * Email adres: "
                   + contactmail.Email
                   + "<br> * Telefoon: "
                   + contactmail.Phone
                   + "<br><p>Bericht:<br>"
                   + contactmail.Message);
            }
            else
            {
                if (contactmail.Data == null)
                {
                    builder.HtmlBody = contactmail.Template;
                }
                else
                {
                    builder.HtmlBody = string.Format("TODO: Mailinglist<br>");
                }
            }

            // Set the plain-text version of the message text
            // builder.TextBody = ""
            //    + " Rijksregister: "
            //    + contactmail.RR
            //    + " naam: "
            //    + contactmail.Name
            //    + " met opgegeven email adres: "
            //    + contactmail.Email
            //    + " Bericht: "
            //    + contactmail.Message;


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

        private void SendMailConfirmation(User newUser)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(
                _mailConfig.Value.SendMailAddress,
                _mailConfig.Value.SendMailAddress));

            message.To.Add(new MailboxAddress(
                newUser.UserName,
                newUser.Email));

            message.To.Add(new MailboxAddress(
                _mailConfig.Value.AdminCCFullName,
                _mailConfig.Value.AdminCCMailAddress));

            message.Subject = mailSubject;

            var builder = new BodyBuilder();

            // Set the plain-text version of the message text
            builder.TextBody = bodyText
                + newUser.BerNumber
                + " voor gebruikersnaam: "
                + newUser.UserName
                + " met opgegeven email adres: "
                + newUser.Email
                + " Groeten, Admin";

            // Set the html version of the message text
            builder.HtmlBody = string.Format(bodyHtml
                + newUser.BerNumber
                + "<br> * voor gebruikersnaam: "
                + newUser.UserName
                + "<br> * met opgegeven email adres: "
                + newUser.Email
                + "<br><p>Groeten, Admin<br>");

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