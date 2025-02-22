using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryLib.ViewModel
{
  public  class Prod_TypeAddViewModel
    {
        [Required]
        public string descr { get; set; }
        [Required]
        public int prod_cat_id { get; set; }
    }
}
