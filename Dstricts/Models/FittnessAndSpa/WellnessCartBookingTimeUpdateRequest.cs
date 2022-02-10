namespace Dstricts.Models
{
	public class WellnessCartBookingTimeUpdateRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int WellnessId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dstricts_user_id")]
		public int DstrictsUserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "booking_time")]
		public string BookingTime { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "booking_date")]
		public int BookingDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "booking_employee_id")]
		public int? BookingEmployeeId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "employee_id")]
		public int EmployeeId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "total_booking_time")]
		public int TotalBookingTime { get; set; }
	}
}
