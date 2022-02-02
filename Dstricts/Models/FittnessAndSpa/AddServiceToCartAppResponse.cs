namespace Dstricts.Models
{
	public class AddServiceToCartAppResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "qloud_checkout_id")]
		public int QloudCheckoutId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_id")]
		public int DishId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_name")]
		public string DishName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_price")]
		public int DishPrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_image")]
		public string DishImage { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_quantity")]
		public int DishQuantity { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_detail")]
		public string DishDetail { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "total_price")]
		public int TotalPrice { get; set; }


		/*[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public string created_on { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int is_verified { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int service_type { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int wellness_id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int is_paid { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public object user_id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public object company_id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public object card_id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public object charge_id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public object customer_id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int is_user { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int location_id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int one_shared { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int is_private { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public object booking_person_id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public object booked_employee_id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public object booking_time { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public object booking_date { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int is_confirmed_employee { get; set; }*/
	}
}
