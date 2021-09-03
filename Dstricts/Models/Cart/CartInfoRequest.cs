namespace Dstricts.Models
{
	public class CartInfoRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }
	}
}
