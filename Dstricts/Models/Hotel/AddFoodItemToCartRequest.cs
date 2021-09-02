namespace Dstricts.Models
{
	public class AddFoodItemToCartRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_name")]
		public string DishName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_detail")]
		public string DishDetail { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_image")]
		public string DishImage { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "price")]
		public int DishPrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "quantity")]
		public int Quantity { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "item_id")]
		public int ItemId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "service_type")]
		public int ServiceType { get; set; }
	}
}
