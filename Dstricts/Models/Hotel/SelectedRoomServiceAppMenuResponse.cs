using System.Collections.Generic;

namespace Dstricts.Models
{
	public class SelectedRoomServiceAppMenuResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "serve_type")]
		public int ServeType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serve_info")]
		public string ServeInfo { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serve_image")]
		public string ServeImage { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "category")]
		public List<CategoryInfo> Category { get; set; }
	}
}

public class CategoryInfo
{
	[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
	public int Id { get; set; }

	[Newtonsoft.Json.JsonProperty(PropertyName = "serve_type")]
	public int ServeType { get; set; }

	[Newtonsoft.Json.JsonProperty(PropertyName = "dish_name")]
	public string DishName { get; set; }

	[Newtonsoft.Json.JsonProperty(PropertyName = "dish_detail")]
	public string DishDetail { get; set; }

	[Newtonsoft.Json.JsonProperty(PropertyName = "dish_image")]
	public string DishImage { get; set; }

	[Newtonsoft.Json.JsonProperty(PropertyName = "dish_price")]
	public int DishPrice { get; set; }

	[Newtonsoft.Json.JsonProperty(PropertyName = "enc")]
	public string Enc { get; set; }
}
