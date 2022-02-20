using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
	public interface IBookService
	{
		Task<int> WellnessUpdateFollowingAsync(Models.WellnessUpdateFollowingRequest request);
		Task<int> WellnessSearchFollowingCountAsync(Models.WellnessSearchFollowingCountRequest request);
		Task<List<Models.SelectedWellnessCategoriesAndMenuResponse>> SelectedWellnessCategoriesandMenuAsync(Models.SelectedWellnessCategoriesandMenuRequest request);
	}
}
