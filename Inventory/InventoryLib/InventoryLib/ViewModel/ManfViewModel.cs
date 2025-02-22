using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryLib.ViewModel
{
   public class ManfAddViewModel
    {
        [Required]
        public string descr { get; set; }
    }
 
}
