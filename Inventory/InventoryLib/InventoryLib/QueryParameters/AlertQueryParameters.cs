using Common.QueryParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.QueryParameters
{
   public class AlertQueryParameters: QueryCommonParam
    {
        public string rec_email { get; set; }
        public string rec_sms { get; set; }
        public string del_status { get; set; }       
        public string status { get; set; }
 

    }
}
