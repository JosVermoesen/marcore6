using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using marcore.api.Data;
using marcore.api.Dtos.VsoftCustomerInvoice;

namespace marcore.api.Controllers
{
    public class VsoftCustomerInvoicesController : BaseApiController
    {
        private readonly IVsoftMarRepository _repo;
        private readonly IMapper _mapper;
        public VsoftCustomerInvoicesController(IVsoftMarRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [Authorize(Policy = "RequireMarRole")]
        [HttpGet]
        public async Task<IActionResult> GetVsoftCustomerInvoices()
        {
            var vsoftcustomerinvoices = await _repo.GetVsoftCustomerInvoices();

            var vsoftcustomerinvoicesToReturn = _mapper.Map<IEnumerable<VsoftCustomerInvoiceForListDto>>(vsoftcustomerinvoices);

            return Ok(vsoftcustomerinvoicesToReturn);
        }

        [Authorize(Policy = "RequireMarRole")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVsoftCustomerInvoice(string id)
        {
            var vsoftcustomerinvoice = await _repo.GetVsoftCustomerInvoice(id);

            var vsoftcustomerinvoiceToReturn = _mapper.Map<VsoftCustomerInvoiceForDetailedDto>(vsoftcustomerinvoice);

            return Ok(vsoftcustomerinvoiceToReturn);
        }
    }
}
