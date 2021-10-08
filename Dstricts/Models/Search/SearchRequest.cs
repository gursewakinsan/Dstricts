namespace Dstricts.Models
{
	public class SearchRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "name")]
		public string Name { get; set; }
	}
}
