using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using marcore.Entities;
using marcore.api.Data;
using marcore.api.Dtos.VsoftCustomer;
using marcore.api.Helpers;

namespace marcore.api.Controllers
{
    public class VsoftCustomersController : BaseApiController
    {
        private readonly IVsoftMarRepository _repo;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public VsoftCustomersController(DataContext context, IVsoftMarRepository repo, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _repo = repo;
        }

        [Authorize(Policy = "RequireMarRole")]
        [HttpGet]
        public async Task<IActionResult> GetVsoftCustomers([FromQuery] CustomerParams customerParams)
        {
            var vsoftcustomers = await _repo.GetVsoftCustomers(customerParams);

            var vsoftcustomersToReturn = _mapper.Map<IEnumerable<VsoftCustomerForListDto>>(vsoftcustomers);

            Response.AddPagination(vsoftcustomers.CurrentPage, vsoftcustomers.PageSize, vsoftcustomers.TotalCount, vsoftcustomers.TotalPages);

            return Ok(vsoftcustomersToReturn);
        }

        // disabled for member view own customer invoices and contracts!
        // [Authorize(Policy = "RequireMarRole")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVsoftCustomer(string id)
        {
            var vsoftcustomer = await _repo.GetVsoftCustomer(id);

            var vsoftcustomerToReturn = _mapper.Map<VsoftCustomerForDetailedDto>(vsoftcustomer);

            return Ok(vsoftcustomerToReturn);
        }

        [Authorize(Policy = "ModeratePhotoRole")]
        [HttpGet("withmail")]
        public async Task<IActionResult> WithMail()
        {
            var vsoftcustomers = await _repo.GetVsoftCustomersWithMail();

            var vsoftcustomersToReturn = _mapper.Map<IEnumerable<VsoftCustomerForListDto>>(vsoftcustomers);
            // Response.AddPagination(vsoftcustomers.CurrentPage, vsoftcustomers.PageSize, vsoftcustomers.TotalCount, vsoftcustomers.TotalPages);

            return Ok(vsoftcustomersToReturn);
        }

        /* public async Task<IActionResult> WithMail()
        {
            var customerswithmail = await _context.VsoftCustomers
               .Where(x => x.V224 != null)
               .ToListAsync();

            return Ok(customerswithmail);
        } */

        [Authorize(Policy = "RequireMarEditRole")]
        [HttpPost("{id}")]
        public async Task<IActionResult> CustomerCreate([FromBody] CustomerForNewDto customerForNewDto)
        {

            if (await _repo.CustomerExistsAsync(customerForNewDto.Id))
                ModelState.AddModelError("Id", "Customer already exists");

            // validate request
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerToCreate = _mapper.Map<VsoftCustomer>(customerForNewDto);
            var createdCustomer = await _repo.CustomerNew(customerToCreate);

            // TODO: fixing this!!            
            // var customerToReturn = _mapper.Map<CustomerForNewDto>(createdCustomer);
            // return CreatedAtRoute("GetVsoftCustomer", new { controller = "VsoftCustomers", id = createdCustomer.Id }, customerToReturn);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(createdCustomer);
        }

        [Authorize(Policy = "RequireMarEditRole")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerForUpdateDto customerForUpdateDto)
        {
            var customerFromRepo = await _repo.GetVsoftCustomer(customerForUpdateDto.Id);

            _mapper.Map(customerForUpdateDto, customerFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating customer {customerForUpdateDto.Id} failed on save");
            // return BadRequest($"Updating customer {customerForUpdateDto.Id} failed on save")
        }
    }
}
