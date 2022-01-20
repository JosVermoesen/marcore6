using System.ComponentModel.DataAnnotations;

namespace marcore.Entities
{
    public class VsoftYearSetting
    {
        public int Id { get; set; }
        [Required]
        [StringLength(5)]
        public string V071 { get; set; }
        [Required]
        [StringLength(30)]
        public string V217 { get; set; }
        [Required]
        [StringLength(4)]
        public string Bkjr { get; set; }
    }
}
