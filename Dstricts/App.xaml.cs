using Dstricts.Interfaces;
using Dstricts.Service;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Dstricts
{
	public partial class App : Application
	{
		public static int ScreenHeight { get; set; }
		public static int ScreenWidth { get; set; }
		public int HotelPropertyType { get; set; }
		public string VerifyCheckinId { get; set; } = string.Empty;
		public App()
		{
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTIzNzQzQDMxMzkyZTMzMmUzMFBIaTRVTHZ6RSt5ZFl4ZzFkTkhHSWcwTGFnQ0JkUjg4TEJNcnVhSUVZeUE9");
			InitializeComponent();
			if (Application.Current.Properties.ContainsKey("UserId"))
			{
				Helper.Helper.LoggedInUserId = Convert.ToInt32(Application.Current.Properties["UserId"]);
				Helper.Helper.LoggedInUserName = $"{Application.Current.Properties["UserName"]}";
				MainPage = new NavigationPage(new Views.Hotel.CheckedInListPage());
			}
			else
				MainPage = new NavigationPage(new Views.LoginPage()); 
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

		#region Login With Session For iOS.
		public void CheckInFunctionality(string info)
		{
			VerifyQrCodeCommand.Execute(info.Remove(0, 2));
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
					//Go To Appartment Check-in
					if (uri.Segments[1].Equals("verify_checkin/"))
					{
						VerifyQrCodeCommand.Execute(uri.AbsolutePath.Remove(0, 1));
					}
					else
					{
						Helper.Helper.SessionId = uri.Segments[2];
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
				else if (uri.Segments != null && uri.Segments.Length == 4)
				{
					VerifyQrCodeCommand.Execute(uri.AbsolutePath.Remove(0, 1));
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

		#region Verify QR Code Command.
		private ICommand verifyQrCodeCommand;
		public ICommand VerifyQrCodeCommand
		{
			get => verifyQrCodeCommand ?? (verifyQrCodeCommand = new Command<string>(async (qrCode) => await ExecuteVerifyQrCodeCommand(qrCode)));
		}
		private async Task ExecuteVerifyQrCodeCommand(string qrCode)
		{
			VerifyCheckinId = string.Empty;
			string[] codeInfo = qrCode.Split('/');
			switch (codeInfo[0])
			{
				case "verify_checkin":
					HotelPropertyType = Convert.ToInt32(codeInfo[1]);
					if (codeInfo.Length == 3)
					{
						VerifyCheckinId = codeInfo[2];
						VerifyBookingCheckinCommand.Execute(codeInfo[2]);
					}
					else
						GoToVerifyCheckedInCodePageCommand.Execute(null);
					break;
				case "getQueue":
					Helper.Helper.AvalibleQueueId = codeInfo[1];
					MainPage = new NavigationPage(new Views.Queue.AvalibleQueueOnTheLocationPage());
					break;
				case "verify_adult_checkin":
					VerifyUserInvitationInfoCommand.Execute(codeInfo[2]);
					break;
				case "verify_visitor":
					InvitedVisitorsMeetingListCommand.Execute(codeInfo[2]);
					break;
			}
			await Task.CompletedTask;
		}
		#endregion

		#region Verify Booking Checkin Command.
		private ICommand verifyBookingCheckinCommand;
		public ICommand VerifyBookingCheckinCommand
		{
			get => verifyBookingCheckinCommand ?? (verifyBookingCheckinCommand = new Command<string>(async (id) => await ExecuteVerifyBookingCheckinCommand(id)));
		}
		private async Task ExecuteVerifyBookingCheckinCommand(string id)
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			var response = await service.VerifyBookingCheckinAsync(new Models.VerifyBookingCheckinRequest()
			{
				Id = id,
				DstrictsUserId = Helper.Helper.LoggedInUserId
			});
			if (response == 0)
				MainPage = new NavigationPage(new Views.ErrorMessage.BookingNotAvailablePage());
			else if (response == 1)
				GoToVerifyCheckedInCodePageCommand.Execute(null);
			else if (response == 2)
				MainPage = new NavigationPage(new Views.ErrorMessage.FrontDeskPage());
			else if (response == 3)
				MainPage = new NavigationPage(new Views.ErrorMessage.AlreadyCheckedInForHotelPage());
			else if (response == 4)
			{
				//Missing some info go to qloudid app.
				if (Device.RuntimePlatform == Device.iOS)
					await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/ShowMissingPreCheckInInfoPage/{id}");
				else
					await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/ShowMissingPreCheckInInfoPage/{id}");
			}
			//In verify_checkin array 3 hai to api call krni hai
			//TODO https://dstricts.com/user/index.php/DstrictsApp/verifyBookingCheckin
			//id,jo 3 arrary ki value hai and  dstricts_user_id
			//after call api if return 0 then navigate to booking not avilable
			// if 1 then current flow same as
			// if 3 then naviagte to already checked in page
			//if 2 then new page "Front desk"
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Go To Verify Checked In Code Page Command.
		private ICommand goToVerifyCheckedInCodePageCommand;
		public ICommand GoToVerifyCheckedInCodePageCommand
		{
			get => goToVerifyCheckedInCodePageCommand ?? (goToVerifyCheckedInCodePageCommand = new Command( () =>  ExecuteGoToVerifyCheckedInCodePageCommand()));
		}
		private void ExecuteGoToVerifyCheckedInCodePageCommand()
		{
			MainPage = new NavigationPage(new Views.Hotel.VerifyCheckedInPage(HotelPropertyType, VerifyCheckinId));
		}
		#endregion

		#region Verify User Invitation Info Command.
		private ICommand verifyUserInvitationInfoCommand;
		public ICommand VerifyUserInvitationInfoCommand
		{
			get => verifyUserInvitationInfoCommand ?? (verifyUserInvitationInfoCommand = new Command<string>(async (id) => await ExecuteVerifyUserInvitationInfoCommand(id)));
		}
		private async Task ExecuteVerifyUserInvitationInfoCommand(string id)
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService hotelService = new HotelService();
			int code = await hotelService.VerifyUserInvitationInfoAsync(new Models.VerifyUserInvitationInfoRequest()
			{
				Id = id,
				UserId = Helper.Helper.LoggedInUserId
			});
			if (code == 0) //Not authorized page
				Application.Current.MainPage = new NavigationPage(new Views.ErrorMessage.NotAuthorizedForHotelCheckInPage());
			else if (code == 1) // Already checked-in page
				Application.Current.MainPage = new NavigationPage(new Views.ErrorMessage.AlreadyCheckedInForHotelPage());
			else if (code == 2) // Wrong date page
				Application.Current.MainPage = new NavigationPage(new Views.ErrorMessage.WrongDateForHotelCheckInPage());
			else if (code == 4)
			{
				//Missing some info go to qloudid app.
				if (Device.RuntimePlatform == Device.iOS)
					await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/ShowMissingPreCheckInInfoPage/{id}");
				else
					await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/ShowMissingPreCheckInInfoPage/{id}");
			}
			else
			{
				Helper.Helper.VerifyUserInvitationInfoId = id;
				MainPage = new NavigationPage(new Views.Hotel.VerifyUserInvitationInfoCodePage(code));
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion
	}
}
