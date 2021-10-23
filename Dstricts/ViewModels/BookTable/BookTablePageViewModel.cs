using System;
using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dstricts.ViewModels
{
	public class BookTablePageViewModel : BaseViewModel
	{
		#region Constructor.
		public BookTablePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			SelectedDate = MinDate = DateTime.Today;
		}
		#endregion

		#region Resturant Work Info Command.
		private ICommand resturantWorkInfoCommand;
		public ICommand ResturantWorkInfoCommand
		{
			get => resturantWorkInfoCommand ?? (resturantWorkInfoCommand = new Command(async () => await ExecuteResturantWorkInfoCommand()));
		}
		private async Task ExecuteResturantWorkInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			var response = await service.ResturantWorkInfoAsync(new Models.ResturantWorkInfoRequest()
			{
				ResturantId = Helper.Helper.SelectResturantId
			});
			if (response == null)
				response = new List<Models.ResturantWorkInfoResponse>();
			response.Insert(0, new Models.ResturantWorkInfoResponse() { Id = 0, Serve = "Select" });
			ResturantWorkInfo = response;
			ResturantWorkInfoSelectedItem = ResturantWorkInfo[0];
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Resturant Table Available Command.
		private ICommand resturantTableAvailableCommand;
		public ICommand ResturantTableAvailableCommand
		{
			get => resturantTableAvailableCommand ?? (resturantTableAvailableCommand = new Command(async () => await ExecuteResturantTableAvailableCommand()));
		}
		private async Task ExecuteResturantTableAvailableCommand()
		{
			IsVisibleSubmit = false;
			IsResturantTableAvailable = false;
			if (ResturantWorkInfoSelectedItem ==null || ResturantWorkInfoSelectedItem.Id == 0)
				return;
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			var response = await service.ResturantTableAvailableAsync(new Models.ResturantTableAvailableRequest()
			{
				ResturantId = Helper.Helper.SelectResturantId,
				ServeType = ResturantWorkInfoSelectedItem.Id,
				CompanySize = PartyCount,
				BookingDate = SelectedDate.ToString(),
				DateToday = SelectedDate == DateTime.Today ? true : false
			});
			foreach (var item in response)
			{
				item.IsSelected = false;
				item.SelectedWorkTimeBg = Color.FromHex("#2A2B30");
			}
			ResturantTableAvailableInfo = new ObservableCollection<Models.ResturantTableAvailableResponse>(response);
			IsResturantTableAvailable = ResturantTableAvailableInfo?.Count > 0 ? true : false;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Request Table Booking Command.
		private ICommand requestTableBookingCommand;
		public ICommand RequestTableBookingCommand
		{
			get => requestTableBookingCommand ?? (requestTableBookingCommand = new Command(async () => await ExecuteRequestTableBookingCommand()));
		}
		private async Task ExecuteRequestTableBookingCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			var response = await service.RequestTableBookingAsync(new Models.RequestTableBookingRequest()
			{
				ResturantId = Helper.Helper.SelectResturantId,
				UserId = Helper.Helper.LoggedInUserId,
				ServeType = ResturantWorkInfoSelectedItem.Id,
				CompanySize = PartyCount,
				BookingDate = SelectedDate.ToString(),
				TimeDetail= SelectedTimeDetail
			});
			if (response == 1)
				await Navigation.PopAsync();
			else
				await Helper.Alert.DisplayAlert("Something went wrong. Try again");
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.ResturantWorkInfoResponse> resturantWorkInfo;
		public List<Models.ResturantWorkInfoResponse> ResturantWorkInfo
		{
			get => resturantWorkInfo;
			set
			{
				resturantWorkInfo = value;
				OnPropertyChanged("ResturantWorkInfo");
			}
		}

		private Models.ResturantWorkInfoResponse resturantWorkInfoSelectedItem;
		public Models.ResturantWorkInfoResponse ResturantWorkInfoSelectedItem
		{
			get => resturantWorkInfoSelectedItem;
			set
			{
				resturantWorkInfoSelectedItem = value;
				OnPropertyChanged("ResturantWorkInfoSelectedItem");
			}
		}

		private int partyCount = 1;
		public int PartyCount
		{
			get => partyCount;
			set
			{
				if (value == 0)
					value = 1;
				else if (value > 10)
					value = 10;
				partyCount = value;
				OnPropertyChanged("PartyCount");
				ResturantTableAvailableCommand.Execute(null);
			}
		}

		private DateTime selectedDate;
		public DateTime SelectedDate
		{
			get => selectedDate;
			set
			{
				selectedDate = value;
				OnPropertyChanged("SelectedDate");
			}
		}

		private DateTime minDate;
		public DateTime MinDate
		{
			get => minDate;
			set
			{
				minDate = value;
				OnPropertyChanged("MinDate");
			}
		}

		private ObservableCollection<Models.ResturantTableAvailableResponse> resturantTableAvailableInfo;
		public ObservableCollection<Models.ResturantTableAvailableResponse> ResturantTableAvailableInfo
		{
			get => resturantTableAvailableInfo;
			set
			{
				resturantTableAvailableInfo = value;
				OnPropertyChanged("ResturantTableAvailableInfo");
			}
		}

		private bool isVisibleSubmit = false;
		public bool IsVisibleSubmit
		{
			get => isVisibleSubmit;
			set
			{
				isVisibleSubmit = value;
				OnPropertyChanged("IsVisibleSubmit");
			}
		}

		private bool isResturantTableAvailable = false;
		public bool IsResturantTableAvailable
		{
			get => isResturantTableAvailable;
			set
			{
				isResturantTableAvailable = value;
				OnPropertyChanged("IsResturantTableAvailable");
			}
		}

		public int SelectedTimeDetail { get; set; }
		#endregion
	}
}
