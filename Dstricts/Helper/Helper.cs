using System.Text.RegularExpressions;

namespace Dstricts.Helper
{
	public static class Helper
	{
		public static T FromJson<T>(this string jsonData)
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonData);
		}
		public static string ToJson(this object obj)
		{
			return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
		}

		public static bool IsValid(string value)
		{
			return CheckEmail(value);
		}
		public static bool CheckEmail(string input)
		{
			return Regex.IsMatch(input,
		   @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
		   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
		   RegexOptions.IgnoreCase);
		}
		public static double DeviceWidth { get; set; }
		public static bool IsLoggedInUser { get; set; } = false;
		public static int LoggedInUserId { get; set; }
		public static string LoggedInUserName { get; set; }
		public static string SessionId { get; set; }
		public static int HotelCheckedIn { get; set; }
        public static string PropertyNickName { get; set; }
        public static Models.HotelCompleteInfoResponse HotelDetails { get; set; }
		public static CategoryInfo SelectedRoomServiceMenuCategory { get; set; }
		public static bool IsRoomService { get; set; }
		public static string AvalibleQueueId { get; set; }
		public static string VerifyUserInvitationInfoId { get; set; }
		public static int SelectSearchType { get; set; }
		public static string SelectSearchText { get; set; }
		public static int SelectResturantId { get; set; }
		public static int WellnessId { get; set; }
		public static string WellnessName { get; set; }
		public static int SelectedServicesType { get; set; } = 1;
		public static bool IsFromViewCartButtonClicked { get; set; } = false;
		public static bool IsWellnessBookingType { get; set; } = false;
		public static string ServiceCategoryName { get; set; }

        public static int TicketType { get; set; }
		public static Models.TicketTitleInfoResponse TicketTitleInfo { get; set; }
		public static int CommunityId { get; set; }
		public static Models.CheckedInResponse ApartmentCheckedIn { get; set; }

		public static string VerifyCheckinId { get; set; }
		public static int HotelPropertyType { get; set; }

        public static bool IsPayment { get; set; }
		public static bool IsGuest { get; set; }
		public static int BuildingId { get; set; }
		public static Models.ApartmentDetailInfoResponse ApartmentDetailInfo { get; set; }

		public static double MyCurrentLocationLatitude { get; set; }
        public static double MyCurrentLocationLongitude { get; set; }

		public static Models.AddMissingPersonInfoRequest MissingPersonInfo { get; set; }


		public static string[] ListIconBgColorList =
		{
			"#223426", "#282732", "#342334", "#FC7125",
			"#223426", "#282732", "#342334", "#FC7125",
			"#223426", "#282732", "#342334", "#FC7125",
			"#223426", "#282732", "#342334", "#FC7125",
			"#223426", "#282732", "#342334", "#FC7125",
			"#223426", "#282732", "#342334", "#FC7125",
			"#223426", "#282732", "#342334", "#FC7125",
			"#223426", "#282732", "#342334", "#FC7125",
			"#223426", "#282732", "#342334", "#FC7125",
			"#223426", "#282732", "#342334", "#FC7125"
		};

		public static string[] ListIconTextColorList =
		{
			"#4FD471", "#6F70FB", "#E340EC","#E53614",
			"#4FD471", "#6F70FB", "#E340EC","#E53614",
			"#4FD471", "#6F70FB", "#E340EC","#E53614",
			"#4FD471", "#6F70FB", "#E340EC","#E53614",
			"#4FD471", "#6F70FB", "#E340EC","#E53614",
			"#4FD471", "#6F70FB", "#E340EC","#E53614",
			"#4FD471", "#6F70FB", "#E340EC","#E53614",
			"#4FD471", "#6F70FB", "#E340EC","#E53614",
			"#4FD471", "#6F70FB", "#E340EC","#E53614",
			"#4FD471", "#6F70FB", "#E340EC","#E53614"
		};
	}
}
