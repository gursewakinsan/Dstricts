using System.Threading.Tasks;

namespace Dstricts.Interfaces
{
	public interface IVenueService
	{
		Task<Models.VenueInfomationDetailResponse> VenueInfomationDetailAsync(Models.VenueInfomationDetailRequest request);
	}
}
