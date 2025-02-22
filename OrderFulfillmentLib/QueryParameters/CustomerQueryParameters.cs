
using Common.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.QueryParameters
{
    public class CustomerQueryParameters: QueryCommonParam
    {
        public string? name { get; set; }
        public string? phone { get; set; }
        public string? state { get; set; }
        public string? country { get; set; }

    }
}
