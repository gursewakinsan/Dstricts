namespace Dstricts.Models
{
	public class SelectedLaundaryCategoriesResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "category_id")]
		public int CategoryId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serve_info")]
		public string ServeInfo { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serve_image")]
		public string ServeImage { get; set; }

		public double ImgWidth { get; set; }
		public double ImgHeight { get; set; }
	}
}
