using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Service
{
	public class BookService : IBookService
	{
		public Task<int> WellnessUpdateFollowingAsync(Models.WellnessUpdateFollowingRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.WellnessUpdateFollowingUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> WellnessSearchFollowingCountAsync(Models.WellnessSearchFollowingCountRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.WellnessSearchFollowingCountUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.SelectedWellnessCategoriesAndMenuResponse>> SelectedWellnessCategoriesandMenuAsync(Models.SelectedWellnessCategoriesandMenuRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.SelectedWellnessCategoriesAndMenuResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.SelectedWellnessCategoriesandMenuUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
