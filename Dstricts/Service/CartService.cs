﻿using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Service
{
	public class CartService : ICartService
	{
		public Task<int> AddFoodItemToCartAsync(Models.AddFoodItemToCartRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.AddFoodItemToCartUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> CartItemCountAsync(Models.CartItemCountRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.CartItemCountUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.CartInfoResponse>> CartInfoAsync(Models.CartInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.CartInfoResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.CartInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateCartItemCountAsync(Models.UpdateCartItemCountRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateCartItemCountUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> CartItemCountInfoAsync(Models.CartItemCountInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.CartItemCountInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.CartInfoListResponse>> CartInfoListAsync(Models.CartInfoListRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.CartInfoListResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.CartInfoListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateCartItemCountInfoAsync(Models.UpdateCartItemCountInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateCartItemCountInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
