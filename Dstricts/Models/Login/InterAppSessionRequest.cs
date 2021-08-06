namespace Dstricts.Models
{
	public class InterAppSessionRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "certi")]
		public string Session { get; set; }
	}
}
