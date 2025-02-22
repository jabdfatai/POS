using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.ViewModel
{
    public class BarCodeScanViewModel
    { 
            public int id { get; set; }
            public string UPC { get; set; }
            public string SKU { get; set; }
            public int lotid { get; set; }
            public int inv_stock_id { get; set; }

    }
}
