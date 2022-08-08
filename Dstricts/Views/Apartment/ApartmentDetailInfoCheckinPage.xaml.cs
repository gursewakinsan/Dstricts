using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Apartment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApartmentDetailInfoCheckinPage : ContentPage
    {
        ApartmentDetailInfoCheckinPageViewModel viewModel;
        public ApartmentDetailInfoCheckinPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ApartmentDetailInfoCheckinPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ApartmentDetailInfoCheckinCommand.Execute(null);
        }
    }
}