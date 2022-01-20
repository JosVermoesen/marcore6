using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace marcore.api.Dtos.VsoftSupplier
{
    public class VsoftSupplierForListDto
    {
        public string Id { get; set; }
        public string A100 { get; set; }
        public string A104 { get; set; }
        public string A105 { get; set; }
        public string A106 { get; set; }
        public string A107 { get; set; }
        public string A108 { get; set; }
    }
}
