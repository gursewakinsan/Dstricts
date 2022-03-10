using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dstricts.Views.ErrorMessage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlreadyCheckedInForHotelPage : ContentPage
	{
		public AlreadyCheckedInForHotelPage ()
		{
			InitializeComponent ();
		}

		private void OnNotAuthorizedTapped(object sender, System.EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new Hotel.CheckedInListPage());
		}
	}
}