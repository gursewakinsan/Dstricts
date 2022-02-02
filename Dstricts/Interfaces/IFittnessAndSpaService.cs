using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
	public interface IFittnessAndSpaService
	{
		Task<List<Models.FittnessAndSpaCategoryResponse>> SelectedWellnessCategoriesAsync(Models.FittnessAndSpaCategoryRequest request);
		Task<List<Models.FittnessAndSpaSelectedCategoryResponse>> SelectedWellnessBookingAppMenuAsync(Models.FittnessAndSpaSelectedCategoryRequest request);
		Task<List<Models.AddServiceToCartAppResponse>> AddServiceToCartAppAsync(Models.AddServiceToCartAppRequest request);
		Task<int> UpdateWellnessCartItemAsync(Models.UpdateWellnessCartItemRequest request);
	}
}
