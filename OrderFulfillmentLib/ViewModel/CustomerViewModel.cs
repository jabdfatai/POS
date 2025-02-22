using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.ViewModel
{
    public class CustomerAddViewModel
    {
        public Guid customerid { get; set; }
        public string? first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string add_line_1 { get; set; }
        public string add_line_2 { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public DateTime? dob { get; set; }
    }

    public class CustomerPatchViewModel
    {
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? add_line_1 { get; set; }
        public string? add_line_2 { get; set; }
        public string? city { get; set; }
        public string? country { get; set; }
        public string state { get; set; }
        public string? zipcode { get; set; }
        public DateTime? dob { get; set; }
    }
}
