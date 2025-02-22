

using Common.QueryParameters;

namespace OrderFulfillmentLib.QueryParameters
{
    public class  OrderDeliveryQueryParameter:QueryCommonParam
    {
        public int order_id { get; set; }
        public string? contact_name { get; set; }
        public string? contact_email { get; set; }
        public string? contact_phone { get; set; }
        public string? address { get; set; }
        public string? city { get; set; }
        public string? country { get; set; }
        public string? state { get; set; }
        public string? zipcode { get; set; }
        public int del_status { get; set; }
    }

}
