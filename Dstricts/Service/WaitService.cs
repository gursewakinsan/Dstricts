using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Service
{
	public class WaitService : IWaitService
	{
		public Task<List<Models.WaitListResturantResponse>> WaitListResturantAsync(Models.WaitListResturantRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.WaitListResturantResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.WaitListResturantUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.PublishedResturantInfoResponse> PublishedResturantInfoAsync(Models.PublishedResturantInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.PublishedResturantInfoResponse>(HttpWebRequest.Create(string.Format(EndPointsList.PublishedResturantInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
