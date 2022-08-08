namespace Dstricts.Models
{
    public class ApartmentDetailInfoCheckinRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "dstricts_user_id")]
        public int DstrictsUserId { get; set; }
    }
}
