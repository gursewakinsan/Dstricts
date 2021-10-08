namespace Dstricts.Models
{
	public class SearchCompanyResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "passport_image")]
		public object PassportImage { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_image")]
		public string UserImage { get; set; }
	}
}
