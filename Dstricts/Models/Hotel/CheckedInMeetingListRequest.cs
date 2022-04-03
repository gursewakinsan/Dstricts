namespace Dstricts.Models
{
	public class CheckedInMeetingListRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }
	}
}
