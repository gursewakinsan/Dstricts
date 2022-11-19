using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Kins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KinsLostOrFoundPage : ContentPage
    {
        KinsLostOrFoundPageViewModel viewModel;
        public KinsLostOrFoundPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new KinsLostOrFoundPageViewModel(this.Navigation);
        }
    }
}