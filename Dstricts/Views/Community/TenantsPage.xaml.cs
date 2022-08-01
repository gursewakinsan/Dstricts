using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Community
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TenantsPage : ContentPage
    {
        TenantsPageViewModel viewModel;
        public TenantsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new TenantsPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.CommunityAvailableTenantsInfoCommand.Execute(null);
        }
    }
}