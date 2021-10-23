namespace Dstricts.Models
{
	public class ResturantTableAvailableRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "resturant_id")]
		public int ResturantId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serve_type")]
		public int ServeType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "company_size")]
		public int CompanySize { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "booking_date")]
		public string BookingDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "date_today")]
		public bool DateToday { get; set; }
	}
}