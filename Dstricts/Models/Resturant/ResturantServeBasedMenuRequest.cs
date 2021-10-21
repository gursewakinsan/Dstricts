namespace Dstricts.Models
{
	public class ResturantServeBasedMenuRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "resturant_id")]
		public int ResturantId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serve_type")]
		public int ServeType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "width")]
		public double ImgWidth { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "height")]
		public double ImgHeight { get; set; }
	}
}
