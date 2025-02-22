
using Common.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.QueryParameters
{
    public class InvoiceQueryParameter:QueryCommonParam
    {
            public int? order_id { get; set; }
            public int? print_status { get; set; }
            public DateTime? print_date { get; set; }
        
    }
}
