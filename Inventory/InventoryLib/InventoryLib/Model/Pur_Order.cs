using Common.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryLib.Model
{
    public class Pur_Order : CommonFields
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public int vend_id { get; set; }
        public DateTime purchase_date { get; set; }
        public string pur_ord_no { get; set; }
        public int total_item_no { get; set; }
        public decimal total_item_cost { get; set; }

    }
 
}
