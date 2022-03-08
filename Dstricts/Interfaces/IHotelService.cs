using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
	public interface IHotelService
	{
		Task<List<Models.CheckedInResponse>> CheckedInHotelAsync(Models.CheckedInRequest request);
		Task<List<Models.CheckedInResponse>> CheckedInApartmentAsync(Models.CheckedInRequest request);
		Task<List<Models.UserQueueListResponse>> UserQueueListAsync(Models.UserQueueListRequest request);
		Task<Models.VerifyCheckedInCodeResponse> VerifyCheckedInCodeAsync(Models.VerifyCheckedInCodeRequest request);
		Task<Models.HotelCompleteInfoResponse> HotelCompleteInfoAsync(Models.HotelCompleteInfoRequest request);
		Task<List<Models.SelectedRoomServiceAppMenuResponse>> SelectedRoomServiceAppMenuAsync(Models.SelectedRoomServiceAppMenuRequest request);
		Task<Models.ResturantProfileInfoResponse> ResturantProfileInfoAsync(Models.ResturantProfileInfoRequest request);
		Task<List<Models.ResturantServeInfoResponse>> ResturantServeInfoAsync(Models.ResturantServeInfoRequest request);
		Task<List<Models.ResturantServeBasedMenuResponse>> ResturantServeBasedMenuAsync(Models.ResturantServeBasedMenuRequest request);
		Task<List<Models.ResturantWorkInfoResponse>> ResturantWorkInfoAsync(Models.ResturantWorkInfoRequest request);
		Task<List<Models.ResturantTableAvailableResponse>> ResturantTableAvailableAsync(Models.ResturantTableAvailableRequest request);
		Task<int> RequestTableBookingAsync(Models.RequestTableBookingRequest request);
		Task<List<Models.SelectedRoomServiceAppServesResponse>> SelectedRoomServiceAppServesAsync(Models.SelectedRoomServiceAppServesRequest request);
		Task<List<Models.SelectedRoomServiceServeBasedAppMenuResponse>> SelectedRoomServiceServeBasedAppMenuAsync(Models.SelectedRoomServiceServeBasedAppMenuRequest request);
		Task<int> AddFoodToCartAsync(Models.AddFoodToCartRequest request);
		Task<int> UpdateGuestRecordAsync(Models.UpdateGuestRecordRequest request);
		Task<List<Models.DependentsListForCheckinDstrictResponse>> DependentsListForCheckinDstrictAsync(Models.DependentsListForCheckinDstrictRequest request);
		Task<int> AddDependentChekinAsync(Models.AddDependentChekinRequest request);
		Task<List<Models.DependentsCheckedInListResponse>> DependentsCheckedInListAsync(Models.DependentsCheckedInListRequest request);
		Task<List<Models.CountryCodeListResponse>> CountryCodeListAsync();
		Task<int> PhoneIinviteAdultForCheckinAsync(Models.PhoneIinviteAdultForCheckinRequest request);
		Task<int> EmailIinviteAdultForCheckinAsync(Models.EmailIinviteAdultForCheckinRequest request);
	}
}

