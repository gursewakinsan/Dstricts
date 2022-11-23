using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
    public interface IKinsService
    {
        Task<List<Models.kinsListResponse>> KinsListAsync(Models.kinsListRequest request);
        Task<int> AddMissingPersonInfoAsync(Models.AddMissingPersonInfoRequest request);
        Task<int> AddMissingPersonImagesAsync(Models.AddMissingPersonImageRequest request);
        Task<List<Models.MissingPersonListResponse>> MissingPersonListAsync(Models.MissingPersonListRequest request);
        Task<List<Models.MissingPersonEmergencyListResponse>> MissingPersonEmergencyListAsync(Models.MissingPersonEmergencyListRequest request);
        Task<int> ReportPersonFoundAsync(Models.ReportPersonFoundRequest request);
    }
}
