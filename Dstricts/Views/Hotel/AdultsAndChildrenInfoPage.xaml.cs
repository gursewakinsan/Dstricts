using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdultsAndChildrenInfoPage : ContentPage
	{
		AdultsAndChildrenInfoPageViewModel viewModel;
		public AdultsAndChildrenInfoPage(Models.VerifyCheckedInCodeResponse verifyCheckedIn)
		{
			InitializeComponent();
			BindingContext = viewModel = new AdultsAndChildrenInfoPageViewModel(this.Navigation);
			viewModel.VerifyCheckedInInfo = verifyCheckedIn;
			if (verifyCheckedIn.GuestChildren == 0)
				lblChildren.IsVisible = false;
			else
				lblChildren.IsVisible = true;
			viewModel.TotalCount = verifyCheckedIn.GuestAdult + verifyCheckedIn.GuestChildren;
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			BindableLayout.SetItemsSource(layoutInviteAdults, new string[viewModel.VerifyCheckedInInfo.GuestAdult - 1]);
			BindableLayout.SetItemsSource(layoutAddChild, new string[viewModel.VerifyCheckedInInfo.GuestChildren]);
		}
	}
}