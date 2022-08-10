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
    public class ApartmentDetailInfoCheckinPageViewModel : BaseViewModel
    {
		#region Constructor.
		public ApartmentDetailInfoCheckinPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Apartment Detail Info Checkin Command. 
		private ICommand apartmentDetailInfoCheckinCommand;
		public ICommand ApartmentDetailInfoCheckinCommand
		{
			get => apartmentDetailInfoCheckinCommand ?? (apartmentDetailInfoCheckinCommand = new Command(async () => await ExecuteApartmentDetailInfoCheckinCommand()));
		}
		private async Task ExecuteApartmentDetailInfoCheckinCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IApartmentService service = new ApartmentService();
			ApartmentDetailInfo = await service.ApartmentDetailInfoCheckinAsync(new Models.ApartmentDetailInfoCheckinRequest()
			{
				Id = Helper.Helper.VerifyCheckinId,
				DstrictsUserId = Helper.Helper.LoggedInUserId
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Habitant Command. 
		private ICommand habitantCommand;
		public ICommand HabitantCommand
		{
			get => habitantCommand ?? (habitantCommand = new Command(async () => await ExecuteHabitantCommand()));
		}
		private async Task ExecuteHabitantCommand()
		{
			if (!ApartmentDetailInfo.IsOwner)
				Application.Current.MainPage = new NavigationPage(new Views.ErrorMessage.NotOwnerOfPropertyPage());
			else
			{
				if (ApartmentDetailInfo.OwnerCheckedIn == 1)
					Application.Current.MainPage = new NavigationPage(new Views.ErrorMessage.AlreadyCheckedInPropertyPage());
				else
				{
					if (Device.RuntimePlatform == Device.iOS)
						await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/VerifyHabitantPage/{Helper.Helper.VerifyCheckinId}");
					else
						await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/VerifyHabitantPage/{Helper.Helper.VerifyCheckinId}");
				}
			}
		}
		#endregion

		#region Guests Command. 
		private ICommand guestsCommand;
		public ICommand GuestsCommand
		{
			get => guestsCommand ?? (guestsCommand = new Command(() => ExecuteGuestsCommand()));
		}
		private void ExecuteGuestsCommand()
		{
			if (ApartmentDetailInfo.QloudCheckoutId == "0")
				Application.Current.MainPage = new NavigationPage(new Views.ErrorMessage.BookingNotAvailablePage());
			else
				VerifyBookingCheckinCommand.Execute(null);
		}
		#endregion

		#region Verify Booking Checkin Command.
		private ICommand verifyBookingCheckinCommand;
		public ICommand VerifyBookingCheckinCommand
		{
			get => verifyBookingCheckinCommand ?? (verifyBookingCheckinCommand = new Command(async () => await ExecuteVerifyBookingCheckinCommand()));
		}
		private async Task ExecuteVerifyBookingCheckinCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			var response = await service.VerifyBookingCheckinAsync(new Models.VerifyBookingCheckinRequest()
			{
				Id = ApartmentDetailInfo.QloudCheckoutId,
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
					await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/ShowMissingPreCheckInInfoPage/{ApartmentDetailInfo.QloudCheckoutId}");
				else
					await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/ShowMissingPreCheckInInfoPage/{ApartmentDetailInfo.QloudCheckoutId}");
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
			await Navigation.PushAsync(new Views.Hotel.VerifyCheckedInPage(Helper.Helper.HotelPropertyType, ApartmentDetailInfo.QloudCheckoutId));
		}
		#endregion

		#region Properties.
		private Models.ApartmentDetailInfoCheckinResponse apartmentDetailInfo;
		public Models.ApartmentDetailInfoCheckinResponse ApartmentDetailInfo
		{
			get => apartmentDetailInfo;
			set
			{
				apartmentDetailInfo = value;
				OnPropertyChanged("ApartmentDetailInfo");
			}
		}
        #endregion
    }
}
