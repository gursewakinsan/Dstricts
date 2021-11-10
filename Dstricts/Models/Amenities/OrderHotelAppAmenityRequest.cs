namespace Dstricts.Models
{
	public class OrderHotelAppAmenityRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "a_id")]
		public string AId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "aname")]
		public string AName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "quantity")]
		public int Quantity { get; set; }
	}
}
