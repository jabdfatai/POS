using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryLib.ViewModel
{
   public class Prod_CatAddViewModel
    {
     
        [Required]
        public string descr { get; set; }
        public string prod_form { get; set; }
    }
    public class Prod_CatPatchViewModel
    {
        public string descr { get; set; }
        public string prod_form { get; set; }
    }
}
