using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Kins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KinsTimeAndDurationPage : ContentPage
    {
        KinsTimeAndDurationPageViewModel viewModel;
        public KinsTimeAndDurationPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new KinsTimeAndDurationPageViewModel(this.Navigation);
        }
    }
}