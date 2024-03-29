﻿using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Service
{
    public class CommunityService : ICommunityService
    {
		public Task<int> GetCommunityInfoAsync(Models.CommunityInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.GetCommunityInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.TicketTitleInfoResponse>> GetTicketTitleInfoAsync(Models.TicketTitleInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.TicketTitleInfoResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.GetTicketTitleInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.TicketSubTitleInfoResponse>> GetTicketSubTitleInfoAsync(Models.TicketSubTitleInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.TicketSubTitleInfoResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.GetTicketSubTitleInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> CreateCommunityTicketAsync(Models.CreateCommunityTicketRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.CreateCommunityTicketUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> AddCommunityTicketImageAsync(Models.AddCommunityTicketImageRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.AddCommunityTicketImageUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.ApartmentCommunityTicketCreatedCountResponse> ApartmentCommunityTicketCreatedCountAsync(Models.ApartmentCommunityTicketCreatedCountRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.ApartmentCommunityTicketCreatedCountResponse>(HttpWebRequest.Create(string.Format(EndPointsList.ApartmentCommunityTicketCreatedCountUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.GetCommunityDetailInfoResponse> GetCommunityDetailInfoAsync(Models.GetCommunityDetailInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.GetCommunityDetailInfoResponse>(HttpWebRequest.Create(string.Format(EndPointsList.GetCommunityDetailInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.ApartmentCommunityAmenitiesResponse> ApartmentCommunityAmenitiesAsync(Models.ApartmentCommunityAmenitiesRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.ApartmentCommunityAmenitiesResponse>(HttpWebRequest.Create(string.Format(EndPointsList.ApartmentCommunityAmenitiesUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.CommunityAvailableTenantsInfoResponse>> CommunityAvailableTenantsInfoAsync(Models.CommunityAvailableTenantsInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.CommunityAvailableTenantsInfoResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.CommunityAvailableTenantsInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.SocietyRulesListResponse>> SocietyRulesListAsync(Models.SocietyRulesListRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.SocietyRulesListResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.SocietyRulesListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.CommunitySelectedAmenitiesRulesInfoResponse>> CommunitySelectedAmenitiesRulesInfoAsync(Models.CommunitySelectedAmenitiesRulesInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.CommunitySelectedAmenitiesRulesInfoResponse>> (HttpWebRequest.Create(string.Format(EndPointsList.CommunitySelectedAmenitiesRulesInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.CommunitySelectedAmenitiesInfoResponse> CommunitySelectedAmenitiesInfoAsync(Models.CommunitySelectedAmenitiesInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.CommunitySelectedAmenitiesInfoResponse>(HttpWebRequest.Create(string.Format(EndPointsList.CommunitySelectedAmenitiesInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.ApartmentCommunityParkingsResponse>> ApartmentCommunityParkingsAsync(Models.CommunityAvailableTenantsInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.ApartmentCommunityParkingsResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.ApartmentCommunityParkingsUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.BuildingSelectedParkingInfoResponse> BuildingSelectedParkingInfoAsync(Models.BuildingSelectedParkingInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.BuildingSelectedParkingInfoResponse>(HttpWebRequest.Create(string.Format(EndPointsList.BuildingSelectedParkingInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.BuildingSelectedAmenitiesInfoResponse> BuildingSelectedAmenitiesInfoAsync(Models.BuildingSelectedAmenitiesInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.BuildingSelectedAmenitiesInfoResponse>(HttpWebRequest.Create(string.Format(EndPointsList.BuildingSelectedAmenitiesInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}

