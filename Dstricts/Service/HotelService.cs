﻿using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Service
{
	public class HotelService : IHotelService
	{
		public Task<List<Models.CheckedInResponse>> CheckedInHotelAsync(Models.CheckedInRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.CheckedInResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.CheckedInHotelListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.CheckedInResponse>> CheckedInApartmentAsync(Models.CheckedInRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.CheckedInResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.CheckedInApartmentListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.VerifyCheckedInCodeResponse> VerifyCheckedInCodeAsync(Models.VerifyCheckedInCodeRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.VerifyCheckedInCodeResponse>(HttpWebRequest.Create(string.Format(EndPointsList.VerifyCheckedInCodeUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}