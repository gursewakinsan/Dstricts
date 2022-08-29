using Xamarin.Forms;
using Dstricts.ViewModels;
using Xamarin.Forms.Xaml;

namespace Dstricts.Views.Apartment
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HouseWifiPage : ContentPage
	{
		HouseWifiPageViewModel viewModel;
		public HouseWifiPage (string username, string password)
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new HouseWifiPageViewModel(this.Navigation);
			lblName.Text = username;
			lblPassword.Text = password;
		}
	}
}