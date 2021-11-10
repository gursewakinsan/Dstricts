using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;

namespace Dstricts.Views.Amenities
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AmenitiesServicePage : ContentPage
	{
		AmenitiesServicePageViewModel viewModel;
		public AmenitiesServicePage(int selectedGuestServicesId)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AmenitiesServicePageViewModel(this.Navigation);
			viewModel.SelectedGuestServicesId = selectedGuestServicesId;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GetAppAmenitiesCommand.Execute(null);
		}

		private void OnGuestServiceClicked(object sender, System.EventArgs e)
		{
			Button button = sender as Button;
			Models.GuestServices services = button.BindingContext as Models.GuestServices;
			viewModel.SelectedGuestServicesId = services.Id;
			viewModel.GetAppAmenitiesCommand.Execute(null);
		}

		private async void OnGridAmenityItemTapped(object sender, System.EventArgs e)
		{
			Grid grid = sender as Grid;
			Models.AmenitiesResponse selectedAmenities = grid.BindingContext as Models.AmenitiesResponse;
			selectedAmenities.CallBack = AmenitiesCallBack;
			await Navigation.PushPopupAsync(new PopupPages.AddAmenitiesItemToCartPopupPage(selectedAmenities));
		}

		private async void OnFrameAmenityItemTapped(object sender, System.EventArgs e)
		{
			Frame frame = sender as Frame;
			Models.AmenitiesResponse selectedAmenities = frame.BindingContext as Models.AmenitiesResponse;
			selectedAmenities.CallBack = AmenitiesCallBack;
			await Navigation.PushPopupAsync(new PopupPages.AddAmenitiesItemToCartPopupPage(selectedAmenities));
		}

		private void AmenitiesCallBack()
		{
			var service = viewModel.AmenitiesList.FirstOrDefault(x => x.Quantity != 0);
			if (service == null)
				viewModel.IsCheckOut = false;
			else
				viewModel.IsCheckOut = true;
		}
	}
}