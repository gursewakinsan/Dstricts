using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Dstricts.ViewModels
{
	public class BookOpenCalenderInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public BookOpenCalenderInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Available Dates For booking Command.
		private ICommand availableDatesForbookingCommand;
		public ICommand AvailableDatesForbookingCommand
		{
			get => availableDatesForbookingCommand ?? (availableDatesForbookingCommand = new Command(async () => await ExecuteAvailableDatesForbookingCommand()));
		}
		private async Task ExecuteAvailableDatesForbookingCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IFittnessAndSpaService service = new FittnessAndSpaService();
			var response = await service.AvailableDatesForbookingAsync(new Models.AvailableDatesForbookingRequest()
			{
				CheckId = 0,
				DstrictsUserId = Helper.Helper.LoggedInUserId,
				WellnessId = Helper.Helper.WellnessId
			});
			if (response?.Count > 0)
			{
				DateId = response[0].DateId;
				response[0].PickDateBorderColor = Color.FromHex("#6263ED");
				response[0].DisplayDateColor = Color.FromHex("#6263ED");
				response[0].DisplayMonthColor = Color.FromHex("#6263ED");
			}
			AvailableDatesForbookingList = new ObservableCollection<Models.AvailableDatesForbookingResponse>(response);
			WellnessOpenCalenderInfo = await service.WellnessOpenCalenderInfoAsync(new Models.WellnessOpenCalenderInfoRequest()
			{
				CheckId = 0,
				DstrictsUserId = Helper.Helper.LoggedInUserId,
				WellnessId = Helper.Helper.WellnessId,
				EmployeeId = 0,
				DateId = DateId
			});
			IsBookingTimeSelected = true;
			WorkTimeSelectedCommand.Execute(null);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Wellness Open Calender Info Command.
		private ICommand wellnessOpenCalenderInfoCommand;
		public ICommand WellnessOpenCalenderInfoCommand
		{
			get => wellnessOpenCalenderInfoCommand ?? (wellnessOpenCalenderInfoCommand = new Command(async () => await ExecuteWellnessOpenCalenderInfoCommand()));
		}
		private async Task ExecuteWellnessOpenCalenderInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IFittnessAndSpaService service = new FittnessAndSpaService();
			WellnessOpenCalenderInfo = await service.WellnessOpenCalenderInfoAsync(new Models.WellnessOpenCalenderInfoRequest()
			{
				CheckId = 0,
				DstrictsUserId = Helper.Helper.LoggedInUserId,
				WellnessId = Helper.Helper.WellnessId,
				EmployeeId = 0,
				DateId = DateId
			});
			IsBookingTimeSelected = true;
			WorkTimeSelectedCommand.Execute(null);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Wellness Cart Booking Time Update Command.
		private ICommand wellnessCartBookingTimeUpdateCommand;
		public ICommand WellnessCartBookingTimeUpdateCommand
		{
			get => wellnessCartBookingTimeUpdateCommand ?? (wellnessCartBookingTimeUpdateCommand = new Command(async () => await ExecuteWellnessCartBookingTimeUpdateCommand()));
		}
		private async Task ExecuteWellnessCartBookingTimeUpdateCommand()
		{
			if (!IsBookingTimeSelected)
				await Helper.Alert.DisplayAlert("Please select time.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IFittnessAndSpaService service = new FittnessAndSpaService();
				var response = await service.WellnessCartBookingTimeUpdateAsync(new Models.WellnessCartBookingTimeUpdateRequest()
				{
					CheckId = 0,
					DstrictsUserId = Helper.Helper.LoggedInUserId,
					WellnessId = Helper.Helper.WellnessId,
					EmployeeId = 0,
					BookingDate = WellnessOpenCalenderInfo.Date,
					BookingEmployeeId = 0,
					BookingTime = WellnessOpenCalenderInfo.WorkTime,
					TotalBookingTime = WellnessOpenCalenderInfo.TimeRequired
				});
				Models.PayOnRequest payOnRequest = new Models.PayOnRequest()
				{
					CheckedInId = 0,
					ServiceType = 5,
					QloudIdPay = 1,
					WellnessId = Helper.Helper.WellnessId
				};
				string payJson = Newtonsoft.Json.JsonConvert.SerializeObject(payOnRequest);
				if (Device.RuntimePlatform == Device.iOS)
					await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/DstrictsAppPayOn/{payJson}");
				else
					await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/DstrictsAppPayOn/{payJson}");
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Work Time Selected Command.
		private ICommand workTimeSelectedCommand;
		public ICommand WorkTimeSelectedCommand
		{
			get => workTimeSelectedCommand ?? (workTimeSelectedCommand = new Command(() => ExecuteWorkTimeSelectedCommand()));
		}
		private void ExecuteWorkTimeSelectedCommand()
		{
			IsBookingTimeSelected = !IsBookingTimeSelected;
			if (IsBookingTimeSelected)
				WorkTimeFrameBorderColor = Color.FromHex("#6263ED");
			else
				WorkTimeFrameBorderColor = Color.FromHex("#2A2A31");
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.AvailableDatesForbookingResponse> availableDatesForbookingList;
		public ObservableCollection<Models.AvailableDatesForbookingResponse> AvailableDatesForbookingList
		{
			get => availableDatesForbookingList;
			set
			{
				availableDatesForbookingList = value;
				OnPropertyChanged("AvailableDatesForbookingList");
			}
		}

		private Models.WellnessSelectedServiceInfoResponse selectedWellnessServiceInfo;
		public Models.WellnessSelectedServiceInfoResponse SelectedWellnessServiceInfo
		{
			get => selectedWellnessServiceInfo;
			set
			{
				selectedWellnessServiceInfo = value;
				OnPropertyChanged("SelectedWellnessServiceInfo");
			}
		}

		private Models.WellnessOpenCalenderInfoResponse wellnessOpenCalenderInfo;
		public Models.WellnessOpenCalenderInfoResponse WellnessOpenCalenderInfo
		{
			get => wellnessOpenCalenderInfo;
			set
			{
				wellnessOpenCalenderInfo = value;
				OnPropertyChanged("WellnessOpenCalenderInfo");
			}
		}

		private Color workTimeFrameBorderColor = Color.FromHex("#2A2A31");
		public Color WorkTimeFrameBorderColor
		{
			get => workTimeFrameBorderColor;
			set
			{
				workTimeFrameBorderColor = value;
				OnPropertyChanged("WorkTimeFrameBorderColor");
			}
		}

		public bool IsBookingTimeSelected { get; set; } = true;
		public int DateId { get; set; }
		public string WellnessName => Helper.Helper.WellnessName;
		#endregion
	}
}
