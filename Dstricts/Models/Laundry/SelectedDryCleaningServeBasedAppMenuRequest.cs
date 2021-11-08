namespace Dstricts.Models
{
	public class SelectedDryCleaningServeBasedAppMenuRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "category_id")]
		public int CategoryId { get; set; }
	}
}
