using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
    public interface ISosService
    {
        Task<List<Models.TravelAppAvailableSosResponse>> TravelAppAvailableSosAsync(Models.TravelAppAvailableSosRequest request);
        Task<List<Models.TravelAppCompanyResponse>> TravelAppCompanyAsync(Models.TravelAppCompanyRequest request);
        Task<List<Models.TravelAppCompanyLocationsResponse>> TravelAppCompanyLocationsAsync(Models.TravelAppCompanyLocationsRequest request);
    }
}
