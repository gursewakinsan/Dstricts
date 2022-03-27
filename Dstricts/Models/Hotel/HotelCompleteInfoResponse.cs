using System.Collections.Generic;

namespace Dstricts.Models
{
	public class HotelCompleteInfoResponse
	{

		[Newtonsoft.Json.JsonProperty(PropertyName = "dry_cleaning")]
		public bool IsDryCleaning { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "hotel_description")]
		public string HotelDescription { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "visiting_address")]
		public string VisitingAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "hotel_name")]
		public string HotelName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkin_date")]
		public string CheckinDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkout_date")]
		public string CheckoutDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "hotel_images")]
		public List<HotelImages> HotelImages { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "inhouse_resturants")]
		public List<InhouseResturantsInfo> InhouseResturants { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "inhouse_fittness")]
		public List<InhouseFittnessInfo> InhouseFittness { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "hotel_venues")]
		public List<HotelVenue> HotelVenues { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_adult")]
		public int GuestAdult { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_children")]
		public int GuestChildren { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "room_name")]
		public int RoomName { get; set; }
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
	[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
	public int Id { get; set; }

	[Newtonsoft.Json.JsonProperty(PropertyName = "center_name")]
	public string CenterName { get; set; }

	[Newtonsoft.Json.JsonProperty(PropertyName = "ctype")]
	public int CType { get; set; }

	[Newtonsoft.Json.JsonProperty(PropertyName = "center_type")]
	public string CenterType { get; set; }

	public string ImageUrl { get; set; }
	public double ImgWidth { get; set; }
	public double ImgHeight { get; set; }
}

public class HotelVenue
{
	[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
	public int Id { get; set; }

	[Newtonsoft.Json.JsonProperty(PropertyName = "venue_name")]
	public string VenueName { get; set; }

	[Newtonsoft.Json.JsonProperty(PropertyName = "image_path1")]
	public string ImagePath { get; set; }
	public double ImgWidth { get; set; }
	public double ImgHeight { get; set; }
}