using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Service
{
	public class FittnessAndSpaService : IFittnessAndSpaService
	{
		public Task<List<Models.FittnessAndSpaCategoryResponse>> SelectedWellnessCategoriesAsync(Models.FittnessAndSpaCategoryRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.FittnessAndSpaCategoryResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.SelectedWellnessCategoriesUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.FittnessAndSpaSelectedCategoryResponse>> SelectedWellnessBookingAppMenuAsync(Models.FittnessAndSpaSelectedCategoryRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.FittnessAndSpaSelectedCategoryResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.SelectedWellnessBookingAppMenuUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.AddServiceToCartAppResponse>> AddServiceToCartAppAsync(Models.AddServiceToCartAppRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.AddServiceToCartAppResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.AddServiceToCartAppUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateWellnessCartItemAsync(Models.UpdateWellnessCartItemRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateWellnessCartItemUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.AddServiceToCartAppResponse>> CartInfoWellnessListAsync(Models.CartInfoWellnessListRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.AddServiceToCartAppResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.CartInfoWellnessListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.SelectEmployeeForSelectedServicesResponse>> SelectEmployeeForSelectedServicesAsync(Models.SelectEmployeeForSelectedServicesRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.SelectEmployeeForSelectedServicesResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.SelectEmployeeForSelectedServicesUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.AvailableDatesForbookingResponse>> AvailableDatesForbookingAsync(Models.AvailableDatesForbookingRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.AvailableDatesForbookingResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.AvailableDatesForbookingUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.EmployeeBookingCalenderInfoAppResponse>> EmployeeBookingCalenderInfoAppAsync(Models.EmployeeBookingCalenderInfoAppRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post< List<Models.EmployeeBookingCalenderInfoAppResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.EmployeeBookingCalenderInfoAppUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<string> WellnessCartBookingTimeUpdateAsync(Models.WellnessCartBookingTimeUpdateRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(string.Format(EndPointsList.WellnessCartBookingTimeUpdateUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<string> DeleteWellnessSharedItemsAsync(Models.DeleteWellnessSharedItemsRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(string.Format(EndPointsList.DeleteWellnessSharedItemsUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.EmployeeBookingCalenderInfoAppResponse>> WellnessPrivateCalenderInfoAppAsync(Models.EmployeeBookingCalenderInfoAppRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.EmployeeBookingCalenderInfoAppResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.WellnessPrivateCalenderInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.WellnessSelectedServiceInfoResponse> WellnessSelectedServiceInfoAsync(Models.WellnessSelectedServiceInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.WellnessSelectedServiceInfoResponse>(HttpWebRequest.Create(string.Format(EndPointsList.WellnessSelectedServiceInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> AddPublicServiceToCartAppAsync(Models.AddPublicServiceToCartAppRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.AddPublicServiceToCartAppUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.WellnessOpenCalenderInfoResponse> WellnessOpenCalenderInfoAsync(Models.WellnessOpenCalenderInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.WellnessOpenCalenderInfoResponse>(HttpWebRequest.Create(string.Format(EndPointsList.WellnessOpenCalenderInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}