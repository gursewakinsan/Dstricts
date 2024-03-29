﻿using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
	public interface ICartService
	{
		Task<int> AddFoodItemToCartAsync(Models.AddFoodItemToCartRequest request);
		Task<int> CartItemCountAsync(Models.CartItemCountRequest request);
		Task<List<Models.CartInfoResponse>> CartInfoAsync(Models.CartInfoRequest request);
		Task<int> UpdateCartItemCountAsync(Models.UpdateCartItemCountRequest request);
		Task<int> CartItemCountInfoAsync(Models.CartItemCountInfoRequest request);
		Task<List<Models.CartInfoListResponse>> CartInfoListAsync(Models.CartInfoListRequest request);
		Task<int> UpdateCartItemCountInfoAsync(Models.UpdateCartItemCountInfoRequest request);
	}
}
