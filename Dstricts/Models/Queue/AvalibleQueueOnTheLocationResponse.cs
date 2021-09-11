namespace Dstricts.Models
{
	public class AvalibleQueueOnTheLocationResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "queue_name")]
		public string QueueName { get; set; }
		public string FirstLetterName => System.Globalization.StringInfo.GetNextTextElement(QueueName, 0).ToUpper();
	}
}
