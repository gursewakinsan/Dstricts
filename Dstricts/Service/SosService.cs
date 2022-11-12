using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Service
{
    public class SosService : ISosService
    {
		public Task<List<Models.TravelAppAvailableSosResponse>> TravelAppAvailableSosAsync(Models.TravelAppAvailableSosRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.TravelAppAvailableSosResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.TravelAppAvailableSosUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.TravelAppCompanyResponse>> TravelAppCompanyAsync(Models.TravelAppCompanyRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.TravelAppCompanyResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.TravelAppCompanyUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
