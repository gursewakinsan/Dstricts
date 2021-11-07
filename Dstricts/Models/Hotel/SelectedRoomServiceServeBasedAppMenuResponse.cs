using System.Collections.Generic;

namespace Dstricts.Models
{
	public class SelectedRoomServiceServeBasedAppMenuResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "category_food")]
		public int CategoryFood { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "food_category")]
		public string FoodCategory { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "place_of_display")]
		public int PlaceOfDisplay { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "category")]
		public List<Category> Category { get; set; }
	}

	public class Category
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serve_type")]
		public int ServeType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "food_category")]
		public string FoodCategory { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_name")]
		public string DishName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_detail")]
		public string DishDetail { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dimage")]
		public string DImage { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_price")]
		public int DishPrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_image")]
		public string DishImage { get; set; }

		public double ImgWidth { get; set; }
		public double ImgHeight { get; set; }
	}
}
