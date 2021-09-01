using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
	public interface IHotelService
	{
		Task<List<Models.CheckedInResponse>> CheckedInHotelAsync(Models.CheckedInRequest request);
		Task<List<Models.CheckedInResponse>> CheckedInApartmentAsync(Models.CheckedInRequest request);
		Task<Models.VerifyCheckedInCodeResponse> VerifyCheckedInCodeAsync(Models.VerifyCheckedInCodeRequest request);
		Task<Models.HotelCompleteInfoResponse> HotelCompleteInfoAsync(Models.HotelCompleteInfoRequest request);
		Task<List<Models.SelectedRoomServiceAppMenuResponse>> SelectedRoomServiceAppMenuAsync(Models.SelectedRoomServiceAppMenuRequest request);
	}
}

