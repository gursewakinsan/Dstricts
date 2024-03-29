﻿namespace Dstricts.Models
{
	public class SelectedWellnessCategoriesandMenuRequest : BaseModel
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "selected_services_type")]
		public int SelectedServicesType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int WellnessId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dstricts_user_id")]
		public int DstrictsUserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }
	}
}
