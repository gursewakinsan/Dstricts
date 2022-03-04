namespace Dstricts.Models
{
	public class UserDetailsDstrictsResponse
	{
		//public string first_name { get; set; }
		//public string last_name { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "email")]
		public string Email { get; set; }
		//public int user_id { get; set; }
		//public string UserImage { get; set; }
		//public int result { get; set; }
	}
}
