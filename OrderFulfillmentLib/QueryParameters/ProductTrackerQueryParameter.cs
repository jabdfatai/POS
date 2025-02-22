using Common.QueryParameters;

namespace OrderFulfillmentLib.QueryParameters
{
    public class ProductTrackerQueryParameter:QueryCommonParam
    {
        public int? order_id { get; set; }
        public string? order_loc { get; set; }
        public int? order_status { get; set; }
    }

}
