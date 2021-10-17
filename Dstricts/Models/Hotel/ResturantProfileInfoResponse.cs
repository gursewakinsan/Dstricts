namespace Dstricts.Models
{
	public class ResturantProfileInfoResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "resturant_name")]
		public string ResturantName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "resturant_type")]
		public int ResturantType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "visiting_address")]
		public string VisitingAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "publish_dropin")]
		public int PublishDropIn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "publish_book_table")]
		public int PublishBookTable { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "publish_menu")]
		public int PublishMenu { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "big_image")]
		public string BigImage { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "small_image")]
		public string SmallImage { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "small_image2")]
		public string SmallImage2 { get; set; }
	}
}
