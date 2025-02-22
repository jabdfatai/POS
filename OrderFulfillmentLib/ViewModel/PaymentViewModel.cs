using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.ViewModel
{
    public class PaymentAddViewModel
    {
        public int order_id { get; set; }
        public string payment_ref { get; set; }
        public decimal amount { get; set; }
        public DateTime payment_date { get; set; }
        public int? provider_id { get; set; }
        public int payment_type { get; set; }
        public int payment_status { get; set; }
    }
    public class PaymentPatchViewModel
    { 
        public DateTime? payment_date { get; set; }
        public int? payment_status { get; set; }
    }
}
