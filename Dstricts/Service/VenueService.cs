using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;

namespace Dstricts.Service
{
	public class VenueService : IVenueService
	{
		public Task<Models.VenueInfomationDetailResponse> VenueInfomationDetailAsync(Models.VenueInfomationDetailRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.VenueInfomationDetailResponse>(HttpWebRequest.Create(string.Format(EndPointsList.VenueInfomationDetailUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
