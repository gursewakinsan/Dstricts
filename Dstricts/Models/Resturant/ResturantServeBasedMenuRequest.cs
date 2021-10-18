namespace Dstricts.Models
{
	public class ResturantServeBasedMenuRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "resturant_id")]
		public int ResturantId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serve_type")]
		public int ServeType { get; set; }
	}
}
