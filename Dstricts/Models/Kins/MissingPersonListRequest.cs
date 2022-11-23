namespace Dstricts.Models
{
    public class MissingPersonListRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }
    }
}
