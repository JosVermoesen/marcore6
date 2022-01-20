using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace marcore.Entities
{
    public class VsoftContract
    {
        [Required]
        [StringLength(12)]
        public string Id { get; set; }      // A000 Contract Number        
        [StringLength(4)]
        public string A010 { get; set; } // InsuranceCompany code (Belgium: CDV number)        
        [StringLength(30)]
        public string Vs99 { get; set; } // Description short (30 characters)        
        public string Vs98 { get; set; } // Description long
        [StringLength(2)]
        public string V164 { get; set; }
        [StringLength(2)]
        public string V165 { get; set; }
        [StringLength(8)]
        public string Aw2 { get; set; }
        [StringLength(1)]
        public string A325 { get; set; }
        [StringLength(1)]
        public string A600 { get; set; }
        [StringLength(1)]
        public string Vs97 { get; set; }
        [StringLength(10)]
        public string B010 { get; set; }
        [StringLength(10)]
        public string B014 { get; set; }
        [StringLength(1)]
        public string V166 { get; set; }
        [StringLength(3)]
        public string V223 { get; set; }
        [StringLength(2)]
        public string Vs96 { get; set; }
        [StringLength(30)]
        public string V167 { get; set; }
        [Column(TypeName = "money")]
        public decimal? DecB010 { get; set; }
        [Column(TypeName = "money")]
        public decimal? DecB014 { get; set; }
        // TODO!!!!!!!!!!!
        public string Dece069 { get; set; }
        [StringLength(50)]
        public string E069 { get; set; }
        [StringLength(50)]
        public string E070 { get; set; }
        [StringLength(50)]
        public string E071 { get; set; }
        [StringLength(50)]
        public string E072 { get; set; }
        
        public virtual VsoftCustomer VsoftCustomer { get; set; }  // important for ON DELETE CASCADE when Customer is deleted        
        public string VsoftCustomerId { get; set; } // A110 in mdv database
        
        public virtual ICollection<VsoftTelebibContract> VsoftTelebibContracts { get; set; }        
        public VsoftContract()
        {
            VsoftTelebibContracts = new Collection<VsoftTelebibContract>();
        }
    }
}
