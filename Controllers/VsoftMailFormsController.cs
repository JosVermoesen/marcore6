using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using marcore.Entities;
using marcore.api.Data;
using marcore.api.Dtos.VsoftMailform;
using marcore.api.Helpers;

namespace marcore.api.Controllers
{
    public class VsoftMailformsController : BaseApiController
    {
        private readonly IVsoftMarRepository _repo;
        private readonly IMapper _mapper;
        public VsoftMailformsController(IVsoftMarRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetVsoftMailforms([FromQuery]MailformParams mailformParams)
        {
            var vsoftmailforms = await _repo.GetVsoftMailforms(mailformParams);

            var vsoftmailformsToReturn = _mapper.Map<IEnumerable<VsoftMailformForListDto>>(vsoftmailforms);

            Response.AddPagination(vsoftmailforms.CurrentPage, vsoftmailforms.PageSize, vsoftmailforms.TotalCount, vsoftmailforms.TotalPages);

            return Ok(vsoftmailformsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVsoftmailform(string id)
        {
            var vsoftmailform = await _repo.GetVsoftMailform(id);

            var vsoftmailformToReturn = _mapper.Map<VsoftMailformForDetailedDto>(vsoftmailform);

            return Ok(vsoftmailformToReturn);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> MailformCreate([FromBody]MailformForNewDto mailformForNewDto)
        {

            if (await _repo.MailformExistsAsync(mailformForNewDto.Id))
                ModelState.AddModelError("Id", "Mailform already exists");

            // validate request
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mailformToCreate = _mapper.Map<VsoftMailform>(mailformForNewDto);
            var createdMailform = await _repo.MailformNew(mailformToCreate);

            // TODO: fixing this!!            
            // var customerToReturn = _mapper.Map<CustomerForNewDto>(createdCustomer);
            // return CreatedAtRoute("GetVsoftCustomer", new { controller = "VsoftCustomers", id = createdCustomer.Id }, customerToReturn);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(createdMailform);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMailform([FromBody] MailformForUpdateDto mailformForUpdateDto)
        {
            var mailformFromRepo = await _repo.GetVsoftMailform(mailformForUpdateDto.Id);

            _mapper.Map(mailformForUpdateDto, mailformFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating customer {mailformForUpdateDto.Id} failed on save");
        }
    }
}
