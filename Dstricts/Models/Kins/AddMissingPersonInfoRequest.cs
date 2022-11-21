namespace Dstricts.Models
{
    public class AddMissingPersonInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "clothes_wearing")]
        public string ClothesWearing { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "last_seen_duration")]
        public int LastSeenDuration { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "last_seen_time")]
        public int LastSeenTime { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "uid")]
        public int Uid { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
    }
}