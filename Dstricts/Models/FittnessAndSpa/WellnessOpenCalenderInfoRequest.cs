namespace Dstricts.Models
{
	public class WellnessOpenCalenderInfoRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "dstricts_user_id")]
		public int DstrictsUserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkid")]
		public int CheckId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wellness_id")]
		public int WellnessId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "employee_id")]
		public int EmployeeId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "date_id")]
		public int DateId { get; set; }
	}
}
