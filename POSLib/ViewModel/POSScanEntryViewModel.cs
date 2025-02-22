using POSLib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.ViewModel
{
    public class PosScanEntryViewModel
    {
        public int id { get; set; }
        public string UPC { get; set; }
        public Guid userid { get; set; }
        public string scantime { get; set; }
        public DateTime scandate { get; set; }
        public char dir { get; set; }
        public int source { get; set; }


    }
    public class PosScanEntryAddViewModel
    {
        public int id { get; set; }
        public string UPC { get; set; }
        public Guid userid { get; set; }
        public string scantime { get; set; }
        public DateTime scandate { get; set; }
        public char dir { get; set; }
        public int source { get; set; }


    }

    public class PosScanOperationViewModel
    {
        public int id { get; set; }
        public string UPC { get; set; }
        public string item_name { get; set; }
        public Guid userid { get; set; }
        public int source { get; set; }
        public decimal discount { get; set; }
        public decimal unit_price { get; set; }
        public int quantity { get; set; }
        public decimal line_total { get; set; }
        public string tranxid { get; set; }
        public int? customerid { get; set; }
        public string scantime { get; set; }
        public DateTime scandate { get; set; }
    }
  


}
