using System;
using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace Dstricts.ViewModels
{
	public class CheckInPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CheckInPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Social Command.
		private ICommand socialCommand;
		public ICommand SocialCommand
		{
			get => socialCommand ?? (socialCommand = new Command(() => ExecuteGoToCheckInCommand()));
		}
		private void ExecuteGoToCheckInCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Hotel.CheckedInListPage());
		}
		#endregion

		#region Get Check In Command.
		private ICommand getCheckInCommand;
		public ICommand GetCheckInCommand
		{
			get => getCheckInCommand ?? (getCheckInCommand = new Command(async () => await ExecuteGetCheckInCommand()));
		}
		private async Task ExecuteGetCheckInCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			List<Models.CheckedInResponse> checkIns = new List<Models.CheckedInResponse>();
			var responseCheckedIn = await service.CheckedInHotelAsync(new Models.CheckedInRequest()
			{
				UserId = Helper.Helper.LoggedInUserId
			});

			/*responseCheckedIn.Add(new Models.CheckedInResponse() { PropertyNickName = "Hotel 1" });
			responseCheckedIn.Add(new Models.CheckedInResponse() { PropertyNickName = "Hotel 2" });
			responseCheckedIn.Add(new Models.CheckedInResponse() { PropertyNickName = "Hotel 3" });*/

			var responseCheckedInApartment = await service.CheckedInApartmentAsync(new Models.CheckedInRequest()
			{
				UserId = Helper.Helper.LoggedInUserId
			});

			/*var responseCheckedInMeetingList = await service.CheckedInMeetingListAsync(new Models.CheckedInMeetingListRequest()
			{
				UserId = Helper.Helper.LoggedInUserId
			});*/

			/*responseCheckedInMeetingList.Add(new Models.CheckedInMeetingListResponse() { Name = "Name 1", CompanyName = "CompanyName 1" });
			responseCheckedInMeetingList.Add(new Models.CheckedInMeetingListResponse() { Name = "Name 2", CompanyName = "CompanyName 2" });
			responseCheckedInMeetingList.Add(new Models.CheckedInMeetingListResponse() { Name = "Name 3", CompanyName = "CompanyName 3" });
			responseCheckedInMeetingList.Add(new Models.CheckedInMeetingListResponse() { Name = "Name 4", CompanyName = "CompanyName 4" });*/
			
			//CheckedInMeetingList = responseCheckedInMeetingList;

			if (responseCheckedIn?.Count > 0)
			{
				foreach (var item in responseCheckedIn)
					if (item != null)
						checkIns.Add(item);
			}

			if (responseCheckedInApartment?.Count > 0)
			{
				foreach (var item in responseCheckedInApartment)
					if (item != null)
						checkIns.Add(item);
			}

			/*if (checkIns?.Count > 1)
			{
				int index = 0;
				foreach (var item in checkIns)
				{
					item.FirstLetterBg = Helper.Helper.ListIconBgColorList[index];
					item.FirstLetterText = Helper.Helper.ListIconTextColorList[index];
					index = index + 1;
				}
			}*/

			int deviceWidth = App.ScreenWidth - 56;
			int imgWidth = deviceWidth * 80 / 100;

			if (checkIns?.Count > 1)
			{
				foreach (var item in checkIns)
					item.ImgWidth = imgWidth;
				IsListOneRecord = true;
			}
			else if (checkIns?.Count == 1)
				IsListOneRecord = false;


			CheckInList = checkIns;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Hotel Details Command.
		private ICommand hotelDetailsCommand;
		public ICommand HotelDetailsCommand
		{
			get => hotelDetailsCommand ?? (hotelDetailsCommand = new Command(async () => await ExecuteHotelDetailsCommand()));
		}
		private async Task ExecuteHotelDetailsCommand()
		{
			await Navigation.PushAsync(new Views.Hotel.HotelDetailsPage());
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

		#region User Queue List Command.
		private ICommand userQueueListCommand;
		public ICommand UserQueueListCommand
		{
			get => userQueueListCommand ?? (userQueueListCommand = new Command(async () => await ExecuteUserQueueListCommand()));

		}
		private async Task ExecuteUserQueueListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			var UserQueueList = await service.UserQueueListAsync(new Models.UserQueueListRequest()
			{
				UserId = Helper.Helper.LoggedInUserId
			});
			if (UserQueueList?.Count > 0)
			{
				int deviceWidth = App.ScreenWidth - 56;
				int imgWidth = deviceWidth * 80 / 100;

				foreach (var waitList in UserQueueList)
				{
					waitList.ImgWidth = imgWidth;
					waitList.ImagePath = "WaitListImage.png";
				}
				await Navigation.PushAsync(new Views.WaitList.AllWaitListPage(UserQueueList));
			}
			else
				await Navigation.PushAsync(new Views.WaitList.EmptyWaitListPage());
			DependencyService.Get<IProgressBar>().Hide();
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
