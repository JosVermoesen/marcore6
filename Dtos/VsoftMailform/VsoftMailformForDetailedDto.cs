using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using marcore.api.Dtos.VsoftContract;
using marcore.api.Dtos.VsoftCustomerInvoice;


namespace marcore.api.Dtos.VsoftMailform
{
    public class VsoftMailformForDetailedDto
    {
        public string Id { get; set; }  // Short Description
        public string Subject { get; set; }
        public string Body { get; set; }        
        public string PartyCode { get; set; } // D= Debitor  C= Creditor G = Government          
    }
}
