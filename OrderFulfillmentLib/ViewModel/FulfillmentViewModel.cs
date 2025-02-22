using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.ViewModel
{
    public class FulfillmentAddViewModel
    {
        public int order_id { get; set; }
        public int paymentid { get; set; }
        public string? remarks { get; set; }
        public int fulfillment_status { get; set; }
    }

    public class FulfillmentPatchViewModel
    {
        public int? paymentid { get; set; }
        public string? remarks { get; set; }
        public int? fulfillment_status { get; set; }
    }
}
