using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Service
{
	public class AmenitiesService : IAmenitiesService
	{
		public Task<List<Models.AmenitiesResponse>> HotelRoomAppAmenitiesAsync(Models.AmenitiesRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.AmenitiesResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.HotelRoomAppAmenitiesUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.AmenitiesResponse>> HotelBedAppAmenitiesAsync(Models.AmenitiesRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.AmenitiesResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.HotelBedAppAmenitiesUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.AmenitiesResponse>> HotelMediaAppAmenitiesAsync(Models.AmenitiesRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.AmenitiesResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.HotelMediaAppAmenitiesUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.AmenitiesResponse>> HotelBathroomAppAmenitiesAsync(Models.AmenitiesRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.AmenitiesResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.HotelBathroomAppAmenitiesUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> CartAmenityItemCountAsync(Models.CartAmenityItemCountRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.CartAmenityItemCountUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> OrderHotelAppAmenityAsync(Models.OrderHotelAppAmenityRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.OrderHotelAppAmenityUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
