namespace Dstricts.Models
{
	public class WaitListResturantResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "queue_name")]
		public string QueueName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "waiting_count")]
		public int WaitingCount { get; set; }

		/*[Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
		public int CompanyId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "location_id")]
		public int LocationId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "total_operators")]
		public int TotalOperators { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "opening_time")]
		public string OpeningTime { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "closing_time")]
		public string ClosingTime { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "tokan_closing")]
		public string TokanClosing { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
		public string CreatedOn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "published_queue")]
		public int PublishedQueue { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_active")]
		public bool IsActive { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dining_id")]
		public int DiningId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "queue_type")]
		public int QueueType { get; set; }*/
	}
}
