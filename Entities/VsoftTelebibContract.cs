using System.ComponentModel.DataAnnotations;

namespace marcore.Entities
{
    public class VsoftTelebibContract
    {
        public int Id { get; set; }
        [StringLength(4)]
        public string Mij { get; set; }        
        public string MemoTb2 { get; set; }
        [StringLength(2)]
        public string DocType { get; set; }                
        public virtual VsoftContract VsoftContract { get; set; } // important for ON DELETE CASCADE when Customer is deleted
        public string VsoftContractId { get; set; } // Polis (A000) in mdv database
    }
}
