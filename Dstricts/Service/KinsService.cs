using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Service
{
    public class KinsService : IKinsService
    {
        public Task<List<Models.kinsListResponse>> KinsListAsync(Models.kinsListRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<List<Models.kinsListResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.kinsListUrl)), string.Empty, request.ToJson());
                return res;
            });
        }
    }
}
