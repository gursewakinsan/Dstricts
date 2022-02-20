using System.Collections.Generic;

namespace Dstricts.Models
{
	public class SelectedWellnessCategoriesAndMenuResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "service_category_name")]
		public string ServiceCategoryName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
		public string ImagePath { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "menu")]
		public List<Menu> MenuInfo { get; set; }
	}

	public class Menu
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_name")]
		public string DishName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_detail")]
		public string DishDetail { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_price")]
		public int DishPrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_bookable")]
		public bool IsBookAble { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_active")]
		public bool IsActive { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_physical")]
		public bool IsPhysical { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "one_shared")]
		public bool OneShared { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "one_shared_type")]
		public bool OneSharedType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "recurring_event")]
		public bool RecurringEvent { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "open_event_date")]
		public string OpenEventDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "open_total_person")]
		public int OpenTotalPerson { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dish_image")]
		public string DishImage { get; set; }
	}
}
