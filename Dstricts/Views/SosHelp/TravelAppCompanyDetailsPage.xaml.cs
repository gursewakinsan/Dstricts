using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

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
    }
}