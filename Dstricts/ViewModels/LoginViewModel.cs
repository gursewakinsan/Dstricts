using Xamarin.Forms;
using Xamarin.Essentials;
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

		#region Login With QloudId App Command.
		private ICommand loginWithQloudIdAppCommand;
		public ICommand LoginWithQloudIdAppCommand
		{
			get => loginWithQloudIdAppCommand ?? (loginWithQloudIdAppCommand = new Command(async () => await ExecuteLoginWithQloudIdAppCommand()));
		}
		private async Task ExecuteLoginWithQloudIdAppCommand()
		{
			if (Device.RuntimePlatform == Device.iOS)
			{
				//var supportsUri = await Launcher.CanOpenAsync("QloudidUrl://");
				//if (supportsUri)
				await Launcher.OpenAsync("QloudidUrl://NoffaPlusApp");
				//else
				//await Alert.DisplayAlert("QloudID app not install on your mobile phone.");
			}
			else
			{
				var supportsUri = await Launcher.CanOpenAsync("https://qloudid.com/ip/");
				if (supportsUri)
					await Launcher.OpenAsync("https://qloudid.com/ip/");
				//else
					//await Alert.DisplayAlert("QloudID app not install on your mobile phone.");
			}
			await Task.CompletedTask;
		}
		#endregion
	}
}
