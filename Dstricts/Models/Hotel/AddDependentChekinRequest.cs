namespace Dstricts.Models
{
	public class AddDependentChekinRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "child_id")]
		public int ChildId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }
	}
}
