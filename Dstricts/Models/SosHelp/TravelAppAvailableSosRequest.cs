namespace Dstricts.Models
{
    public class TravelAppAvailableSosRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "current_latitude")]
        public double CurrentLatitude { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "current_longitude")]
        public double CurrentLongitude { get; set; }
    }
}
