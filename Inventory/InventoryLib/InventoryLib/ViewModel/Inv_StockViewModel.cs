using InventoryLib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InventoryLib.ViewModel
{
    public class Inv_StockAddViewModel
    {

        [Required]
        public int prod_id { get; set; }
        [Required]
        public int qty { get; set; }
        [Required]

        public int targ_inv_level { get; set; }
        [Required]
        public string SKU { get; set; }
    }



    public class Inv_StockPatchViewModel
    {

        //public int prod_id { get; set; }   
        public int? qty { get; set; }
        public int? targ_inv_level { get; set; }
        public string? SKU { get; set; }
    }


    public class Inv_StockViewModel
    {
        public int id { get; set; }
        public int prod_id { get; set; }
        public int qty { get; set; }
        public int targ_inv_level { get; set; }
        public string SKU { get; set; }
        public DateTime? dt_crtd { get; set; }
        public string? productname { get; set; }
        public string? prodtype { get; set; }
        public int? uom { get; set; }


    }

    public class Inv_StockDepleteViewModel
    {
        public int inv_Stockid { get; set; }
        public int? lotid { get; set; }
        public int qty { get; set; }
    }
}
