using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Kins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KinsWearingPage : ContentPage
    {
        KinsWearingPageViewModel viewModel;
        public KinsWearingPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new KinsWearingPageViewModel(this.Navigation);
        }
    }
}