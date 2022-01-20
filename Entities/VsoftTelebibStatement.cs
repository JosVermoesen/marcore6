using System.ComponentModel.DataAnnotations;

namespace marcore.Entities
{
    public class VsoftTelebibStatement
    {
        public int Id { get; set; }
        [StringLength(4)]
        public string Mij { get; set; }        
        public string MemoTb2 { get; set; }
        [StringLength(2)]
        public string DocType { get; set; }        
        [StringLength(1)]
        public string DocStatus { get; set; }        
        public int? RvID { get; set; }
    }
}
