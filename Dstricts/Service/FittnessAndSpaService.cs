using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Service
{
	public class FittnessAndSpaService : IFittnessAndSpaService
	{
		public Task<List<Models.FittnessAndSpaCategoryResponse>> SelectedWellnessCategoriesAsync(Models.FittnessAndSpaCategoryRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.FittnessAndSpaCategoryResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.SelectedWellnessCategoriesUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.FittnessAndSpaSelectedCategoryResponse>> SelectedWellnessBookingAppMenuAsync(Models.FittnessAndSpaSelectedCategoryRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.FittnessAndSpaSelectedCategoryResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.SelectedWellnessBookingAppMenuUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.AddServiceToCartAppResponse>> AddServiceToCartAppAsync(Models.AddServiceToCartAppRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.AddServiceToCartAppResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.AddServiceToCartAppUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateWellnessCartItemAsync(Models.UpdateWellnessCartItemRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateWellnessCartItemUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
