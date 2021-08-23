using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerifyCheckedInPage : ContentPage
	{
		VerifyCheckedInPageViewModel loginViewModel;
		public VerifyCheckedInPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = loginViewModel = new VerifyCheckedInPageViewModel(this.Navigation);
		}
	}
}