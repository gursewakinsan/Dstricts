namespace Dstricts.Models
{
    public class GetCommunityDetailInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public int CommunityId { get; set; }
    }
}
