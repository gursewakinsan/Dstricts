using Xamarin.Forms;
using Dstricts.ViewModels;
using Xamarin.Forms.Xaml;

namespace Dstricts.Views.Community
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommunityWifiPage : ContentPage
    {
        CommunityWifiPageViewModel viewModel;
        public CommunityWifiPage(string username,string password)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new CommunityWifiPageViewModel(this.Navigation);
            lblName.Text = username;
            lblPassword.Text = password;
        }
    }
}