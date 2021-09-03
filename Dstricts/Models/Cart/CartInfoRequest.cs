namespace Dstricts.Models
{
	public class CartInfoRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public string CheckId { get; set; }
	}
}
