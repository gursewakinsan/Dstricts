using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
	public interface ISearchService
	{
		Task<List<Models.SearchUserResponse>> SearchUserAsync(Models.SearchRequest request);
		Task<List<Models.SearchCompanyResponse>> SearchCompanyAsync(Models.SearchRequest request);
		Task<List<Models.SearchResturantResponse>> SearchResturantAsync(Models.SearchRequest request);
		Task<List<Models.SearchWellnessResponse>> SearchWellnessAsync(Models.SearchWellnessRequest request);
	}
}
