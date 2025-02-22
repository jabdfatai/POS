
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Common.Model;

namespace OrderFulfillmentLib.Model
{
    public class OrderDelivery:CommonFields
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int order_id { get; set; }
        public string? contact_name { get; set; }
        public string? contact_email { get; set; }
        public string? contact_phone { get; set; }
        public string? add_line1 { get; set; }
        public string? add_line2 { get; set; }
        public string? city { get; set; }
        public string? country { get; set; }
        public string? state { get; set; }
        public string? zipcode { get; set; }
        public int del_status { get; set; }
     
    }


}
