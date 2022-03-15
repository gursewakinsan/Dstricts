using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dstricts.Views.ErrorMessage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WrongDateForHotelCheckInPage : ContentPage
	{
		public WrongDateForHotelCheckInPage ()
		{
			InitializeComponent ();
		}

		private void OnNotAuthorizedTapped(object sender, EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new Hotel.CheckedInListPage());
		}
	}
}