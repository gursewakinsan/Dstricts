namespace Dstricts.Models
{
	public class CartItemCountRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }
	}
}
