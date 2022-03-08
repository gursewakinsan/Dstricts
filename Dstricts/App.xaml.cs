using System;
using Xamarin.Forms;

namespace Dstricts
{
	public partial class App : Application
	{
		public static int ScreenHeight { get; set; }
		public static int ScreenWidth { get; set; }
		public App()
		{
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTIzNzQzQDMxMzkyZTMzMmUzMFBIaTRVTHZ6RSt5ZFl4ZzFkTkhHSWcwTGFnQ0JkUjg4TEJNcnVhSUVZeUE9");
			InitializeComponent();
			/*if (Application.Current.Properties.ContainsKey("UserId"))
			{
				Helper.Helper.LoggedInUserId = Convert.ToInt32(Application.Current.Properties["UserId"]);
				Helper.Helper.LoggedInUserName = $"{Application.Current.Properties["UserName"]}";
				MainPage = new NavigationPage(new Views.Hotel.CheckedInListPage());
			}
			else*/
			MainPage = new NavigationPage(new Views.Hotel.InviteAdultsPage());

		}

		#region Login With Session For iOS.
		public void LoginWithSession(string session)
		{
			if (!string.IsNullOrWhiteSpace(session))
				Helper.Helper.SessionId = session;
			if (Application.Current.Properties.ContainsKey("UserId"))
			{
				Helper.Helper.LoggedInUserId = Convert.ToInt32(Application.Current.Properties["UserId"]);
				Helper.Helper.LoggedInUserName = $"{Application.Current.Properties["UserName"]}";
				MainPage = new NavigationPage(new Views.Hotel.CheckedInListPage());
			}
			else
				MainPage = new Views.LoginPage();
			//MainPage = new Views.LoginPage();
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
					//if (Helper.Helper.IsLoggedInUser)
					//MainPage = new Views.Hotel.CheckedInListPage();
					if (Application.Current.Properties.ContainsKey("UserId"))
					{
						Helper.Helper.LoggedInUserId = Convert.ToInt32(Application.Current.Properties["UserId"]);
						Helper.Helper.LoggedInUserName = $"{Application.Current.Properties["UserName"]}";
						MainPage = new NavigationPage(new Views.Hotel.CheckedInListPage());
					}
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
