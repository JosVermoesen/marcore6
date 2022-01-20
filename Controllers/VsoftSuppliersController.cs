using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using marcore.Entities;
using marcore.api.Data;
using marcore.api.Dtos.VsoftSupplier;
using marcore.api.Helpers;

namespace marcore.api.Controllers
{    
    public class VsoftSuppliersController : BaseApiController
    {
        private readonly IVsoftMarRepository _repo;
        private readonly IMapper _mapper;
        public VsoftSuppliersController(IVsoftMarRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [Authorize(Policy = "RequireMarRole")]
        [HttpGet]
        public async Task<IActionResult> GetVsoftSuppliers([FromQuery]SupplierParams supplierParams)
        {
            var vsoftsuppliers = await _repo.GetVsoftSuppliers(supplierParams);

            var vsoftsuppliersToReturn = _mapper.Map<IEnumerable<VsoftSupplierForListDto>>(vsoftsuppliers);

            Response.AddPagination(vsoftsuppliers.CurrentPage, vsoftsuppliers.PageSize, vsoftsuppliers.TotalCount, vsoftsuppliers.TotalPages);

            return Ok(vsoftsuppliersToReturn);
        }

        [Authorize(Policy = "RequireMarRole")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVsoftSupplier(string id)
        {
            var vsoftsupplier = await _repo.GetVsoftSupplier(id);

            var vsoftsupplierToReturn = _mapper.Map<VsoftSupplierForDetailedDto>(vsoftsupplier);

            return Ok(vsoftsupplierToReturn);
        }

        [Authorize(Policy = "RequireMarEditRole")]
        [HttpPost("{id}")]
        public async Task<IActionResult> SupplierCreate([FromBody]SupplierForNewDto supplierForNewDto)
        {

            if (await _repo.SupplierExistsAsync(supplierForNewDto.Id))
                ModelState.AddModelError("Id", "Supplier already exists");

            // validate request
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var supplierToCreate = _mapper.Map<VsoftSupplier>(supplierForNewDto);
            var createdSupplier = await _repo.SupplierNew(supplierToCreate);

            // TODO: fixing this!!            
            // var customerToReturn = _mapper.Map<CustomerForNewDto>(createdCustomer);
            // return CreatedAtRoute("GetVsoftCustomer", new { controller = "VsoftCustomers", id = createdCustomer.Id }, customerToReturn);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(createdSupplier);
        }

        [Authorize(Policy = "RequireMarEditRole")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier([FromBody] SupplierForUpdateDto supplierForUpdateDto)
        {
            var supplierFromRepo = await _repo.GetVsoftSupplier(supplierForUpdateDto.Id);

            _mapper.Map(supplierForUpdateDto, supplierFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating supplier {supplierForUpdateDto.Id} failed on save");
        }
    }
}
