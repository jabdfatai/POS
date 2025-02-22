using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.ViewModel
{
    public class ProductTrackerAddViewModel
    {
        public int order_id { get; set; }
        public string order_loc { get; set; }
        public int order_status { get; set; }
        public string? comment { get; set; }
    }
    public class ProductTrackerPatchViewModel
    {
        public string? order_loc { get; set; }
        public int? order_status { get; set; }
        public string? comment { get; set; }
    }
}
