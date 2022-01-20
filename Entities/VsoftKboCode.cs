using System.ComponentModel.DataAnnotations;

namespace marcore.Entities
{
    public class VsoftKboCode
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Category { get; set; }
        [Required]
        [StringLength(15)]
        public string Code { get; set; }
        [Required]
        [StringLength(2)]
        public string Language { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }        
    }
}