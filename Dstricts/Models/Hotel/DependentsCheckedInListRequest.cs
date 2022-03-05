namespace Dstricts.Models
{
	public class DependentsCheckedInListRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }
	}
}
