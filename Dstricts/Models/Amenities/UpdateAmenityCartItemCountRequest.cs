namespace Dstricts.Models
{
	public class UpdateAmenityCartItemCountRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "quantity")]
		public int Quantity { get; set; }
	}
}
