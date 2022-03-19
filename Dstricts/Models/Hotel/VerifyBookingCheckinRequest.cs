namespace Dstricts.Models
{
	public class VerifyBookingCheckinRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dstricts_user_id")]
		public int DstrictsUserId { get; set; }
	}
}
