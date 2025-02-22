using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryLib.ViewModel
{
   public class Code_TabAddViewModel
    {
        public string tab_id { get; set; }
        [Required]
        public string tab_name { get; set; }
        public int col_id { get; set; }
        public string col_name { get; set; }
    }
    public class Code_TabPatchViewModel
    {
        public string tab_id { get; set; }
    
        public string tab_name { get; set; }
        public int col_id { get; set; }
        public string col_name { get; set; }
        public int status { get; set; }
   
    }
}
