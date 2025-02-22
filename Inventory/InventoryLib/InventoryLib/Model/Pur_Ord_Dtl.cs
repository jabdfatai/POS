using Common.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryLib.Model
{
    public class Pur_Ord_Dtl : CommonFields
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
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
 
}
