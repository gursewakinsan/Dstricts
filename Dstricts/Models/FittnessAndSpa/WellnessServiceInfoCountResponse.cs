namespace Dstricts.Models
{
	public class WellnessServiceInfoCountResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "public_service")]
		public bool PublicService { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "private_service")]
		public bool PrivateService { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "onetoone")]
		public bool OneToOne { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "onecart")]
		public bool? OneCart { get; set; }
	}
}
