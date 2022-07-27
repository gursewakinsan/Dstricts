using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Apartment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateTicketPage : ContentPage
    {
        CreateTicketPageViewModel viewModel;
        public CreateTicketPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new CreateTicketPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.CreateTicketCommand.Execute(null);
        }
    }
}