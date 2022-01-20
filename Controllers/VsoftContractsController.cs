using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using marcore.api.Data;
using marcore.api.Dtos.VsoftContract;

namespace marcore.api.Controllers
{
    public class VsoftContractsController : BaseApiController
    {
        private readonly IVsoftMarRepository _repo;
        private readonly IMapper _mapper;
        public VsoftContractsController(IVsoftMarRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [Authorize(Policy = "RequireMarRole")]
        [HttpGet]
        public async Task<IActionResult> GetVsoftContracts()
        {
            var vsoftcontracts = await _repo.GetVsoftContracts();

            var vsoftcontractsToReturn = _mapper.Map<IEnumerable<VsoftContractForListDto>>(vsoftcontracts);

            return Ok(vsoftcontractsToReturn);
        }

        [Authorize(Policy = "RequireMarRole")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVsoftContract(string id)
        {
            var vsoftcontract = await _repo.GetVsoftContract(id);

            var vsoftcontractToReturn = _mapper.Map<VsoftContractForDetailedDto>(vsoftcontract);

            return Ok(vsoftcontractToReturn);
        }
    }
}
