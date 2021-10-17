namespace Dstricts.Models
{
	public class ResturantProfileInfoRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "resturant_id")]
		public int ResturantId { get; set; }
	}
}
