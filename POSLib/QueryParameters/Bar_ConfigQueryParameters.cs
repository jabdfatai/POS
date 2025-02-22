

using Common.QueryParameters;

namespace POSLib.QueryParameters
{
    public class Bar_ConfigQueryParameters:QueryCommonParam
    {
        public string? UPC { get; set; }
        public string? SKU { get; set; }
        public int? lotid { get; set; }
        public DateTime? created_from { get; set; }
        public DateTime? created_to { get; set; }
    }
}
