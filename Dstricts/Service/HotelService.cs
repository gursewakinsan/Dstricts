using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Service
{
	public class HotelService : IHotelService
	{
		public Task<List<Models.CheckedInResponse>> CheckedInHotelAsync(Models.CheckedInRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.CheckedInResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.CheckedInHotelListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.CheckedInResponse>> CheckedInApartmentAsync(Models.CheckedInRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.CheckedInResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.CheckedInApartmentListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.UserQueueListResponse>> UserQueueListAsync(Models.UserQueueListRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.UserQueueListResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.UserQueueListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.VerifyCheckedInCodeResponse> VerifyCheckedInCodeAsync(Models.VerifyCheckedInCodeRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.VerifyCheckedInCodeResponse>(HttpWebRequest.Create(string.Format(EndPointsList.VerifyCheckedInCodeUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.HotelCompleteInfoResponse> HotelCompleteInfoAsync(Models.HotelCompleteInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.HotelCompleteInfoResponse>(HttpWebRequest.Create(string.Format(EndPointsList.HotelCompleteInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.SelectedRoomServiceAppMenuResponse>> SelectedRoomServiceAppMenuAsync(Models.SelectedRoomServiceAppMenuRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.SelectedRoomServiceAppMenuResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.SelectedRoomServiceAppMenuUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.ResturantProfileInfoResponse> ResturantProfileInfoAsync(Models.ResturantProfileInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.ResturantProfileInfoResponse>(HttpWebRequest.Create(string.Format(EndPointsList.ResturantProfileInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.ResturantServeInfoResponse>> ResturantServeInfoAsync(Models.ResturantServeInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.ResturantServeInfoResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.ResturantServeInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.ResturantServeBasedMenuResponse>> ResturantServeBasedMenuAsync(Models.ResturantServeBasedMenuRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.ResturantServeBasedMenuResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.ResturantServeBasedMenuUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.ResturantWorkInfoResponse>> ResturantWorkInfoAsync(Models.ResturantWorkInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.ResturantWorkInfoResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.ResturantWorkInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.ResturantTableAvailableResponse>> ResturantTableAvailableAsync(Models.ResturantTableAvailableRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.ResturantTableAvailableResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.ResturantTableAvailableUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> RequestTableBookingAsync(Models.RequestTableBookingRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.RequestTableBookingUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.SelectedRoomServiceAppServesResponse>> SelectedRoomServiceAppServesAsync(Models.SelectedRoomServiceAppServesRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.SelectedRoomServiceAppServesResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.SelectedRoomServiceAppServesUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.SelectedRoomServiceServeBasedAppMenuResponse>> SelectedRoomServiceServeBasedAppMenuAsync(Models.SelectedRoomServiceServeBasedAppMenuRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.SelectedRoomServiceServeBasedAppMenuResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.SelectedRoomServiceServeBasedAppMenuUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> AddFoodToCartAsync(Models.AddFoodToCartRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.AddFoodToCartUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateGuestRecordAsync(Models.UpdateGuestRecordRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateGuestRecordUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.DependentsListForCheckinDstrictResponse>> DependentsListForCheckinDstrictAsync(Models.DependentsListForCheckinDstrictRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.DependentsListForCheckinDstrictResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.DependentsListForCheckinDstrictUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> AddDependentChekinAsync(Models.AddDependentChekinRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.AddDependentChekinUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.DependentsCheckedInListResponse>> DependentsCheckedInListAsync(Models.DependentsCheckedInListRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.DependentsCheckedInListResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.DependentsCheckedInListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.CountryCodeListResponse>> CountryCodeListAsync()
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.CountryCodeListResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.CountryCodeUrl)), string.Empty, null);
				return res;
			});
		}

		public Task<int> PhoneIinviteAdultForCheckinAsync(Models.PhoneIinviteAdultForCheckinRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.PhoneIinviteAdultForCheckinUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> EmailIinviteAdultForCheckinAsync(Models.EmailIinviteAdultForCheckinRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.EmailIinviteAdultForCheckinUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}