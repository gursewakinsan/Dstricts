using Dstricts.Interfaces;
using Dstricts.Service;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
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
				MainPage = new NavigationPage(new Views.TestPage());
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
			if (Application.Current.Properties.ContainsKey("UserId"))
			{
				Helper.Helper.LoggedInUserId = Convert.ToInt32(Application.Current.Properties["UserId"]);
				Helper.Helper.LoggedInUserName = $"{Application.Current.Properties["UserName"]}";
			}

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
				else if (uri.Segments != null && uri.Segments.Length == 5)
				{
					string text = uri.Segments[3].Replace("/", "");
					if (text.Equals("verify_visitor"))
					{
						InvitedVisitorsMeetingListCommand.Execute(uri.Segments[4].Replace("/", ""));
					}
				}
			}
			else
				MainPage = new Views.LoginPage();
			base.OnAppLinkRequestReceived(uri);
		}
		#endregion

		#region Invited Visitors Meeting List Command.
		private ICommand invitedVisitorsMeetingListCommand;
		public ICommand InvitedVisitorsMeetingListCommand
		{
			get => invitedVisitorsMeetingListCommand ?? (invitedVisitorsMeetingListCommand = new Command<string>(async (locationId) => await ExecuteInvitedVisitorsMeetingListCommand(locationId)));
		}
		private async Task ExecuteInvitedVisitorsMeetingListCommand(string locationId)
		{
			DependencyService.Get<IProgressBar>().Show();
			IVisitorsService service = new VisitorsService();
			var response = await service.InvitedVisitorsMeetingListAsync(new Models.InvitedVisitorsMeetingListRequest()
			{
				LocationId = locationId,
				UserId = Helper.Helper.LoggedInUserId,
			});
			if (response?.Count > 0)
			{
				foreach (var visitors in response)
				{
					visitors.IsSelectedVisitors = false;
					visitors.VisitorsCardBorderColor = Color.FromHex("#363541");
					visitors.VisitorsNameTextOpacity = 0.4;
				}
				MainPage = new NavigationPage(new Views.Visitors.InvitedVisitorsMeetingListPage(response));
			}
			else
				MainPage = new NavigationPage(new Views.ErrorMessage.InvitedVisitorsMeetingListNotAvailablePage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion
	}
}
