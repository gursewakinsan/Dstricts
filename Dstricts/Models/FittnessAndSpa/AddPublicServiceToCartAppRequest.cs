namespace Dstricts.Models
{
	public class AddPublicServiceToCartAppRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "dstricts_user_id")]
		public int DstrictsUserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int Checkid { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int WellnessId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_detail")]
		public string DishDetail { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_name")]
		public string DishName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_image")]
		public string DishImage { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "price")]
		public int Price { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "quantity")]
		public int Quantity { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "item_id")]
		public int ItemId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "service_type")]
		public int ServiceType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "one_shared")]
		public int OneShared { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "one_shared_type")]
		public int OneSharedType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "open_event_date")]
		public string OpenEventDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "open_event_time")]
		public int? OpenEventTime { get; set; }
	}
}
