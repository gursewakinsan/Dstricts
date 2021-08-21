using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
	public interface IHotelService
	{
		Task<List<Models.CheckedInResponse>> CheckedInHotelAsync(Models.CheckedInRequest request);
		Task<List<Models.CheckedInResponse>> CheckedInApartmentAsync(Models.CheckedInRequest request);
		Task<int> VerifyCheckedInCodeAsync(Models.VerifyCheckedInCodeRequest request);
	}
}
