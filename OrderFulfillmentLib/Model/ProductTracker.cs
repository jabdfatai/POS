
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Common.Model;

namespace OrderFulfillmentLib.Model
{
    public class ProductTracker:CommonFields
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int order_id { get; set; }
        public string order_loc { get; set; }
        public int order_status { get; set; }
        public string? comment { get; set; }
    }


}
