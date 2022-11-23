namespace Dstricts.Models
{
    public class MissingPersonEmergencyListRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }
    }
}
