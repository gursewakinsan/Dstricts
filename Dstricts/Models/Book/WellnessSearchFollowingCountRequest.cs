namespace Dstricts.Models
{
	public class WellnessSearchFollowingCountRequest : BaseModel
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int WellnessId { get; set; }
	}
}
