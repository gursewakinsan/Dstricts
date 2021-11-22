using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
	public interface IWaitService
	{
		Task<List<Models.WaitListResturantResponse>> WaitListResturantAsync(Models.WaitListResturantRequest request);
		Task<Models.PublishedResturantInfoResponse> PublishedResturantInfoAsync(Models.PublishedResturantInfoRequest request);
	}
}
