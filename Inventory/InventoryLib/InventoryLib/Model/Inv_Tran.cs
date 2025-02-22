using Common.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryLib.Model
{
    public class Inv_Tran:CommonFields
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int inv_stock_id { get; set; }

        public int lot_id { get; set; }
        public int dir { get; set; }
        public int qty { get; set; }
        public string note { get; set; }


    }
 
}
