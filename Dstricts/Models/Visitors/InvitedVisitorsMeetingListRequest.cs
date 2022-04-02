namespace Dstricts.Models
{
	public class InvitedVisitorsMeetingListRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "location_id")]
		public string LocationId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }
	}
}
