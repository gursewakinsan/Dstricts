using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdultsAndChildrenInfoPage : ContentPage
	{
		AdultsAndChildrenInfoPageViewModel viewModel;
		int guestChildren = 0;
		int guestAdult = 0;
		public AdultsAndChildrenInfoPage(int _guestChildren, int _guestAdult)
		{
			guestChildren = _guestChildren;
			guestAdult = _guestAdult;
			InitializeComponent();
			BindingContext = viewModel = new AdultsAndChildrenInfoPageViewModel(this.Navigation);
			if (guestChildren == 0)
				viewModel.IsGuestChildren = false;
			else
				viewModel.IsGuestChildren = true;
			viewModel.TotalCount = guestChildren + guestAdult;
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			BindableLayout.SetItemsSource(layoutInviteAdults, new string[guestAdult - 1]);
			BindableLayout.SetItemsSource(layoutAddChild, new string[guestChildren]);
			viewModel.DependentsCheckedInListCommand.Execute(null);
		}

		private async void OnAdultsTapped(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new InviteAdultsPage());
		}

		private async void OnChildrenTapped(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new DependentsListForCheckinPage());
		}
	}
}