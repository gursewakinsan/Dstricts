using System.Collections.Generic;
using Xamarin.Forms;

namespace Dstricts.Models
{
	public class VenueInfomationDetailResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "venue_name")]
		public string VenueName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "location_id")]
		public int LocationId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "venue_type")]
		public string VenueType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "owner_of_the_venue")]
		public int OwnerOfTheVenue { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "venue_description")]
		public string VenueDescription { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "bookable_for")]
		public int BookableFor { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "owner_id")]
		public int OwnerId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
		public int CompanyId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
		public string CreatedOn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "capacity_info")]
		public int CapacityInfo { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "standing_capacity")]
		public int StandingCapacity { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "seating_capacity")]
		public int SeatingCapacity { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "classroom_formation")]
		public int ClassroomFormation { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "theater_formation")]
		public int TheaterFormation { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "banquet_formation")]
		public int BanquetFormation { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "conference_formation")]
		public int ConferenceFormation { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "ushape_formation")]
		public int UshapeFormation { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "floor_area")]
		public int FloorArea { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "price_info")]
		public int PriceInfo { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "cleaning_fee")]
		public int CleaningFee { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "reservation_deposit")]
		public int ReservationDeposit { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "minimum_price")]
		public int MinimumPrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "full_day_price")]
		public int FullDayPrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "pre_lunch_price")]
		public int PreLunchPrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "post_lunch_price")]
		public int PostLunchPrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "photo_info")]
		public int PhotoInfo { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "nightly_price")]
		public int NightlyPrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "food_and_drink")]
		public string FoodAndDrink { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "image_path1")]
		public string ImagePath { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "venue_type_details")]
		public List<VenueTypeDetail> VenueTypeDetails { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "food_type_details")]
		public List<FoodTypeDetail> FoodTypeDetails { get; set; }

	}

	public class VenueTypeDetail
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "type_info")]
		public string TypeInfo { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "available_type")]
		public string AvailableType { get; set; }
		public Color AvailableTypeBorderColor { get; set; }
	}

	public class FoodTypeDetail : BaseModel
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "food_type")]
		public string FoodType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "available_type")]
		public string AvailableType { get; set; }
		public Color AvailableTypeBorderColor { get; set; }
	}
}
