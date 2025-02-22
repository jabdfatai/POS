using Common.QueryParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.QueryParameters
{
   public class LotQueryParameters:QueryCommonParam
    {
   
        public string? descr { get; set; }
        public int? prod_id { get; set; }
        public int? vend_id { get; set; }
        public DateTime? manf_date { get; set; }
        public DateTime? manf_date_from { get; set; }
        public DateTime? manf_date_to { get; set; }
        public DateTime? exp_date_from { get; set; }
        public DateTime? exp_date_to { get; set; }
        public DateTime? exp_date { get; set; }
        public int? maxqty { get; set; }
        public int? minqty { get; set; }
        public int? qty { get; set; }
        public string? batch_no { get; set; }    
        public int? pur_ord_id { get; set; }
        public string? lotno { get; set; }


    }
}
