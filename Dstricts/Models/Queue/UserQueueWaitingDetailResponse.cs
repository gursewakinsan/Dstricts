namespace Dstricts.Models
{
	public class UserQueueWaitingDetailResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_name")]
		public string GuestName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_serviced")]
		public int IsServiced { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "queue_name")]
		public string QueueName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
		public string ImagePath { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "address")]
		public string Address { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "company_name")]
		public string CompanyName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "hash_tag")]
		public string HashTag { get; set; }
	}
}
