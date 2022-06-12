using System.Threading.Tasks;

namespace Dstricts.Interfaces
{
	public interface IApartmentService
	{
		Task<Models.ApartmentDetailInfoResponse> ApartmentDetailInfoAsync(Models.ApartmentDetailInfoRequest request);
	}
}
