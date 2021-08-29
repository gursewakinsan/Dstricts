using System.Collections.Generic;

namespace Dstricts.Models
{
	public class HotelCompleteInfoResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "hotel_description")]
		public string HotelDescription { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "visiting_address")]
		public string VisitingAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "hotel_name")]
		public string HotelName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "hotel_images")]
		public List<HotelImages> HotelImages { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "inhouse_resturants")]
		public List<InhouseResturantsInfo> InhouseResturants { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "inhouse_fittness")]
		public List<InhouseFittnessInfo> InhouseFittness { get; set; }
	}
}

public class HotelImages
{
	public string ImageUrl { get; set; }
}

public class InhouseResturantsInfo
{
	[Newtonsoft.Json.JsonProperty(PropertyName = "rtype")]
	public int Rtype { get; set; }

	[Newtonsoft.Json.JsonProperty(PropertyName = "resturant_type")]
	public string ResturantType { get; set; }
	public string ImageUrl { get; set; }
}

public class InhouseFittnessInfo
{
	[Newtonsoft.Json.JsonProperty(PropertyName = "ctype")]
	public int CType { get; set; }

	[Newtonsoft.Json.JsonProperty(PropertyName = "center_type")]
	public string CenterType { get; set; }
	public string ImageUrl { get; set; }
}