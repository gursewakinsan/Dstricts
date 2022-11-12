namespace Dstricts.Models
{
    public class TravelAppCompanyRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "tab_type")]
        public int TabType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "emergency_id")]
        public int EmergencyId { get; set; }
    }
}