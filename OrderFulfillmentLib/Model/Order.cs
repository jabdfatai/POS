
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;

namespace OrderFulfillmentLib.Model
{
    public class Order:CommonFields
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int qty { get; set; }
        public decimal total_amt { get; set; }
        public Guid? cust_id { get; set; }
        public string? remarks { get; set; }
        public int del_meth_id { get; set; }
        public string order_ref_no { get; set; }

    }


}
