using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using marcore.api.Data;
using marcore.api.Dtos.VsoftTelebibContract;

namespace marcore.api.Controllers
{
    public class VsoftTelebibContractsController : BaseApiController
    {
        private readonly IVsoftMarRepository _repo;
        private readonly IMapper _mapper;
        public VsoftTelebibContractsController(IVsoftMarRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetVsoftTelebibContracts()
        {
            var vsofttelebibcontracts = await _repo.GetVsoftTelebibContracts();

            var vsofttelebibcontractsToReturn = _mapper.Map<IEnumerable<VsoftTelebibContractForListDto>>(vsofttelebibcontracts);

            return Ok(vsofttelebibcontractsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVsoftTelebibContract(int id)
        {
            var vsofttelebibcontract = await _repo.GetVsoftTelebibContract(id);

            var vsofttelebibcontractToReturn = _mapper.Map<VsoftTelebibContractForDetailedDto>(vsofttelebibcontract);

            return Ok(vsofttelebibcontractToReturn);
        }
    }
}
