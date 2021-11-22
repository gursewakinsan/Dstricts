namespace Dstricts.Models
{
	public class PublishedResturantInfoRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "resturant_id")]
		public int ResturantId { get; set; }
	}
}
