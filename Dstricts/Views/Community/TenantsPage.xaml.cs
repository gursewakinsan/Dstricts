using System.Linq;
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

        private void OnPortClicked(object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            var response = button.BindingContext as Models.CommunityAvailableTenantsInfoResponse;
            if (!response.IsSelected)
            {
                var tenant = viewModel.TenantInfo.FirstOrDefault(x => x.IsSelected == true);
                if (tenant != null)
                {
                    tenant.IsSelected = false;
                    tenant.PortNumberTextColor = Color.White;
                    tenant.PortNumberBg = Color.Transparent;
                    tenant.PortNumberBorder = Color.FromHex("#737B8C");
                }
                response.IsSelected = true;
                response.PortNumberTextColor = Color.Black;
                response.PortNumberBg = Color.White;
                response.PortNumberBorder = Color.White;
                viewModel.CopySelectedTenantInfo = response.TenantsList;
                viewModel.SelectedTenantInfo = new System.Collections.ObjectModel.ObservableCollection<Models.Tenant>(response.TenantsList);
            }
        }
    }
}