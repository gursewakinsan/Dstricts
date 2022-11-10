using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.SosHelp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SosHelpPage : ContentPage
    {
        SosHelpPageViewModel viewModel;
        public SosHelpPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new SosHelpPageViewModel(this.Navigation);
        }
    }
}