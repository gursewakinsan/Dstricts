using System.Collections.Generic;

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
		public static double DeviceWidth { get; set; }
		public static bool IsLoggedInUser { get; set; } = false;
		public static int LoggedInUserId { get; set; }
		public static string LoggedInUserName { get; set; }
		public static string SessionId { get; set; }
		public static int HotelCheckedIn { get; set; }
		public static Models.HotelCompleteInfoResponse HotelDetails { get; set; }
		public static CategoryInfo SelectedRoomServiceMenuCategory { get; set; }
		public static bool IsRoomService { get; set; }
		public static string AvalibleQueueId { get; set; }
		public static int SelectSearchType { get; set; }
		public static string SelectSearchText { get; set; }
	}
}
