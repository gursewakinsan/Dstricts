using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dstricts.Views.ErrorMessage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookingNotAvailablePage : ContentPage
	{
		public BookingNotAvailablePage ()
		{
			InitializeComponent ();
		}

		private void OnNotAvailableTapped(object sender, EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new Hotel.CheckedInListPage());
		}
	}
}