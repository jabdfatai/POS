using Common.QueryParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.QueryParameters
{
   public class ProductTypeQueryParameters: QueryCommonParam
    {
        public string? descr { get; set; }
        public int? prod_cat_id { get; set; }
    }
}
