using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.ViewModel
{
    public class UserActivityViewModel
    {
        public int Id { get; set; }
        public Guid userid { get; set; }
        public string action { get; set; }
        public string rec_affected { get; set; }
        public string entity_affected { get; set; }
        public string ipaddress { get; set; }
        public DateTime DT_CRTD { get; set; }
        public DateTime? DT_MODF { get; set; }
    }

    public class UserActivityAddViewModel
    {
        public Guid userid { get; set; }
        public string action { get; set; }
        public string rec_affected { get; set; }
        public string entity_affected { get; set; }
        public string ipaddress { get; set; }

    }
}
