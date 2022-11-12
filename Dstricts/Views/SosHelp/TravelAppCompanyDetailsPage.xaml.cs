using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.SosHelp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TravelAppCompanyDetailsPage : ContentPage
    {
        TravelAppCompanyDetailsPageViewModel viewModel;
        public TravelAppCompanyDetailsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new TravelAppCompanyDetailsPageViewModel(this.Navigation);
        }
    }
}