using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		LoginViewModel loginViewModel;
        public LoginPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = loginViewModel = new LoginViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			Helper.Helper.SessionId = "bVJzMUkvRWhON3dnR2hTMEdwbGhBZz09"; //"eGE1c0Q2S1BrSU9naUJwWFJlemZPa0lBdGNEV25Tem91a0Jmdm1HeXQvRT0=";
            Helper.Helper.DeviceWidth = Application.Current.MainPage.Width;
			if (!string.IsNullOrWhiteSpace(Helper.Helper.SessionId))
				loginViewModel.LoginWithSessionCommand.Execute(null);
			base.OnAppearing();
		}
	}
}