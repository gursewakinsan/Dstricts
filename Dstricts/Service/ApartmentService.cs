using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Service
{
	public class ApartmentService : IApartmentService
	{
		public Task<Models.ApartmentDetailInfoResponse> ApartmentDetailInfoAsync(Models.ApartmentDetailInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.ApartmentDetailInfoResponse>(HttpWebRequest.Create(string.Format(EndPointsList.ApartmentDetailInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.ApartmentDetailInfoCheckinResponse> ApartmentDetailInfoCheckinAsync(Models.ApartmentDetailInfoCheckinRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.ApartmentDetailInfoCheckinResponse>(HttpWebRequest.Create(string.Format(EndPointsList.ApartmentDetailInfoCheckinUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.GetSratedDetailResponse>> GetSratedDetailAsync(Models.GetSratedDetailRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.GetSratedDetailResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.GetSratedDetailUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.ApartmentCommunityAmenitiesResponse> ApartmentBuildingAmenitiesAsync(Models.ApartmentBuildingAmenitiesRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.ApartmentCommunityAmenitiesResponse>(HttpWebRequest.Create(string.Format(EndPointsList.ApartmentBuildingAmenitiesUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.ApartmentCommunityParkingsResponse>> ApartmentBuildingParkingsAsync(Models.ApartmentBuildingAmenitiesRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.ApartmentCommunityParkingsResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.ApartmentBuildingParkingsUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
