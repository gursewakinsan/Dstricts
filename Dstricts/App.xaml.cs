using System;
using Xamarin.Forms;

namespace Dstricts
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			MainPage = new Views.SearchHotel.SearchHotelByTypePage();
		}

		#region Login With Session For iOS.
		public void LoginWithSession(string session)
		{
			if (!string.IsNullOrWhiteSpace(session))
				Helper.Helper.SessionId = session;
			MainPage = new Views.LoginPage();
		}
		#endregion

		#region Login With Session For Android.
		protected override void OnAppLinkRequestReceived(Uri uri)
		{
			if (uri.Host.EndsWith("DstrictsApp.com", StringComparison.OrdinalIgnoreCase))
			{
				if (uri.Segments != null && uri.Segments.Length == 3)
				{
					Helper.Helper.SessionId = uri.Segments[2];
					if (Helper.Helper.IsLoggedInUser)
						MainPage = new Views.Hotel.CheckedInListPage();
					else
						MainPage = new Views.LoginPage();
				}
			}
			else
				MainPage = new Views.LoginPage();
			base.OnAppLinkRequestReceived(uri);
		}
		#endregion
	}
}
