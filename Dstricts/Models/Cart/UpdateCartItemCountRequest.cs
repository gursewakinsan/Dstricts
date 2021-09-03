namespace Dstricts.Models
{
	public class UpdateCartItemCountRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_id")]
		public int DishId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_quantity")]
		public int DishQuantity { get; set; }
	}
}
