using Common.QueryParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.QueryParameters
{
  public  class ProductQueryParameters : QueryCommonParam
    {
        public string? descr { get; set; }
        public int? prod_type_id { get; set; }
        public int? manf_id { get; set; }
        public int? uomid { get; set; }

    }
}
