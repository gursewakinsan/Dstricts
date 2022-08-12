namespace Dstricts.Models
{
    public class TenantInvoiceInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "building_id")]
        public int BuildingId { get; set; }
    }
}
