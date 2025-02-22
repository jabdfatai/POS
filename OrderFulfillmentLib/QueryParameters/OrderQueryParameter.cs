using Common.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.QueryParameters
{
    public class OrderQueryParameter:QueryCommonParam
    {
        public int? maxqty { get; set; }
        public int? minqty { get; set; }
        public decimal? max_total_amt { get; set; }
        public decimal? min_total_amt { get; set; }
        public Guid? cust_id { get; set; }
        public int? del_meth_id { get; set; }
    }
    public class OrderDetailQueryParameter:QueryCommonParam
    {
        public int? inv_stock_id { get; set; }
        public int? orderid { get; set;}
        public decimal? max_unit_price { get; set; }
        public decimal? min_unit_price { get; set; }
        public decimal? max_line_total { get; set; }
        public decimal? min_line_total { get; set; }

    }

}
