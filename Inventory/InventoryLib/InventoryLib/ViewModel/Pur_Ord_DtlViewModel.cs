using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryLib.ViewModel
{
   public class Pur_Ord_DtlAddViewModel
    {
        public int pur_ord_id { get; set; }
        [Required]
        public int prod_id { get; set; }
        [Required]
        public int qty { get; set; }
        [Required]
        public decimal unit_cost { get; set; }
        [Required]
        public decimal line_total { get; set; }
        public string note { get; set; }
    }
    public class Pur_Ord_DtlPatchViewModel
    {
        public int pur_ord_id { get; set; }
    
        public int prod_id { get; set; }
       
        public int qty { get; set; }

  
    }
}
