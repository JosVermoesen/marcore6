using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using marcore.api.Dtos.VsoftDayBook;

namespace marcore.api.Dtos.VsoftAccount
{
    public class VsoftAccountForDetailedDto
    {
        [Required]
        [StringLength(7)]
        public string id { get; set; }
        [Required]
        [StringLength(40)]
        public string v020 { get; set; }
        [Column(TypeName = "money")]
        public decimal? dece022 { get; set; }
        [Column(TypeName = "money")]
        public decimal? dece023 { get; set; }
        [Column(TypeName = "money")]
        public decimal? dece024 { get; set; }
        [Column(TypeName = "money")]
        public decimal? dece025 { get; set; }
        [Column(TypeName = "money")]
        public decimal? dece026 { get; set; }
        [Column(TypeName = "money")]
        public decimal? dece027 { get; set; }
        [Column(TypeName = "money")]
        public decimal? dece028 { get; set; }
        [Column(TypeName = "money")]
        public decimal? dece029 { get; set; }
        [Column(TypeName = "money")]
        public decimal? dece030 { get; set; }
        [Column(TypeName = "money")]
        public decimal? dece031 { get; set; }
        [StringLength(50)]
        public string v021 { get; set; }
        [StringLength(1)]
        public string v032 { get; set; }
        [StringLength(2)]
        public string v216 { get; set; }
        public ICollection<VsoftDayBookForDetailedDto> VsoftDayBooks { get; set; }
    }
}