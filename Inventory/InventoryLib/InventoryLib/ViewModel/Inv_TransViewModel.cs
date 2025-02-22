using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.ViewModel
{
   public class Inv_TransAddViewModel
    {
        public int inv_stock_id { get; set; }

        public int lot_id { get; set; }
        public int dir { get; set; }
        public int? qty { get; set; }
        public string note { get; set; }
    }
    public class Inv_TransPatchViewModel
    {    
        public int? lot_id { get; set; }
        public int? dir { get; set; }
        public int? qty { get; set; }
        public string? note { get; set; }
    }
    public class Inv_TransViewModel
    {
        public int id { get; set; }
        public int inv_stock_id { get; set; }
        public int lot_id { get; set; }
        public int dir { get; set; } 
        public int? qty { get; set; }
        public string note { get; set; }

        public DateTime? dt_crtd { get; set; }
        public string? productname { get; set; }
        public string? prodtype { get; set; }
        public int? uom { get; set; }

    }
}
