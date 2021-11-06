namespace Dstricts.Models
{
	public class AddFoodToCartRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "qloud_checkout_id")]
		public int QloudCheckoutId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_id")]
		public int DishId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_quantity")]
		public int DishQuantity { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_name")]
		public string DishName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_image")]
		public string DishImage { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_detail")]
		public string DishDetail { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_price")]
		public int DishPrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "total_price")]
		public int TotalPrice { get; set; }
	}
}
