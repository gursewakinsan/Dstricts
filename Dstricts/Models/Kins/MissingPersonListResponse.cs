namespace Dstricts.Models
{
    public class MissingPersonListResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
        public string ImagePath { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "person_heart_user_id")]
        public int PersonHeartUserId { get; set; }
    }
}
