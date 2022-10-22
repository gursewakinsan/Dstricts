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
		public string RoomName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "room_type")]
		public string RoomType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "first_name")]
		public string FirstName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wifi_available")]
		public bool WifiAvailable { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wifi_username")]
		public string WifiUsername { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wifi_password")]
		public string WifiPassword { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_adult_left")]
		public int GuestAdultLeft { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_children_left")]
		public int GuestChildrenLeft { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_checkin_left")]
		public int GuestCheckinLeft { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_adult_checkedin")]
		public int GuestAdultCheckedIn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_children_checkedin")]
		public int GuestChildrenCheckedIn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "room_types")]
		public List<RoomType> RoomTypes { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_perk_objects")]
		public List<GuestPerkObject> GuestPerkObjects { get; set; }

		public bool IsGuestCheckinLeft => GuestCheckinLeft > 0 ? true : false;
		public string DisplayGuestCheckinLeft => $"{GuestCheckinLeft} Left";
    }
}

public class GuestPerkObject
{
	[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
	public int Id { get; set; }

	[Newtonsoft.Json.JsonProperty(PropertyName = "perk_object_name")]
	public string PerkObjectName { get; set; }

	[Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
	public string ImagePath { get; set; }

	public int ItemWidth { get; set; }
}

public class RoomType
{
	[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
	public int Id { get; set; }

	[Newtonsoft.Json.JsonProperty(PropertyName = "room_type_name")]
	public int RoomTypeName { get; set; }

	[Newtonsoft.Json.JsonProperty(PropertyName = "room_type")]
	public string Room_Type { get; set; }

	[Newtonsoft.Json.JsonProperty(PropertyName = "is_available")]
	public bool IsAvailable { get; set; }

	[Newtonsoft.Json.JsonProperty(PropertyName = "image_path1")]
	public string ImagePath { get; set; }

	public int ItemWidth { get; set; }
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

	public double ImgWidth { get; set; }
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