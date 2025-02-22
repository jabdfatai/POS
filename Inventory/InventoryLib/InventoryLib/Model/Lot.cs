using Common.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryLib.Model
{
    public class Lot : CommonFields
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string descr { get; set; }
        [Required]
        public int prod_id { get; set; }
        [Required]
        public int vend_id { get; set; }
        [Required]
        public DateTime manf_date { get; set; }
        [Required]
        public DateTime exp_date { get; set; }
        [Required]
        public int qty { get; set; }
        [Required]
        public string batch_no { get; set; }
        [Required]
        public int pur_ord_id { get; set; }
        [Required]
        public string lotno { get; set; }

    }
 
}
