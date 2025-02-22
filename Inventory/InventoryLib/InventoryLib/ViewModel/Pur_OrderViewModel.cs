using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryLib.ViewModel
{
   public class Pur_OrderAddViewModel
    {
        [Required]
        public int vend_id { get; set; }
        public DateTime purchase_date { get; set; }
        public string pur_ord_no { get; set; }
        public int total_item_no { get; set; }
        public decimal total_item_cost { get; set; }
    }
}
