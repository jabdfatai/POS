using Common.QueryParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.QueryParameters
{
  public class Vend_ConQueryParameters : QueryCommonParam
    {
        public int vend_id { get; set; }
        public string vend { get; set; }
        public string org_name { get; set; }
        public string rcno { get; set; }
        public string contact_name { get; set; }
       

    }
}
