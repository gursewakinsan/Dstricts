using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
	public interface ICartService
	{
		Task<Models.AddFoodItemToCartResponse> AddFoodItemToCartAsync(Models.AddFoodItemToCartRequest request);
		Task<int> CartItemCountAsync(Models.CartItemCountRequest request);
		Task<List<Models.CartInfoResponse>> CartInfoAsync(Models.CartInfoRequest request);
		Task<Models.UpdateCartItemCountResponse> UpdateCartItemCountAsync(Models.UpdateCartItemCountRequest request);
	}
}
