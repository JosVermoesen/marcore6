using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace marcore.api.Dtos.VsoftMailform
{
    public class VsoftMailformForListDto
    {
        public string Id { get; set; }  // Short Description
        public string Subject { get; set; }
        public string PartyCode { get; set; } // D= Debitor  C= Creditor G = Government          
    }
}
