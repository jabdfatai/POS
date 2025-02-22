using Common.QueryParameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryLib.QueryParameters
{
   public class VendorQueryParameters : QueryCommonParam
    {  
        public string? descr { get; set; }
        public string? org_name { get; set; }
        public string? rcno { get; set; }
        public string? contactname { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
    }
}
