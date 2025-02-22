
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Common.Model;

namespace OrderFulfillmentLib.Model
{
    public class Payment:CommonFields
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int order_id { get; set;}
        public string payment_ref { get; set; }
        public decimal amount { get; set; }
        public DateTime payment_date { get; set; }
        public int? provider_id { get; set; }
        public int payment_type { get; set; }
        public int payment_status { get; set; }

    }


}
