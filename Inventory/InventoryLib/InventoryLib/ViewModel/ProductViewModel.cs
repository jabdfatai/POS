using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryLib.ViewModel
{
   public class ProductAddViewModel
    {
        [Required]
        public string descr { get; set; }
        [Required]
        public int prod_type_id { get; set; }
        [Required]
        public int manf_id { get; set; }
        [Required]
        public int uomid { get; set; }
    }

    public class ProductPatchViewModel
    {
     
        public string? descr { get; set; }
    
        public int? prod_type_id { get; set; }
     
        public int? manf_id { get; set; }
       
        public int? uomid { get; set; }
    }
}
