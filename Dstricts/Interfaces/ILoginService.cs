using System.Threading.Tasks;

namespace Dstricts.Interfaces
{
	public interface ILoginService
	{
		Task<Models.LoginResponse> LoginAsync(Models.LoginRequest request);
	}
}
