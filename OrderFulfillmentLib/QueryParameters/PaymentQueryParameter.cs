using Common.QueryParameters;

namespace OrderFulfillmentLib.QueryParameters
{
    public class PaymentQueryParameter:QueryCommonParam
    {
        public int? order_id { get; set; }
        public string? payment_ref { get; set; }
        public decimal? fromamount { get; set; }
        public decimal? toamount { get; set; }
        public DateTime? from_payment_date { get; set; }
        public DateTime? to_payment_date { get; set; }
        public int? provider_id { get; set; }
        public int? payment_type { get; set; }
    }

}
