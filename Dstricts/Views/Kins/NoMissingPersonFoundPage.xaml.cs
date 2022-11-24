using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Kins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoMissingPersonFoundPage : ContentPage
    {
        NoMissingPersonFoundPageViewModel viewModel;
        public NoMissingPersonFoundPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new NoMissingPersonFoundPageViewModel(this.Navigation);
            imgNoMissing.Source = ImageSource.FromUri(new System.Uri("https://www.qloudid.com/html/usercontent/images/bg/noMissing.png"));
        }
    }
}