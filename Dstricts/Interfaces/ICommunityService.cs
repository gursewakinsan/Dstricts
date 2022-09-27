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
        Task<List<Models.CommunitySelectedAmenitiesRulesInfoResponse>> CommunitySelectedAmenitiesRulesInfoAsync(Models.CommunitySelectedAmenitiesRulesInfoRequest request);
        Task<Models.CommunitySelectedAmenitiesInfoResponse> CommunitySelectedAmenitiesInfoAsync(Models.CommunitySelectedAmenitiesInfoRequest request);
        Task<List<Models.ApartmentCommunityParkingsResponse>> ApartmentCommunityParkingsAsync(Models.CommunityAvailableTenantsInfoRequest request);
        Task<Models.BuildingSelectedParkingInfoResponse> BuildingSelectedParkingInfoAsync(Models.BuildingSelectedParkingInfoRequest request);
        Task<Models.BuildingSelectedAmenitiesInfoResponse> BuildingSelectedAmenitiesInfoAsync(Models.BuildingSelectedAmenitiesInfoRequest request);
    }
}
