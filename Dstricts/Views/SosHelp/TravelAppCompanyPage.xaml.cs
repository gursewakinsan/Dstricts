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

        private void OnCompaniesItemTapped(object sender, ItemTappedEventArgs e)
        {
            listView.SelectedItem = null;
        }
    }
}