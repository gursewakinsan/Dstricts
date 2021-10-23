namespace Dstricts.Models
{
	public class ResturantWorkInfoResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serve")]
		public string Serve { get; set; }
	}
}
