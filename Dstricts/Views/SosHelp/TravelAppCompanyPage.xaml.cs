using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.SosHelp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TravelAppCompanyPage : ContentPage
    {
        TravelAppCompanyPageViewModel viewModel;
        public TravelAppCompanyPage(Models.TravelAppAvailableSosResponse travelApp)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new TravelAppCompanyPageViewModel(this.Navigation);
            viewModel.SelectedTravelAppAvailable = travelApp;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.TravelAppCompanyCommand.Execute(null);
        }

        private async void OnCompaniesItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.TravelAppCompanyLocationsResponse response = e.Item as Models.TravelAppCompanyLocationsResponse;
            listView.SelectedItem = null;
            await Navigation.PushAsync(new TravelAppCompanyDetailsPage(response, viewModel.SelectcedCompanyName));
        }

        private void OnTravelAppCompanyClicked(object sender, System.EventArgs e)
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
            viewModel.TravelAppCompanyLocationsCommand.Execute(travelApp.Id);
        }
    }
}