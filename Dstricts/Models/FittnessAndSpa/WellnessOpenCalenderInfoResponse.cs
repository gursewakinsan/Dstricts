namespace Dstricts.Models
{
	public class WellnessOpenCalenderInfoResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "day_id")]
		public string DayId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "event_day")]
		public string EventDay { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "work_time")]
		public string WorkTime { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "time_required")]
		public int TimeRequired { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "date")]
		public int Date { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "emp_id")]
		public int EmpId { get; set; }

		public int DisplayDurationMin => TimeRequired * 30;
	}
}
