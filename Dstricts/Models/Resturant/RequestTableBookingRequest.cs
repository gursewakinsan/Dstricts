namespace Dstricts.Models
{
	public class RequestTableBookingRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "resturant_id")]
		public int ResturantId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serve_type")]
		public int ServeType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "company_size")]
		public int CompanySize { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "booking_date")]
		public string BookingDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "time_detail")]
		public int TimeDetail { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }
	}
}