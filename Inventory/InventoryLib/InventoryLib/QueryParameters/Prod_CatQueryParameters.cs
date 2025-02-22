using Common.QueryParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.QueryParameters
{
    public class Prod_CatQueryParameters : QueryCommonParam
    {
        public string descr { get; set; }
        public string prod_form { get; set; }
    }
}
