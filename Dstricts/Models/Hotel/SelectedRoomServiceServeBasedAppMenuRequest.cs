namespace Dstricts.Models
{
	public class SelectedRoomServiceServeBasedAppMenuRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serve_type")]
		public int ServeType { get; set; }
	}
}
