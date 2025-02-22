using Common.QueryParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.QueryParameters
{
   public class Pur_Ord_DtlQueryParameters : QueryCommonParam
    {
        public int? pur_ord_id { get; set; }
    
        public int? prod_id { get; set; }
        public string? prod { get; set; }

        public int? minqty { get; set; }
        public int? maxqty { get; set; }

        public int? mincost { get; set; }
        public int? maxcost { get; set; }
    }
}
