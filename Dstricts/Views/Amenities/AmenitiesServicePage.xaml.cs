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

		private void OnGridAmenityItemTapped(object sender, System.EventArgs e)
		{

		}

		private void OnFrameAmenityItemTapped(object sender, System.EventArgs e)
		{

		}
	}
}