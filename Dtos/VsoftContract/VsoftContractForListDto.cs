using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace marcore.api.Dtos.VsoftContract
{
    public class VsoftContractForListDto
    {
        public string Id { get; set; } // A000
        [StringLength(4)]
        public string A010 { get; set; }        
        [StringLength(12)]
        public string A110 { get; set; }
        [Column("vs99")]
        [StringLength(30)]
        public string Vs99 { get; set; }
        [Column("vs98")]
        public string Vs98 { get; set; }
    }
}
