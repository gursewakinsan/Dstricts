using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace Dstricts.Views.SosHelp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TravelAppCompanyPage : ContentPage
    {
        TravelAppCompanyPageViewModel viewModel;
        List<MapLocation> locations = new List<MapLocation>();
        public TravelAppCompanyPage(Models.TravelAppAvailableSosResponse travelApp)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new TravelAppCompanyPageViewModel(this.Navigation);
            viewModel.SelectedTravelAppAvailable = travelApp;
            //viewModel.TravelAppCompanyCommand.Execute(null);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.ExecuteTravelAppCompanyCommand();
            LoadMap();
        }

        private void LoadMap()
        {
            foreach (var companyLocations in viewModel.TravelAppCompanyLocationsList)
            {
                locations.Add(new MapLocation()
                {
                    LocationName = $"{companyLocations.StreetName} {companyLocations.PortNumber}",
                    LocationAddress = $"{companyLocations.PostalCode} {companyLocations.City}",
                    PositionPins = new Position(Convert.ToDouble(companyLocations.Latitude), Convert.ToDouble(companyLocations.Longitude))
                });
            }
            map.ItemsSource = locations;
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Helper.Helper.MyCurrentLocationLatitude, Helper.Helper.MyCurrentLocationLongitude), Distance.FromKilometers(100)));
        }

        private async void OnCompaniesItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.TravelAppCompanyLocationsResponse response = e.Item as Models.TravelAppCompanyLocationsResponse;
            listView.SelectedItem = null;
            await Navigation.PushAsync(new TravelAppCompanyDetailsPage(response, viewModel.SelectcedCompanyName));
        }

        private async void OnTravelAppCompanyClicked(object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            Models.TravelAppCompanyResponse travelApp = button.BindingContext as Models.TravelAppCompanyResponse;
            foreach (var item in viewModel.TravelAppCompanyList)
            {
                if (item.Id == travelApp.Id)
                {
                    viewModel.SelectcedCompanyName = travelApp.EmergencyName;
                    item.IsSelected = true;
                }
                else
                    item.IsSelected = false;
            }
            await viewModel.ExecuteTravelAppCompanyLocationsCommand(travelApp.Id);
            LoadMap();
        }
    }
}