using System.ComponentModel.DataAnnotations;

namespace marcore.Entities
{
    public class VsoftMailform
    {        
        [Required]
        [StringLength(50)]
        public string Id { get; set; }  // Short Description
        public string Subject { get; set; }
        public string Body { get; set; }        
        [StringLength(1)]
        public string PartyCode { get; set; } // D= Debitor  C= Creditor G = Government          
    }
}
