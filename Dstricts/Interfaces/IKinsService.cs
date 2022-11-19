using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
    public interface IKinsService
    {
        Task<List<Models.kinsListResponse>> KinsListAsync(Models.kinsListRequest request);
    }
}
