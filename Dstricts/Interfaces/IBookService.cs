using System.Threading.Tasks;

namespace Dstricts.Interfaces
{
	public interface IBookService
	{
		Task<int> WellnessUpdateFollowingAsync(Models.WellnessUpdateFollowingRequest request);
		Task<int> WellnessSearchFollowingCountAsync(Models.WellnessSearchFollowingCountRequest request);
		Task<int> SelectedWellnessCategoriesandMenuAsync(Models.SelectedWellnessCategoriesandMenuRequest request);
	}
}
