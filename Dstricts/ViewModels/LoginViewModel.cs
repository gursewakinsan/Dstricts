using Xamarin.Forms;
using Dstricts.Helper;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		#region Constructor.
		public LoginViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Login With Session Command.
		private ICommand loginWithSessionCommand;
		public ICommand LoginWithSessionCommand
		{
			get => loginWithSessionCommand ?? (loginWithSessionCommand = new Command(async () => await ExecuteLoginWithSessionCommand()));
		}
		private async Task ExecuteLoginWithSessionCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ILoginService service = new LoginService();
			Models.InterAppSessionResponse response = await service.LoginWithSessionAsync(new Models.InterAppSessionRequest()
			{
				Session = Helper.Helper.SessionId
			});
			if (response == null)
				await Alert.DisplayAlert("Something went wrong, Please try after some time.");
			else if (response.Result == 0)
				await Alert.DisplayAlert("You have enter wrong password, Please try again.");
			else if (response.Result == 1)
			{
				Helper.Helper.LoggedInUserId = response.UserId;
				Application.Current.MainPage = new NavigationPage(new Views.SuccessfullyLoggedInPage(response.UserName));
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Login With QloudId App Command.
		private ICommand loginWithQloudIdAppCommand;
		public ICommand LoginWithQloudIdAppCommand
		{
			get => loginWithQloudIdAppCommand ?? (loginWithQloudIdAppCommand = new Command(async () => await ExecuteLoginWithQloudIdAppCommand()));
		}
		private async Task ExecuteLoginWithQloudIdAppCommand()
		{
			if (Device.RuntimePlatform == Device.iOS)
				await Launcher.OpenAsync("QloudidUrl://DstrictsApp");
			else
			{
				//var supportsUri = await Launcher.CanOpenAsync("https://qloudid.com/ip/");
				//if (supportsUri)
					await Launcher.OpenAsync("https://qloudid.com/ip/DstrictsApp");
				//else
				//	await Alert.DisplayAlert("QloudID app not install on your mobile phone.");
			}
			await Task.CompletedTask;
		}
		#endregion
	}
}
