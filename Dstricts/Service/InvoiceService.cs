using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Service
{
    public class InvoiceService : IInvoiceService
    {
		public Task<Models.TenantInvoiceInfoResponse> TenantInvoiceInfoAsync(Models.TenantInvoiceInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.TenantInvoiceInfoResponse>(HttpWebRequest.Create(string.Format(EndPointsList.TenantInvoiceInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
