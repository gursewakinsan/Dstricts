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
		Task<List<Models.AddServiceToCartAppResponse>> CartInfoWellnessListAsync(Models.CartInfoWellnessListRequest request);
		Task<List<Models.SelectEmployeeForSelectedServicesResponse>> SelectEmployeeForSelectedServicesAsync(Models.SelectEmployeeForSelectedServicesRequest request);
		Task<List<Models.AvailableDatesForbookingResponse>> AvailableDatesForbookingAsync(Models.AvailableDatesForbookingRequest request);
		Task<List<Models.EmployeeBookingCalenderInfoAppResponse>> EmployeeBookingCalenderInfoAppAsync(Models.EmployeeBookingCalenderInfoAppRequest request);
		Task<string> WellnessCartBookingTimeUpdateAsync(Models.WellnessCartBookingTimeUpdateRequest request);
		Task<string> DeleteWellnessSharedItemsAsync(Models.DeleteWellnessSharedItemsRequest request);
		Task<List<Models.EmployeeBookingCalenderInfoAppResponse>> WellnessPrivateCalenderInfoAppAsync(Models.EmployeeBookingCalenderInfoAppRequest request);
	}
}
