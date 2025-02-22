
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Common.Model;

namespace OrderFulfillmentLib.Model
{
    public class Invoice:CommonFields
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int order_id { get; set; }
        public byte[] image { get; set; }
        public int print_status { get; set; }
        public DateTime? print_date { get; set; }
    }
    

}
