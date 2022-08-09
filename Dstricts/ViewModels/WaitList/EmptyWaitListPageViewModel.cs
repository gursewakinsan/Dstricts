using System;
using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class EmptyWaitListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public EmptyWaitListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
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
					Helper.Helper.HotelPropertyType = HotelPropertyType;
					if (codeInfo.Length == 3)
					{
						if (codeInfo[1] == "1")
							GoToVerifyCheckedInCodePageCommand.Execute(null);
						else
						{
							VerifyCheckinId = codeInfo[2];
							//VerifyBookingCheckinCommand.Execute(codeInfo[2]);
							Helper.Helper.VerifyCheckinId = VerifyCheckinId;
							await Navigation.PushAsync(new Views.Apartment.ApartmentDetailInfoCheckinPage());
						}
					}
					break;
				case "getQueue":
					Helper.Helper.AvalibleQueueId = codeInfo[1];
					await Navigation.PushAsync(new Views.Queue.AvalibleQueueOnTheLocationPage());
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
				await Navigation.PushAsync(new Views.ErrorMessage.BookingNotAvailablePage());
			else if (response == 1)
				GoToVerifyCheckedInCodePageCommand.Execute(null);
			else if (response == 2)
				await Navigation.PushAsync(new Views.ErrorMessage.FrontDeskPage());
			else if (response == 3)
				await Navigation.PushAsync(new Views.ErrorMessage.AlreadyCheckedInForHotelPage());
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
			get => goToVerifyCheckedInCodePageCommand ?? (goToVerifyCheckedInCodePageCommand = new Command(async () => await ExecuteGoToVerifyCheckedInCodePageCommand()));
		}
		private async Task ExecuteGoToVerifyCheckedInCodePageCommand()
		{
			await Navigation.PushAsync(new Views.Hotel.VerifyCheckedInPage(HotelPropertyType, VerifyCheckinId));
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
				await Navigation.PushAsync(new Views.Hotel.VerifyUserInvitationInfoCodePage(code));
			}
			DependencyService.Get<IProgressBar>().Hide();
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
				await Navigation.PushAsync(new Views.Visitors.InvitedVisitorsMeetingListPage(response));
			}
			else
				await Navigation.PushAsync(new Views.ErrorMessage.InvitedVisitorsMeetingListNotAvailablePage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Socail Click Command .
		private ICommand socailClickCommand;
		public ICommand SocailClickCommand
		{
			get => socailClickCommand ?? (socailClickCommand = new Command(() => ExecuteSocailClickCommand()));
		}
		private void ExecuteSocailClickCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Hotel.CheckedInListPage());
		}
		#endregion

		#region Go To Check In Command.
		private ICommand goToCheckInCommand;
		public ICommand GoToCheckInCommand
		{
			get => goToCheckInCommand ?? (goToCheckInCommand = new Command(() => ExecuteGoToCheckInCommand()));
		}
		private void ExecuteGoToCheckInCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Hotel.CheckInPage());
		}
		#endregion

		#region Properties.
		private List<Models.CheckedInResponse> checkInList;
		public List<Models.CheckedInResponse> CheckInList
		{
			get => checkInList;
			set
			{
				checkInList = value;
				OnPropertyChanged("CheckInList");
			}
		}

		private List<Models.CheckedInMeetingListResponse> checkedInMeetingList;
		public List<Models.CheckedInMeetingListResponse> CheckedInMeetingList
		{
			get => checkedInMeetingList;
			set
			{
				checkedInMeetingList = value;
				OnPropertyChanged("CheckedInMeetingList");
			}
		}

		private bool isListOneRecord;
		public bool IsListOneRecord
		{
			get => isListOneRecord;
			set
			{
				isListOneRecord = value;
				OnPropertyChanged("IsListOneRecord");
			}
		}

		public int HotelPropertyType { get; set; }
		public string VerifyCheckinId { get; set; } = string.Empty;
		#endregion
	}
}
