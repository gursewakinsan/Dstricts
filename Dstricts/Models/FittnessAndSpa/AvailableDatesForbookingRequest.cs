namespace Dstricts.Models
{
	public class AvailableDatesForbookingRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int WellnessId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dstricts_user_id")]
		public int DstrictsUserId { get; set; }
	}
}
