﻿using System.Net;
using Dstricts.Helper;
using Dstricts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Service
{
    public class CommunityService : ICommunityService
    {
		public Task<bool> GetCommunityInfoAsync(Models.CommunityInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<bool>(HttpWebRequest.Create(string.Format(EndPointsList.GetCommunityInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.TicketTitleInfoResponse>> GetTicketTitleInfoAsync(Models.TicketTitleInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.TicketTitleInfoResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.GetTicketTitleInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.TicketSubTitleInfoResponse>> GetTicketSubTitleInfoAsync(Models.TicketSubTitleInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.TicketSubTitleInfoResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.GetTicketSubTitleInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
