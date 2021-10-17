namespace Dstricts.Models
{
	public class ResturantServeInfoResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serve")]
		public string Serve { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serve_image")]
		public string ServeImage { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "num")]
		public int Num { get; set; }
	}
}
