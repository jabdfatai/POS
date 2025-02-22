using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryLib.ViewModel
{
    public class VendorViewModel
    {
        public int id { get; set; }
        [Required]
        public string descr { get; set; }
        [Required]
        public string org_name { get; set; }
        public string rcno { get; set; }
        public string contact_fst_name { get; set; }
        [Required]
        public string contact_lst_name { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string email { get; set; }
    }
    public class VendorAddViewModel
    {
        [Required]
        public string descr { get; set; }
        [Required]
        public string org_name { get; set; }
        public string rcno { get; set; }
        public string contact_fst_name { get; set; }
        [Required]
        public string contact_lst_name { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string email { get; set; }
    }
    public class VendorPatchViewModel
    {
        public string? descr { get; set; }
        public string? org_name { get; set; }
        public string? rcno { get; set; }
        public string? contact_fst_name { get; set; } 
        public string? contact_lst_name { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
    }
    public class VendorProductAddViewModel
    {
        public int vendorid { get; set; }
        public int productid { get; set; }
    }
    
}
