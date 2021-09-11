using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
	public interface IQueueService
	{
		Task<List<Models.AvalibleQueueOnTheLocationResponse>> GetAvalibleQueueOnTheLocationAsync(Models.AvalibleQueueOnTheLocationRequest request);
	}
}
