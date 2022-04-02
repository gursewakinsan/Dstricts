namespace Dstricts.Models
{
	public class InvitedVisitorsMeetingListResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "visiting_date")]
		public string VisitingDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "visiting_time")]
		public string VisitingTime { get; set; }
	}
}
