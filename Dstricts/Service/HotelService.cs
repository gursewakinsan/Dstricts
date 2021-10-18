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

		public Task<List<Models.CheckedInResponse>> UserQueueListAsync(Models.CheckedInRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.CheckedInResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.UserQueueListUrl)), string.Empty, request.ToJson());
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
	}
}
