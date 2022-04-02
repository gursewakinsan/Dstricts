using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
	public interface IVisitorsService
	{
		Task<List<Models.InvitedVisitorsMeetingListResponse>> InvitedVisitorsMeetingListAsync(Models.InvitedVisitorsMeetingListRequest request);
	}
}
