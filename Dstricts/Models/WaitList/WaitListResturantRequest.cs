namespace Dstricts.Models
{
	public class WaitListResturantRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "resturant_id")]
		public int ResturantId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "queue_type")]
		public int QueueType { get; set; }
	}
}
