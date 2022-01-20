using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace marcore.api.Dtos.VsoftAccount
{
    public class VsoftAccountForListDto
    {
        public string id { get; set; }
        public string v020 { get; set; }
        [Column(TypeName = "money")]
        public decimal? dece022 { get; set; }
        [Column(TypeName = "money")]
        public decimal? dece023 { get; set; }
    }
}
