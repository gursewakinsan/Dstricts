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
	}
}
