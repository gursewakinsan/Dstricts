using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Community
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedAmenityDetailPage : ContentPage
    {
        SelectedAmenityDetailPageViewModel viewModel;
        public SelectedAmenityDetailPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new SelectedAmenityDetailPageViewModel(this.Navigation);
        }
    }
}