using Xamarin.Forms;
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
    }
}