using Common.QueryParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.QueryParameters
{
  public  class Code_TabQueryParameters:QueryCommonParam
    {
    
        public string tab_id { get; set; }

        public string tab_name { get; set; }
        public string col_id { get; set; }
        public string col_name { get; set; }
    }
}
