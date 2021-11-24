namespace Dstricts.Models
{
	public class VerifyCheckedInCodeRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "dstricts_user_id")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "ecode")]
		public string Ecode { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "hotel_property_type")]
		public int HotelPropertyType { get; set; }
	}
}
