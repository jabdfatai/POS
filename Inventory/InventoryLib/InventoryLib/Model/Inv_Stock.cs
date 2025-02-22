using Common.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryLib.Model
{
    public class Inv_Stock:CommonFields
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public int prod_id { get; set; }
        [Required]
        public int qty { get; set; }
        [Required]

        public int targ_inv_level { get; set; }
        [Required]
        public string SKU { get; set; }
  
    }
 
}
