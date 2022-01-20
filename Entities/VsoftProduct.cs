using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace marcore.Entities
{
    public class VsoftProduct
    {
        [Required]
        [StringLength(13)]
        public string Id { get; set; }      // EAN code (V102!!)        
        [StringLength(40)]
        public string V105 { get; set; }    // Description Dutch
        [StringLength(40)]
        public string V221 { get; set; }    // Description French
        [StringLength(1)]
        public string V106 { get; set; }    // Product maatstaf
        [StringLength(10)]
        public string V107 { get; set; }    // number of product maatstaf
        [StringLength(1)]
        public string V108 { get; set; }    // Type of Product/Artical/Service
        [StringLength(3)]
        public string V110 { get; set; }    // Profit margin
        [StringLength(1)]
        public string V111 { get; set; }    // VAT code
        [StringLength(1)]
        public string V168 { get; set; }    // Type of Tax
        [StringLength(3)]
        public string V169 { get; set; }    // Tax Value
        [StringLength(15)]
        public string V112 { get; set; }    // seller price ex VAT
        [StringLength(15)]
        public string V113 { get; set; }    // buyer price ex VAT
        [StringLength(10)]
        public string V115 { get; set; }    // minimum stock
        [StringLength(7)]
        public string V116 { get; set; }    // journal account buyer (60)
        [StringLength(7)]
        public string V117 { get; set; }    // journal account seller (70)
        [StringLength(7)]
        public string V118 { get; set; }    // journal account stock (xx)
        [StringLength(10)]
        public string V114 { get; set; }    // units at start bookyear
        [StringLength(10)]
        public string V119 { get; set; }    // units bought in bookyear
        [StringLength(10)]
        public string V120 { get; set; }    // units sold in bookyear
        [StringLength(15)]
        public string V121 { get; set; }    // total amount bought in bookyear
        [StringLength(15)]
        public string V122 { get; set; }    // gemiddeld of bought sold in bookyear
        [StringLength(15)]
        public string V123 { get; set; }    // total amount of stock at start bookyear
        [StringLength(10)]
        public string V109 { get; set; }    // location in stockplace
        [StringLength(8)]
        public string V103 { get; set; }    // Goederencode (Intrastat)
        [StringLength(20)]
        public string V104 { get; set; }    // Code of our supplier
        [StringLength(12)]
        public string V124 { get; set; }    // Supplier of last delivery
        [StringLength(1)]
        public string V125 { get; set; }    // Sort flag
        [StringLength(30)]
        public string V001 { get; set; }    // Picture filename
        [StringLength(255)]
        public string V002 { get; set; }    // video filename
        [StringLength(50)]
        public string V249 { get; set; }    // Muntcode of amounts
        [StringLength(50)]
        public string E112 { get; set; }    
        [StringLength(50)]
        public string E113 { get; set; }    
        [StringLength(50)]
        public string E121 { get; set; }    
        [StringLength(50)]
        public string E122 { get; set; }
        [StringLength(50)]
        public string E123 { get; set; }
        [Column(TypeName = "money")]
        public decimal? Dece112 { get; set; }   // seller price ex VAT
        [Column(TypeName = "money")]
        public decimal? Dece113 { get; set; }   // buyer price ex VAT        
        [Column(TypeName = "money")]
        public decimal? Dece121 { get; set; }   // total amount bought in bookyear
        [Column(TypeName = "money")]
        public decimal? Dece122 { get; set; }   // gemiddeld of bought sold in bookyear
        [Column(TypeName = "money")]
        public decimal? Dece123 { get; set; }   // total amount of stock at start bookyear
        [StringLength(50)]
        public string V261 { get; set; }
        public int? RvID { get; set; }
    }
}
