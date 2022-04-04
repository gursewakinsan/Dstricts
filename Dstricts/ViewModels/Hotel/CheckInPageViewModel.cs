using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

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

			responseCheckedIn.Add(new Models.CheckedInResponse() { PropertyNickName = "Hotel 1" });
			responseCheckedIn.Add(new Models.CheckedInResponse() { PropertyNickName = "Hotel 2" });
			responseCheckedIn.Add(new Models.CheckedInResponse() { PropertyNickName = "Hotel 3" });

			var responseCheckedInApartment = await service.CheckedInApartmentAsync(new Models.CheckedInRequest()
			{
				UserId = Helper.Helper.LoggedInUserId
			});

			var responseCheckedInMeetingList = await service.CheckedInMeetingListAsync(new Models.CheckedInMeetingListRequest()
			{
				UserId = Helper.Helper.LoggedInUserId
			});
			responseCheckedInMeetingList.Add(new Models.CheckedInMeetingListResponse() {Name = "Name 1",CompanyName= "CompanyName 1" });
			responseCheckedInMeetingList.Add(new Models.CheckedInMeetingListResponse() { Name = "Name 2", CompanyName = "CompanyName 2" });
			responseCheckedInMeetingList.Add(new Models.CheckedInMeetingListResponse() { Name = "Name 3", CompanyName = "CompanyName 3" });
			responseCheckedInMeetingList.Add(new Models.CheckedInMeetingListResponse() { Name = "Name 4", CompanyName = "CompanyName 4" });
			CheckedInMeetingList = responseCheckedInMeetingList;

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

			if (checkIns?.Count > 1)
			{
				int index = 0;
				foreach (var item in checkIns)
				{
					item.FirstLetterBg = Helper.Helper.ListIconBgColorList[index];
					item.FirstLetterText = Helper.Helper.ListIconTextColorList[index];
					index = index + 1;
				}
			}
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
		#endregion
	}
}
