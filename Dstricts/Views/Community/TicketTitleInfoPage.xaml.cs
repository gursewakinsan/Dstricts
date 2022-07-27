using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Community
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketTitleInfoPage : ContentPage
    {
        TicketTitleInfoPageViewModel viewModel;
        public TicketTitleInfoPage(string ticketType)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new TicketTitleInfoPageViewModel(this.Navigation);
            if (ticketType == "1") lblTitle.Text = "Apartment";
            else lblTitle.Text = "Community";
            viewModel.TicketType = ticketType;
            viewModel.GetTicketTitleInfoCommand.Execute(null);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}