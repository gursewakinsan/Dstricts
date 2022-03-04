using System.Threading.Tasks;

namespace Dstricts.Interfaces
{
	public interface ILoginService
	{
		Task<Models.LoginResponse> LoginAsync(Models.LoginRequest request);
		Task<Models.InterAppSessionResponse> LoginWithSessionAsync(Models.InterAppSessionRequest request);
		Task<Models.UserDetailsDstrictsResponse> UserDetailsDstrictsAsync(Models.UserDetailsDstrictsRequest request);
	}
}
