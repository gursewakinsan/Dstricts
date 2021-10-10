namespace Dstricts.Models
{
	public class SearchUserResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "first_name")]
		public string FirstName { get; set; } //Bind with view.

		[Newtonsoft.Json.JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "passport_image")]
		public object PassportImage { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_image")]
		public string UserImage { get; set; }
	}
}
