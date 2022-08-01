namespace Dstricts.Models
{
    public class ApartmentCommunityAmenitiesRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "community_id")]
        public int CommunityId { get; set; }
    }
}
