using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Service
{
	public class SearchService : ISearchService
	{
		public Task<List<Models.SearchUserResponse>> SearchUserAsync(Models.SearchRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.SearchUserResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.UsersListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.SearchCompanyResponse>> SearchCompanyAsync(Models.SearchRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.SearchCompanyResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.CompanyListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.SearchResturantResponse>> SearchResturantAsync(Models.SearchRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.SearchResturantResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.ResturantSearchListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.SearchWellnessResponse>> SearchWellnessAsync(Models.SearchWellnessRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.SearchWellnessResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.WellnessSearchListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
