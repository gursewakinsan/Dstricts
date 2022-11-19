using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Kins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KinsAddressPage : ContentPage
    {
        KinsAddressPageViewModel viewModel;
        public KinsAddressPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new KinsAddressPageViewModel(this.Navigation);
        }
    }
}