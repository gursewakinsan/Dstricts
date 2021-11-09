using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
	public interface ILaundryService
	{
		Task<List<Models.SelectedLaundaryCategoriesResponse>> SelectedLaundaryCategoriesAsync(Models.SelectedLaundaryCategoriesRequest request);
		Task<List<Models.SelectedDryCleaningServeBasedAppMenuResponse>> SelectedDryCleaningServeBasedAppMenuAsync(Models.SelectedDryCleaningServeBasedAppMenuRequest request);
		Task<int> AddDryCleaningItemToCartAsync(Models.AddDryCleaningItemToCartRequest request);
	}
}
