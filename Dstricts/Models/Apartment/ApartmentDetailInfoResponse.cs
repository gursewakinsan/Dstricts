namespace Dstricts.Models
{
	public class ApartmentDetailInfoResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "address")]
		public string Address { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "city")]
		public string City { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "zipcode")]
		public string ZipCode { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "port_number")]
		public string PortNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "you_address")] 
		public string YouAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "you_city")]
		public string YouCity { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "you_zipcode")]
		public string YouZipCode { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "you_port_number")]
		public string YouPortNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_address")]
		public string InvoiceAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_city")]
		public string InvoiceCity { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_zipcode")]
		public string InvoiceZipcode { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "invoice_port_number")]
		public string InvoicePortNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_name_same")]
		public int IsNameSame { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_invoice_same")]
		public int IsInvoiceSame { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name_on_house")]
		public string NameOnHouse { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_personal_address")]
		public int IsPersonalAddress { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
		public string CreatedOn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "entry_code")]
		public string EntryCode { get; set; }
		public string DisplayEntryCode => string.IsNullOrWhiteSpace(EntryCode) ? "Not required" : EntryCode;

		[Newtonsoft.Json.JsonProperty(PropertyName = "property_layout")]
		public string PropertyLayout { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "property_type")]
		public int PropertyType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "floors_available")]
		public int FloorsAvailable { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "entrance_floor")]
		public int EntranceFloor { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "private_entrance")]
		public int PrivateEntrance { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "elevator")]
		public int Elevator { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "latitude")]
		public string Latitude { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "longitude")]
		public string Longitude { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "arrival_time")]
		public string ArrivalTime { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "departure_time")]
		public string DepartureTime { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "children_allowed")]
		public bool IsChildrenAllowed { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "infants_allowed")]
		public bool IsInfantsAllowed { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "smoking_allowed")]
		public bool IsSmokingAllowed { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "events_allowed")]
		public bool IsEventsAllowed { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "pets_allowed")]
		public bool IsPetsAllowed { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "cleening_fee_applicable")]
		public int CleeningFeeApplicable { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "cleening_fee")]
		public int CleeningFee { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "security_fee_applicable")]
		public int SecurityFeeApplicable { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "security_fee")]
		public int SecurityFee { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "property_nickname")]
		public string PropertyNickName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "property_heading")]
		public string PropertyHeading { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "heading_type")]
		public int HeadingType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "booking_notice")]
		public int BookingNotice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "apartment_description")]
		public string ApartmentDescription { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_published")]
		public int IsPublished { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "state")]
		public string State { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "sale_price")]
		public string SalePrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "publish_dstrict_rent")]
		public int PublishDstrictRent { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "publish_dstrict_long_rent")]
		public int PublishDstrictLongRent { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "publish_dstrict_sale")]
		public int PublishDstrictSale { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "publish_airnub")]
		public int PublishAirnub { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "publish_booking")]
		public int PublishBooking { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "publish_vrbo")]
		public int PublishVrbo { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "publish_trip")]
		public int PublishTrip { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "publish_exptd")]
		public int PublishExptd { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "publish_tui")]
		public int PublishTui { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "total_channels")]
		public int TotalChannels { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "monthly_price")]
		public string MonthlyPrice { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "contract_length")]
		public int ContractLength { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "security_fee_applicable_long")]
		public int SecurityFeeApplicableLong { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "security_fee_months")]
		public int SecurityFeeMonths { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "district_rent")]
		public int DistrictRent { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "district_short_rent")]
		public int DistrictShortRent { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "district_long_rent")]
		public int DistrictLongRent { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "district_sale")]
		public int DistrictSale { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "card_detail")]
		public string CardDetail { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "duration")]
		public string Duration { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest")]
		public string Guest { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public object UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "host_name")]
		public string HostName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "host_email")]
		public string HostEmail { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "host_phone")]
		public string HostPhone { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_name")]
		public string GuestName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_email")]
		public string GuestEmail { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_phone")]
		public string GuestPhone { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_id")]
		public string GuestId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "bedrooms")]
		public int Bedrooms { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guests")]
		public int Guests { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "toilet")]
		public int Toilet { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "bath")]
		public int Bath { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
		public string ImagePath { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "enc")]
		public string Enc { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "price")]
		public object Price { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "check_in_date")]
		public string CheckInDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checked_out_date")]
		public string CheckedOutDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "payment")]
		public bool IsPayment { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "building_id")]
		public int BuildingId { get; set; }


		[Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs")]
		public bool IsQuiteHrs { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs_mon_fri")]
		public bool IsQuiteHrsMonFri { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs_sat_sun")]
		public bool IsQuiteHrsSatSun { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs_mon_fri_open")]
		public string QuiteHrsMonFriOpen { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs_mon_fri_close")]
		public string QuiteHrsMonFriClose { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs_sat_sun_open")]
		public string QuiteHrsSatSunOpen { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "quite_hrs_sat_sun_close")]
		public string QuiteHrsSatSunClose { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "description")]
		public string Description { get; set; }


		[Newtonsoft.Json.JsonProperty(PropertyName = "wifi_available")]
		public bool IsWifiAvailable { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wifi_username")]
		public string WifiUserName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "wifi_password")]
		public string WifiPassword { get; set; }
	}
}