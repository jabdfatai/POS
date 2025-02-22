using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.ViewModel
{
    public class InvoiceAddViewModel
    {
        public int order_id { get; set; }
        public byte[] image { get; set; }
        public int print_status { get; set; }
        public DateTime? print_date { get; set; }
    }

    public class InvoicePatchViewModel
    {
        public byte[]? image { get; set; }
        public int? print_status { get; set; }
        public DateTime? print_date { get; set; }
    }
}
