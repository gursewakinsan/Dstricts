using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;

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
	}
}
