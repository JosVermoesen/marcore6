using System;
using System.ComponentModel.DataAnnotations;

namespace marcore.Entities
{
    public class VsoftKboEnterprise
    {
        [StringLength(20)]
        public string Id { get; set; } // EnterpriseNumber
        // [StringLength(20)]
        // public string EnterpriseNumber { get; set; }
        [Required]
        [StringLength(2)]
        public string Status { get; set; }
        [Required]
        [StringLength(3)]
        public string JuridicalSituation { get; set; }
        [Required]
        [StringLength(1)]
        public string TypeOfEnterprise { get; set; }
        [StringLength(3)]
        public string JuridicalForm { get; set; }
        [Required]        
        public DateTime StartDate { get; set; }        
    }
}