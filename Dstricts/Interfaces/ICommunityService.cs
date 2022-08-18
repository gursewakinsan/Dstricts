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
        Task<int> AddCommunityTicketImageAsync(Models.AddCommunityTicketImageRequest request);
        Task<Models.ApartmentCommunityTicketCreatedCountResponse> ApartmentCommunityTicketCreatedCountAsync(Models.ApartmentCommunityTicketCreatedCountRequest request);
        Task<Models.GetCommunityDetailInfoResponse> GetCommunityDetailInfoAsync(Models.GetCommunityDetailInfoRequest request);
        Task<Models.ApartmentCommunityAmenitiesResponse> ApartmentCommunityAmenitiesAsync(Models.ApartmentCommunityAmenitiesRequest request);
        Task<List<Models.CommunityAvailableTenantsInfoResponse>> CommunityAvailableTenantsInfoAsync(Models.CommunityAvailableTenantsInfoRequest request);
        Task<List<Models.SocietyRulesListResponse>> SocietyRulesListAsync(Models.SocietyRulesListRequest request);

    }
}
