using Common.QueryParameters;

namespace POSLib.QueryParameters
{
    public class UserActivityQueryParameters:QueryCommonParam
    {
        public Guid? userid { get; set; }
        public string? action { get; set; }
        public string? rec_affected { get; set; }
        public string? entity_affected { get; set; }
        public string? ipaddress { get; set; }
        public DateTime? created_from { get; set; }
        public DateTime? created_to { get; set; }
    }
}
