using Common.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.QueryParameters
{
    public class UserQueryParameters: QueryCommonParam
    {
        public string? name { get; set; }
        public string? role { get; set; }
        public int? roleid { get; set; }
        public DateTime? created_from { get; set; }
        public DateTime? created_to { get; set;}
    }
}
