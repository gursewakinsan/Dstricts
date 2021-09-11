using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Service
{
	public class QueueService : IQueueService
	{
		public Task<List<Models.AvalibleQueueOnTheLocationResponse>> GetAvalibleQueueOnTheLocationAsync(Models.AvalibleQueueOnTheLocationRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.AvalibleQueueOnTheLocationResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.AvalibleQueueOnTheLocationUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
