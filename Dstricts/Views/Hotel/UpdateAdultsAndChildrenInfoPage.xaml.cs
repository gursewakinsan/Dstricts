using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UpdateAdultsAndChildrenInfoPage : ContentPage
	{
		UpdateAdultsAndChildrenInfoPageViewModel viewModel;
		public UpdateAdultsAndChildrenInfoPage (Models.VerifyCheckedInCodeResponse verifyCheckedIn)
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new UpdateAdultsAndChildrenInfoPageViewModel(this.Navigation);
			viewModel.VerifyCheckedInInfo = verifyCheckedIn;
			viewModel.AdultesCount = verifyCheckedIn.GuestAdult;
			viewModel.ChildrenCount = verifyCheckedIn.GuestChildren;
			viewModel.TotalCount = verifyCheckedIn.GuestAdult + verifyCheckedIn.GuestChildren;
		}
	}
}