namespace Dstricts.Models
{
	public class UpdateWellnessCartItemRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int WellnessId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_id")]
		public int DishId { get; set; }
	}
}
