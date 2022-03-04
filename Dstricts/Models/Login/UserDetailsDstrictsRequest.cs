namespace Dstricts.Models
{
	public class UserDetailsDstrictsRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }
	}
}
