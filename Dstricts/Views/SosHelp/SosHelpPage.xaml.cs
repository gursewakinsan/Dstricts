using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.SosHelp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SosHelpPage : ContentPage
    {
        SosHelpPageViewModel viewModel;
        public SosHelpPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new SosHelpPageViewModel(this.Navigation);
            img1.Source = ImageSource.FromUri(new System.Uri("https://www.qloudid.com/html/usercontent/images/bg-images/sos3.png"));
            img2.Source = ImageSource.FromUri(new System.Uri("https://www.qloudid.com/html/usercontent/images/bg-images/sos4.png"));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.TravelAppAvailableSosCommand.Execute(null);
        }

        private async void OnTravelAppAvailableSosItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            Models.TravelAppAvailableSosResponse travelApp = e.ItemData as Models.TravelAppAvailableSosResponse;
            listView.SelectedItem = null;
            await Navigation.PushAsync(new TravelAppCompanyPage(travelApp));
        }
    }
}