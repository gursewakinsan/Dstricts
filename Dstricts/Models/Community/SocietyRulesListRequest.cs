namespace Dstricts.Models
{
    public class SocietyRulesListRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public int CommunityId { get; set; }
    }
}
