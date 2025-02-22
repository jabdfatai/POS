using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.ViewModel
{
    public class UserViewModel
    {
        public int id { get; set; }
        public Guid userid { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int roleid { get; set; }
    }
    public class UserAddViewModel
    {
        public Guid userid { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int roleid { get; set; }
    }
    public class UserPatchViewModel
    {
        public Guid? userid { get; set; }
        public string? fullname { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public int? roleid { get; set; }
    }
}
