using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using marcore.Entities;
using marcore.api.Data;
using marcore.api.Dtos.VsoftLedgerAccount;
using marcore.api.Helpers;

// !!! WARNING !!!
// VsoftLedgerAccount should be renamed to VsoftLedgerAccount

namespace marcore.api.Controllers
{
    public class VsoftLedgerAccountsController : BaseApiController
    {
        private readonly IVsoftMarRepository _repo;
        private readonly IMapper _mapper;
        public VsoftLedgerAccountsController(IVsoftMarRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [Authorize(Policy = "RequireMarRole")]
        [HttpGet]
        public async Task<IActionResult> GetVsoftLedgerAccounts([FromQuery] AccountParams accountParams)
        {
            var vsoftaccounts = await _repo.GetVsoftLedgerAccounts(accountParams);

            var vsoftaccountsToReturn = _mapper.Map<IEnumerable<VsoftLedgerAccountForListDto>>(vsoftaccounts);

            Response.AddPagination(vsoftaccounts.CurrentPage, vsoftaccounts.PageSize, vsoftaccounts.TotalCount, vsoftaccounts.TotalPages);

            return Ok(vsoftaccountsToReturn);
        }

        [Authorize(Policy = "RequireMarRole")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVsoftLedgerAccount(string id)
        {
            var vsoftaccount = await _repo.GetVsoftLedgerAccount(id);

            var vsoftaccountToReturn = _mapper.Map<VsoftLedgerAccountForDetailedDto>(vsoftaccount);

            return Ok(vsoftaccountToReturn);
        }

        [Authorize(Policy = "RequireMarEditRole")]
        [HttpPost("{id}")]
        public async Task<IActionResult> AccountCreate([FromBody] VsoftLedgerAccountForNewDto vsoftAccountForNewDto)
        {

            if (await _repo.AccountExistsAsync(vsoftAccountForNewDto.id))
                ModelState.AddModelError("Id", "Account already exists");

            // validate request
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var accountToCreate = _mapper.Map<VsoftLedgerAccount>(vsoftAccountForNewDto);
            var createdAccount = await _repo.AccountNew(accountToCreate);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(createdAccount);
        }

        [Authorize(Policy = "RequireMarEditRole")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount([FromBody] VsoftLedgerAccountForUpdateDto accountForUpdateDto)
        {
            var accountFromRepo = await _repo.GetVsoftLedgerAccount(accountForUpdateDto.id);

            _mapper.Map(accountForUpdateDto, accountFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating account {accountForUpdateDto.id} failed on save");
        }
    }
}
