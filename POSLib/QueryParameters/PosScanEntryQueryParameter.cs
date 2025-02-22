
using Common.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.QueryParameters
{
    public class PosScanEntryQueryParameter:QueryCommonParam
    {
        public string? UPC { get; set; }
        public Guid? userid { get; set; }
        public DateTime? fromscandate { get; set; }
        public DateTime? toscandate { get; set; }
        public char? dir { get; set; }
        public int? source { get; set; }
    }
}
