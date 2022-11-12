namespace Dstricts.Models
{
    public class TravelAppCompanyLocationsRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "emergency_id")]
        public int EmergencyId { get; set; }
    }
}
