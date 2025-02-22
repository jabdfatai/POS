using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryLib.ViewModel
{
   public class AlertAddViewModel
    {
        public string msg_event { get; set; }
        [Required]
        public string msg_body { get; set; }
        [Required]
        public string rec_email { get; set; }
        public string rec_sms { get; set; }
        public string del_status { get; set; }
    }
    public class AlertPatchViewModel
    {
        public string del_status { get; set; }


    }
}
