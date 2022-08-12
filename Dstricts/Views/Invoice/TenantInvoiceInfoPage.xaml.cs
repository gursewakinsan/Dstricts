using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Invoice
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TenantInvoiceInfoPage : ContentPage
    {
        TenantInvoiceInfoPageViewModel viewModel;
        public TenantInvoiceInfoPage(int buildingId, string propertyNickName)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new TenantInvoiceInfoPageViewModel(this.Navigation);
            viewModel.BuildingId = buildingId;
            lblHeader.Text = propertyNickName;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.TenantInvoiceInfoCommand.Execute(null);
        }
    }
}