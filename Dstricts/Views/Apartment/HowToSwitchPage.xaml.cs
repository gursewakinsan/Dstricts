using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Apartment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HowToSwitchPage : ContentPage
    {
        HowToSwitchPageViewModel viewModel;
        public HowToSwitchPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new HowToSwitchPageViewModel(this.Navigation);
        }
    }
}