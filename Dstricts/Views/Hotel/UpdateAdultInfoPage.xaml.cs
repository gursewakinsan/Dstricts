using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UpdateAdultInfoPage : ContentPage
	{
		UpdateAdultsInfoPageViewModel viewModel;
		public UpdateAdultInfoPage(Models.VerifyCheckedInCodeResponse verifyCheckedIn)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new UpdateAdultsInfoPageViewModel(this.Navigation);
			viewModel.VerifyCheckedInInfo = verifyCheckedIn;
			viewModel.AdultCount = verifyCheckedIn.GuestAdult;
		}
	}
}