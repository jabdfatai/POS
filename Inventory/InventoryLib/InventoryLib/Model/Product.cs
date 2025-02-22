using Common.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryLib.Model
{
    public class Product : CommonFields
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string descr { get; set; }
        [Required]
        public int prod_type_id { get; set; }
        [Required]
        public int manf_id { get; set; }
        [Required]
        public int uomid { get; set; }
     

    }
 
}
