namespace Dstricts.Models
{
	public class CartItemCountRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public string CheckId { get; set; }
	}
}
