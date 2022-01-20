using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using marcore.api.Data;
using marcore.api.Dtos.VsoftSupplierInvoice;

namespace marcore.api.Controllers
{
    public class VsoftSupplierInvoicesController : BaseApiController
    {
        private readonly IVsoftMarRepository _repo;
        private readonly IMapper _mapper;
        public VsoftSupplierInvoicesController(IVsoftMarRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [Authorize(Policy = "RequireMarRole")]
        [HttpGet]
        public async Task<IActionResult> GetVsoftSupplierInvoices()
        {
            var vsoftsupplierinvoices = await _repo.GetVsoftSupplierInvoices();

            var vsoftsupplierinvoicesToReturn = _mapper.Map<IEnumerable<VsoftSupplierInvoiceForListDto>>(vsoftsupplierinvoices);

            return Ok(vsoftsupplierinvoicesToReturn);
        }

        [Authorize(Policy = "RequireMarRole")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVsoftSupplierInvoice(string id)
        {
            var vsoftsupplierinvoice = await _repo.GetVsoftSupplierInvoice(id);

            var vsoftsupplierinvoiceToReturn = _mapper.Map<VsoftSupplierInvoiceForDetailedDto>(vsoftsupplierinvoice);

            return Ok(vsoftsupplierinvoiceToReturn);
        }
    }
}
