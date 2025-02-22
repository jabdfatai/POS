using Common.QueryParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.QueryParameters
{
    public class Pur_OrdQueryParameters : QueryCommonParam
    {
        public string? vend { get; set; }
        public int? vend_id { get; set; }
        public DateTime? min_purchase_date { get; set; }
        public DateTime? max_purchase_date { get; set; }
        public string? pur_ord_no { get; set; }
        public int? minqty { get; set; }
        public int? maxqty { get; set; }
        public int? mincost { get; set; }
        public int? maxcost { get; set; }
    }
}
