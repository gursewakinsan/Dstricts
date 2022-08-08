using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dstricts.Views.ErrorMessage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotOwnerOfPropertyPage : ContentPage
    {
        public NotOwnerOfPropertyPage()
        {
            InitializeComponent();
        }

        private void OnNotAuthorizedTapped(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Hotel.CheckedInListPage());
        }
    }
}