namespace Dstricts.Models
{
	public class FittnessAndSpaSelectedCategoryResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_name")]
		public string DishName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_detail")]
		public string DishDetail { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_image")]
		public string DishImage { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_price")]
		public int DishPrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "one_shared")]
		public int OneShared { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "one_shared_type")]
		public int OneSharedType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "recurring_event")]
		public bool RecurringEvent { get; set; }


		/*[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int is_bookable { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int is_active { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int is_physical { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int recurring_event { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public object open_event_date { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int open_total_person { get; set; }*/
	}
}
