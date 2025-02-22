
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Common.Model;

namespace OrderFulfillmentLib.Model
{
    public class OrderDetail:CommonFields
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int order_id { get; set; }
        public int inv_stock_id { get; set; }
        public decimal unit_price { get; set; }
        public int qty { get; set; }
        public decimal line_total { get; set; }

    }


}
