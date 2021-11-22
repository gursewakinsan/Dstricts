namespace Dstricts.Models
{
	public class PublishedResturantInfoResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "publish_dropin")]
		public bool PublishDropIn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "publish_book_table")]
		public bool PublishBookTable { get; set; }
	}
}
