
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Common.Model;

namespace OrderFulfillmentLib.Model
{
    public class Fulfillment:CommonFields
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int order_id { get; set; }
        public int paymentid { get; set; }
        public string? remarks { get; set; }
        public int fulfillment_status { get; set; }
    }


}
