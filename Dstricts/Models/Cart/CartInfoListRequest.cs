namespace Dstricts.Models
{
	public class CartInfoListRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "service_type")]
		public int ServiceType { get; set; }
	}
}
