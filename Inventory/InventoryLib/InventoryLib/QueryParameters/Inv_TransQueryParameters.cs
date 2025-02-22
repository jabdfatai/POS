using Common.QueryParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.QueryParameters
{
  public  class Inv_TransQueryParameters : QueryCommonParam
    {
        public int? inv_stock_id { get; set; }
        public int? lot_id { get; set; }
        public int? dir { get; set; }
        public int? prod_id { get; set; }
        public string? prod_name { get; set; }
        public DateTime? dtcreatedfrom { get; set; }
        public DateTime? dtcreatedto { get; set; }


    }
}
