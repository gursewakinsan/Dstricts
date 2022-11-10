namespace Dstricts.Models
{
    public class TravelAppAvailableSosResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "tab_type")]
        public int TabType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "front_display_name")]
        public string FrontDisplayName { get; set; }
    }
}
