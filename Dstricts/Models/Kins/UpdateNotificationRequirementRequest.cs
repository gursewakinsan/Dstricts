namespace Dstricts.Models
{
    public class UpdateNotificationRequirementRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "updateInfo")]
        public int UpdateInfo { get; set; }
    }
}
