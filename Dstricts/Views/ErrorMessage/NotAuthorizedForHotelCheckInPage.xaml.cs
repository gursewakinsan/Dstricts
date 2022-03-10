using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dstricts.Views.ErrorMessage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotAuthorizedForHotelCheckInPage : ContentPage
	{
		public NotAuthorizedForHotelCheckInPage ()
		{
			InitializeComponent ();
		}

		private void OnNotAuthorizedTapped(object sender, System.EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new Hotel.CheckedInListPage());
		}
	}
}