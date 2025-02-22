using Common.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryLib.Model
{
    public class Alert: CommonFields
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string msg_event { get; set; }
        [Required]
        public string msg_body { get; set; }
        [Required]
        public string rec_email { get; set; }
        public string rec_sms { get; set; }
        public string del_status { get; set; }
   

    }
 
}
