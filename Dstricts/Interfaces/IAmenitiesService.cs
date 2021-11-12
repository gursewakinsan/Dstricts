using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
	public interface IAmenitiesService
	{
		Task<List<Models.AmenitiesResponse>> HotelRoomAppAmenitiesAsync(Models.AmenitiesRequest request);
		Task<List<Models.AmenitiesResponse>> HotelBedAppAmenitiesAsync(Models.AmenitiesRequest request);
		Task<List<Models.AmenitiesResponse>> HotelMediaAppAmenitiesAsync(Models.AmenitiesRequest request);
		Task<List<Models.AmenitiesResponse>> HotelBathroomAppAmenitiesAsync(Models.AmenitiesRequest request);
		Task<int> CartAmenityItemCountAsync(Models.CartAmenityItemCountRequest request);
		Task<int> OrderHotelAppAmenityAsync(Models.OrderHotelAppAmenityRequest request);
		Task<List<Models.CartAmenityInfoListResponse>> CartAmenityInfoListAsync(Models.CartAmenityInfoListRequest request);
		Task<int> UpdateAmenityCartItemCountAsync(Models.UpdateAmenityCartItemCountRequest request);
	}
}
