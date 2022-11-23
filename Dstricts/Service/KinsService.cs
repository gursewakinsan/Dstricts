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

        public Task<int> AddMissingPersonInfoAsync(Models.AddMissingPersonInfoRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.AddMissingPersonInfoUrl)), string.Empty, request.ToJson());
                return res;
            });
        }

        public Task<int> AddMissingPersonImagesAsync(Models.AddMissingPersonImageRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.AddMissingPersonImagesUrl)), string.Empty, request.ToJson());
                return res;
            });
        }

        public Task<List<Models.MissingPersonListResponse>> MissingPersonListAsync(Models.MissingPersonListRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<List<Models.MissingPersonListResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.MissingPersonListUrl)), string.Empty, request.ToJson());
                return res;
            });
        }

        public Task<List<Models.MissingPersonEmergencyListResponse>> MissingPersonEmergencyListAsync(Models.MissingPersonEmergencyListRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<List<Models.MissingPersonEmergencyListResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.MissingPersonEmergencyListUrl)), string.Empty, request.ToJson());
                return res;
            });
        }

        public Task<int> ReportPersonFoundAsync(Models.ReportPersonFoundRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.ReportPersonFoundUrl)), string.Empty, request.ToJson());
                return res;
            });
        }
    }
}
