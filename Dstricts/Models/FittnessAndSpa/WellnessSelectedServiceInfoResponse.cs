namespace Dstricts.Models
{
	public class WellnessSelectedServiceInfoResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_name")]
		public string DishName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_detail")]
		public string DishDetail { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_price")]
		public int DishPrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_bookable")]
		public bool IsBookable { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_active")]
		public bool IsActive { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_physical")]
		public bool IsPhysical { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_image")]
		public string DishImage { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "one_shared")]
		public int OneShared { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "one_shared_type")]
		public int OneSharedType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "recurring_event")]
		public bool RecurringEvent { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "open_event_date")]
		public string OpenEventDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "open_total_person")]
		public int OpenTotalPerson { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "open_event_time")]
		public int? OpenEventTime { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "work_time")]
		public string WorkTime { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "open_price_per_person")]
		public int OpenPricePerPerson { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "private_price")]
		public int PrivatePrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "booking_date")]
		public System.DateTime BookingDate { get; set; }

		public string DisplayBookingDate => BookingDate.ToString("dddd, dd MMM");
	}
}
