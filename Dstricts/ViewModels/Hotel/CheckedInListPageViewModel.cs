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
	public class CheckedInListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CheckedInListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Go To Check In Command.
		private ICommand goToCheckInCommand;
		public ICommand GoToCheckInCommand
		{
			get => goToCheckInCommand ?? (goToCheckInCommand = new Command(async () => await ExecuteGoToCheckInCommand()));
		}
		private async Task ExecuteGoToCheckInCommand()
		{
            DependencyService.Get<IProgressBar>().Show();
            IHotelService service = new HotelService();
            List<Models.CheckedInResponse> checkIns = new List<Models.CheckedInResponse>();
            var responseCheckedIn = await service.CheckedInHotelAsync(new Models.CheckedInRequest()
            {
                UserId = Helper.Helper.LoggedInUserId
            });

            var responseCheckedInApartment = await service.CheckedInApartmentAsync(new Models.CheckedInRequest()
            {
                UserId = Helper.Helper.LoggedInUserId
            });

            var responseCheckedInOwnerApartment = await service.CheckedInOwnerApartmentAsync(new Models.CheckedInRequest()
            {
                UserId = Helper.Helper.LoggedInUserId
            });


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

            if (responseCheckedInOwnerApartment?.Count > 0)
            {
                foreach (var item in responseCheckedInOwnerApartment)
                    if (item != null)
                        checkIns.Add(item);
            }
           if(checkIns?.Count > 0)
                await Navigation.PushAsync(new Views.Hotel.CheckInPage());
		   else
                await Navigation.PushAsync(new Views.Hotel.NoCheckInPage());
            DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Go To All Wait Command.
		private ICommand goToAllWaitCommand;
		public ICommand GoToAllWaitCommand
		{
			get => goToAllWaitCommand ?? (goToAllWaitCommand = new Command(async () => await ExecuteGoToAllWaitCommand()));
		}
		private async Task ExecuteGoToAllWaitCommand()
		{
			if (UserQueueList?.Count > 0)
			{
				int deviceWidth = App.ScreenWidth - 56;
				int imgWidth = deviceWidth * 80 / 100;

				foreach (var waitList in UserQueueList)
				{
					waitList.ImgWidth = imgWidth;
					waitList.ImagePath = "WaitListImage.png";
				}

					/*int index = 0;
					foreach (var waitList in UserQueueList)
					{
						waitList.FirstLetterBg = Helper.Helper.ListIconBgColorList[index];
						waitList.FirstLetterText = Helper.Helper.ListIconTextColorList[index];
						index = index + 1;
					}*/
					await Navigation.PushAsync(new Views.WaitList.AllWaitListPage(UserQueueList));
			}
			else
				await Navigation.PushAsync(new Views.WaitList.EmptyWaitListPage());
		}
		#endregion

		#region Go To Book Page Command.
		private ICommand goToBookPageCommand;
		public ICommand GoToBookPageCommand
		{
			get => goToBookPageCommand ?? (goToBookPageCommand = new Command(async () => await ExecuteGoToBookPageCommand()));
		}
		private async Task ExecuteGoToBookPageCommand()
		{
			await Task.CompletedTask;
			//await Navigation.PushAsync(new Views.FittnessAndSpa.WellnessBookingTypePage());
		}
		#endregion

		#region Sos Help Command.
		private ICommand sosHelpCommand;
		public ICommand SosHelpCommand
		{
			get => sosHelpCommand ?? (sosHelpCommand = new Command(async () => await ExecuteSosHelpCommand()));
		}
		private async Task ExecuteSosHelpCommand()
		{
			await Navigation.PushAsync(new Views.SosHelp.SosHelpPage());
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
			UserQueueList = await service.UserQueueListAsync(new Models.UserQueueListRequest()
			{
				UserId = Helper.Helper.LoggedInUserId
			});
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
					Helper.Helper.HotelPropertyType = HotelPropertyType;
					if (codeInfo.Length == 3)
					{
						if (codeInfo[1] == "1")
						{
							VerifyCheckinId = codeInfo[2];
							GoToVerifyCheckedInCodePageCommand.Execute(null);
						}
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

		#region Search Command.
		private ICommand searchCommand;
		public ICommand SearchCommand
		{
			get => searchCommand ?? (searchCommand = new Command(async () => await ExecuteSearchCommand()));
		}
		private async Task ExecuteSearchCommand()
		{
			await Navigation.PushAsync(new Views.SearchHotel.SearchHotelByTypePage());
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

		#region Go To Test Design Pages Command.
		private ICommand goToTestDesignPagesCommand;
		public ICommand GoToTestDesignPagesCommand
		{
			get => goToTestDesignPagesCommand ?? (goToTestDesignPagesCommand = new Command(async () => await ExecuteGoToTestDesignPagesCommand()));
		}
		private async Task ExecuteGoToTestDesignPagesCommand()
		{
			await Navigation.PushAsync(new Views.TestPage478());
		}
		#endregion

		#region Properties.
		public List<Models.UserQueueListResponse> UserQueueList { get; set; }
		public int HotelPropertyType { get; set; }
		public string VerifyCheckinId { get; set; } = string.Empty;
		#endregion
	}
}