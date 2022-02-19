namespace Dstricts.Models
{
	public class WellnessUpdateFollowingRequest : BaseModel
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "is_following_update")]
		public bool IsFollowingUpdate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int WellnessId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dstricts_user_id")]
		public int DstrictsUserId { get; set; }
	}
}
