using Common.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryLib.Model
{
    public class Vend_Con : CommonFields
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public int vend_id { get; set; }
        [Required]
        public string org_name { get; set; }
        public string rcno { get; set; }
        public string contact_fst_name { get; set; }
        [Required]
        public string contact_lst_name { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string email { get; set; }

    }
 
}
