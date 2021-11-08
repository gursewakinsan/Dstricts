using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Service
{
	public class LaundryService : ILaundryService
	{
		public Task<List<Models.SelectedLaundaryCategoriesResponse>> SelectedLaundaryCategoriesAsync(Models.SelectedLaundaryCategoriesRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.SelectedLaundaryCategoriesResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.SelectedLaundaryCategoriesUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
