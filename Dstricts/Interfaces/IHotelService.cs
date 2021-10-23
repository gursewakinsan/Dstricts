using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
	public interface IHotelService
	{
		Task<List<Models.CheckedInResponse>> CheckedInHotelAsync(Models.CheckedInRequest request);
		Task<List<Models.CheckedInResponse>> CheckedInApartmentAsync(Models.CheckedInRequest request);
		Task<List<Models.CheckedInResponse>> UserQueueListAsync(Models.CheckedInRequest request);
		Task<Models.VerifyCheckedInCodeResponse> VerifyCheckedInCodeAsync(Models.VerifyCheckedInCodeRequest request);
		Task<Models.HotelCompleteInfoResponse> HotelCompleteInfoAsync(Models.HotelCompleteInfoRequest request);
		Task<List<Models.SelectedRoomServiceAppMenuResponse>> SelectedRoomServiceAppMenuAsync(Models.SelectedRoomServiceAppMenuRequest request);
		Task<Models.ResturantProfileInfoResponse> ResturantProfileInfoAsync(Models.ResturantProfileInfoRequest request);
		Task<List<Models.ResturantServeInfoResponse>> ResturantServeInfoAsync(Models.ResturantServeInfoRequest request);
		Task<List<Models.ResturantServeBasedMenuResponse>> ResturantServeBasedMenuAsync(Models.ResturantServeBasedMenuRequest request);
		Task<List<Models.ResturantWorkInfoResponse>> ResturantWorkInfoAsync(Models.ResturantWorkInfoRequest request);
		Task<List<Models.ResturantTableAvailableResponse>> ResturantTableAvailableAsync(Models.ResturantTableAvailableRequest request);
		Task<int> RequestTableBookingAsync(Models.RequestTableBookingRequest request);
	}
}

