using Xamarin.Forms;
using Dstricts.Controls;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Community
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketSubTitleInfoPage : ContentPage
    {
        TicketSubTitleInfoPageViewModel viewModel;
        public TicketSubTitleInfoPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new TicketSubTitleInfoPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.GetTicketSubTitleInfoCommand.Execute(null);
        }
    }
}