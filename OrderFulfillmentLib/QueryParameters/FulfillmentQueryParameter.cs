
using Common.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.QueryParameters
{
    public class FulfillmentQueryParameter: QueryCommonParam
    {
        public int? order_id { get; set; }
        public int? paymentid { get; set; }
        public int? fulfillment_status { get; set; }
    }
}
