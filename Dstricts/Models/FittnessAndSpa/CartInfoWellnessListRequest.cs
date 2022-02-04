namespace Dstricts.Models
{
	public class CartInfoWellnessListRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int Checkid { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "service_type")]
		public int ServiceType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int WellnessId { get; set; }
	}
}
