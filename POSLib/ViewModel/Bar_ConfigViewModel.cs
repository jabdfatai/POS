using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.ViewModel
{
    public class Bar_ConfigViewModel
    {
        public int id { get; set; }
        public string UPC { get; set; }
        public string SKU { get; set; }
        public int lotid { get; set; }
        public DateTime DT_CRTD { get; set; }
        public DateTime? DT_MODF { get; set; }

    }

    public class Bar_ConfigAddViewModel
    {
        public int id { get; set; }
        public string UPC { get; set; }
        public string SKU { get; set; }
        public int lotid { get; set; }

    }

    public class Bar_ConfigPatchViewModel
    {
        public string? UPC { get; set; }
        public string? SKU { get; set; }
        public int? lotid { get; set; }

    }

}
