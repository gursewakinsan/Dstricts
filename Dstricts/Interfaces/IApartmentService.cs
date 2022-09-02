﻿using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
	public interface IApartmentService
	{
		Task<Models.ApartmentDetailInfoResponse> ApartmentDetailInfoAsync(Models.ApartmentDetailInfoRequest request);
		Task<Models.ApartmentDetailInfoCheckinResponse> ApartmentDetailInfoCheckinAsync(Models.ApartmentDetailInfoCheckinRequest request);
		Task<List<Models.GetSratedDetailResponse>> GetSratedDetailAsync(Models.GetSratedDetailRequest request);
	}
}
