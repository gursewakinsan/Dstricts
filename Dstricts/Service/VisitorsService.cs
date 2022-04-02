using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Service
{
	public class VisitorsService : IVisitorsService
	{
		public Task<List<Models.InvitedVisitorsMeetingListResponse>> InvitedVisitorsMeetingListAsync(Models.InvitedVisitorsMeetingListRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.InvitedVisitorsMeetingListResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.InvitedVisitorsMeetingListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
