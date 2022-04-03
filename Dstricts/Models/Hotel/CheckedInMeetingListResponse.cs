namespace Dstricts.Models
{
	public class CheckedInMeetingListResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "company_name")]
		public string CompanyName { get; set; }


		/*public string visiting_date { get; set; }
		public string visiting_time { get; set; }
		public string visiting_address { get; set; }
		public string d_port_number { get; set; }
		public string address { get; set; }*/
	}
}
