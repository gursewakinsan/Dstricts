namespace Dstricts.Models
{
	public class DeleteWellnessAllCartItemsRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int WellnessId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dstricts_user_id")]
		public int DstrictsUserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }
	}
}
