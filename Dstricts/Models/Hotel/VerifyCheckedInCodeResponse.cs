namespace Dstricts.Models
{
	public class VerifyCheckedInCodeResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "result")]
		public int Result { get; set; }
	}
}
