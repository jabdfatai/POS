using Common.QueryParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.QueryParameters
{
   public class Inv_StockQueryParameters:QueryCommonParam
    {
        public int? prod_id { get; set; }
        public string? prodname { get; set; }

        public int? minqty { get; set; }
        public int? maxqty { get; set; }
        public int? qty { get; set; }
        public int? min_targ_inv_level { get; set; }
        public int? max_targ_inv_level { get; set; }
        public int? targ_inv_level { get; set; }
        public bool? below_tar_inv_level { get; set; }
        public bool? above_tar_inv_level { get; set; }

        public string? SKU { get; set; }

     

    }
}
