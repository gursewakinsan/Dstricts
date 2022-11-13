using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using Xamarin.Forms.Maps;

namespace Dstricts.Views.SosHelp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TravelAppCompanyDetailsPage : ContentPage
    {
        TravelAppCompanyDetailsPageViewModel viewModel;
        public TravelAppCompanyDetailsPage(Models.TravelAppCompanyLocationsResponse travelAppLocation, string selectcedCompanyName)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new TravelAppCompanyDetailsPageViewModel(this.Navigation);
            viewModel.SelectedTravelAppCompanyLocations = travelAppLocation;
            viewModel.SelectedCompanyName = selectcedCompanyName;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadMap();
        }

        void LoadMap()
        {
            Polyline polyline = new Polyline
            {
                StrokeColor = Color.Blue,
                StrokeWidth = 12,
                Geopath =
                {
                    new Position(Convert.ToDouble(viewModel.SelectedTravelAppCompanyLocations.Latitude),Convert.ToDouble(viewModel.SelectedTravelAppCompanyLocations.Longitude)),
                    new Position(Helper.Helper.MyCurrentLocationLatitude,Helper.Helper.MyCurrentLocationLongitude)
                }
            };
            map.MapElements.Add(polyline);
        }
    }
}