using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompleteSignUpPage : ContentPage
    {
        CompleteSignUpPageViewModel viewModel;
        public CompleteSignUpPage(Models.ApartmentDetailInfoCheckinResponse apartment)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new CompleteSignUpPageViewModel(this.Navigation);
            viewModel.ApartmentDetailInfo = apartment;
        }
    }
}