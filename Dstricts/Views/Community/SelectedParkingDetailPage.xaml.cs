using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;

namespace Dstricts.Views.Community
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedParkingDetailPage : ContentPage
    {
        SelectedParkingDetailPageViewModel viewModel;
        public SelectedParkingDetailPage(List<Models.ApartmentCommunityParkingsResponse> parkings)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new SelectedParkingDetailPageViewModel(this.Navigation);
            viewModel.ApartmentCommunityParkings = parkings;
            viewModel.SelectedApartmentCommunityParking = parkings.FirstOrDefault(x => x.IsSelected);
            viewModel.BuildingId = viewModel.SelectedApartmentCommunityParking.Id;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.BuildingSelectedParkingInfoCommand.Execute(null);
        }

        private void OnParkingsListButtonClicked(object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            Models.ApartmentCommunityParkingsResponse selectedParkings = button.BindingContext as Models.ApartmentCommunityParkingsResponse;
            if (!viewModel.BuildingId.Equals(selectedParkings.Id))
            {
                foreach (var amenity in viewModel.ApartmentCommunityParkings)
                {
                    if (amenity.Id.Equals(selectedParkings.Id))
                        amenity.IsSelected = true;
                    else
                        amenity.IsSelected = false;
                }
                viewModel.BuildingId = selectedParkings.Id;
                viewModel.BuildingSelectedParkingInfoCommand.Execute(null);
            }
        }
    }
}