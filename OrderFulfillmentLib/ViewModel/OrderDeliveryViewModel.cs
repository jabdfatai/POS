namespace OrderFulfillmentLib.ViewModel
{

    public class OrderDeliveryAddViewModel
    {
        public int order_id { get; set; }
        public string? contact_name { get; set; }
        public string? contact_email { get; set; }
        public string? contact_phone { get; set; }
        public string? add_line1 { get; set; }
        public string? add_line2 { get; set; }
        public string? city { get; set; }
        public string? country { get; set; }
        public string? state { get; set; }
        public string? zipcode { get; set; }
        public int del_status { get; set; }
    }
    public class OrderDeliveryPatchViewModel
    {
        public string? contact_name { get; set; }
        public string? contact_email { get; set; }
        public string? contact_phone { get; set; }
        public string? add_line1 { get; set; }
        public string? add_line2 { get; set; }
        public string? city { get; set; }
        public string? country { get; set; }
        public string? state { get; set; }
        public string? zipcode { get; set; }
        public int del_status { get; set; }
    }
}
