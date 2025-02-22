using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryLib.ViewModel
{
  public  class LotAddViewModel
    {
   
        public string descr { get; set; }
        [Required]
        public int prod_id { get; set; }
        [Required]
        public int vend_id { get; set; }
        [Required]
        public DateTime manf_date { get; set; }
        [Required]
        public DateTime exp_time { get; set; }
        [Required]
        public int qty { get; set; }
        [Required]
        public string batch_no { get; set; }
        [Required]
        public int pur_ord_id { get; set; }
        [Required]
        public string lotno { get; set; }
    }
    public class LotPatchViewModel
    {
        public string? descr { get; set; }
        public int? prod_id { get; set; }  
        public int? vend_id { get; set; }    
        public DateTime? manf_date { get; set; }  
        public DateTime? exp_time { get; set; }     
        public int? qty { get; set; }
        public string? batch_no { get; set; }
        public int? pur_ord_id { get; set; }
        public string? lotno { get; set; }
    }
}
