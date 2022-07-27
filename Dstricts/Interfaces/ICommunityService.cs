using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
    public interface ICommunityService
    {
        Task<int> GetCommunityInfoAsync(Models.CommunityInfoRequest request);
        Task<List<Models.TicketTitleInfoResponse>> GetTicketTitleInfoAsync(Models.TicketTitleInfoRequest request);
        Task<List<Models.TicketSubTitleInfoResponse>> GetTicketSubTitleInfoAsync(Models.TicketSubTitleInfoRequest request);
        Task<int> CreateCommunityTicketAsync(Models.CreateCommunityTicketRequest request);
    }
}
