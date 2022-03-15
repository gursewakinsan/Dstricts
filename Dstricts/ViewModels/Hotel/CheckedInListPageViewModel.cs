using System;
using Xamarin.Forms;
using Dstricts.Service;
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
			await Navigation.PushAsync(new Views.Hotel.CheckInPage());
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
				int index = 0;
				foreach (var waitList in UserQueueList)
				{
					waitList.FirstLetterBg = Helper.Helper.ListIconBgColorList[index];
					waitList.FirstLetterText = Helper.Helper.ListIconTextColorList[index];
					index = index + 1;
				}
				await Navigation.PushAsync(new Views.WaitList.AllWaitListPage(UserQueueList));
			}
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
			string[] codeInfo = qrCode.Split('/');
			switch (codeInfo[0])
			{
				case "verify_checkin":
					HotelPropertyType = Convert.ToInt32(codeInfo[1]);
					GoToVerifyCheckedInCodePageCommand.Execute(null);
					break;
				case "getQueue":
					Helper.Helper.AvalibleQueueId = codeInfo[1];
					await Navigation.PushAsync(new Views.Queue.AvalibleQueueOnTheLocationPage());
					break;
				case "verify_adult_checkin":
					VerifyUserInvitationInfoCommand.Execute(codeInfo[2]);
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
			await Navigation.PushAsync(new Views.Hotel.VerifyCheckedInPage(HotelPropertyType));
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
			else
			{
				Helper.Helper.VerifyUserInvitationInfoId = id;
				await Navigation.PushAsync(new Views.Hotel.VerifyUserInvitationInfoCodePage(code));
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		public List<Models.UserQueueListResponse> UserQueueList { get; set; }
		public int HotelPropertyType { get; set; }
		#endregion
	}
}

