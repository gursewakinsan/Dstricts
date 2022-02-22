using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Dstricts.ViewModels
{
	public class BookServiceTimePageViewModel : BaseViewModel
	{
		#region Constructor.
		public BookServiceTimePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Select Employee For Selected Services Command.
		private ICommand selectEmployeeForSelectedServicesCommand;
		public ICommand SelectEmployeeForSelectedServicesCommand
		{
			get => selectEmployeeForSelectedServicesCommand ?? (selectEmployeeForSelectedServicesCommand = new Command(async () => await ExecuteSelectEmployeeForSelectedServicesCommand()));
		}
		private async Task ExecuteSelectEmployeeForSelectedServicesCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IFittnessAndSpaService service = new FittnessAndSpaService();
			var response = await service.SelectEmployeeForSelectedServicesAsync(new Models.SelectEmployeeForSelectedServicesRequest()
			{
				CheckId = 0,
				DstrictsUserId = Helper.Helper.LoggedInUserId,
				WellnessId = Helper.Helper.WellnessId
			});
			EmployeeId = 0;
			if (response?.Count > 0)
			{
				EmployeeId = response[0].Id;
				response[0].UserImageBorderColor = Color.FromHex("#2A2A31");
			}
			SelectEmployeeForSelectedServicesList = new ObservableCollection<Models.SelectEmployeeForSelectedServicesResponse>(response);
			AvailableDatesForbookingCommand.Execute(null);
			DependencyService.Get<IProgressBar>().Hide();
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
			EmployeeBookingCalenderInfoAppCommand.Execute(null);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Employee Booking Calender Info App Command.
		private ICommand employeeBookingCalenderInfoAppCommand;
		public ICommand EmployeeBookingCalenderInfoAppCommand
		{
			get => employeeBookingCalenderInfoAppCommand ?? (employeeBookingCalenderInfoAppCommand = new Command(async () => await ExecuteEmployeeBookingCalenderInfoAppCommand()));
		}
		private async Task ExecuteEmployeeBookingCalenderInfoAppCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IFittnessAndSpaService service = new FittnessAndSpaService();
			var response = await service.EmployeeBookingCalenderInfoAppAsync(new Models.EmployeeBookingCalenderInfoAppRequest()
			{
				CheckId = 0,
				DstrictsUserId = Helper.Helper.LoggedInUserId,
				WellnessId = Helper.Helper.WellnessId,
				EmployeeId = EmployeeId,
				DateId = DateId
			});
			int heightRequest = 0;

			if (response?.Count > 0)
				heightRequest = 50;
			if (response?.Count > 3)
				heightRequest = 100;
			if (response?.Count > 6)
				heightRequest = 150;
			if (response?.Count > 9)
				heightRequest = 200;
			if (response?.Count > 12)
				heightRequest = 250;
			if (response?.Count > 15)
				heightRequest = 300;
			if (response?.Count > 18)
				heightRequest = 350;
			if (response?.Count > 21)
				heightRequest = 400;
			if (response?.Count > 24)
				heightRequest = 450;
			if (response?.Count > 27)
				heightRequest = 500;
			if (response?.Count > 30)
				heightRequest = 550;
			if (response?.Count > 33)
				heightRequest = 600;
			if (response?.Count > 36)
				heightRequest = 650;
			if (response?.Count > 39)
				heightRequest = 700;
			if (response?.Count > 41)
				heightRequest = 750;
			if (response?.Count > 44)
				heightRequest = 800;
			if (response?.Count > 47)
				heightRequest = 850;

			EmployeeBookingCalenderHeightRequest = heightRequest + 20;
			EmployeeBookingCalenderInfo = new ObservableCollection<Models.EmployeeBookingCalenderInfoAppResponse>(response);
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
			if (SelectedBookingTime == null)
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
					EmployeeId = EmployeeId,
					BookingDate = SelectedBookingTime.Date,
					BookingEmployeeId = SelectedBookingTime.EmpId,
					BookingTime = SelectedBookingTime.WorkTime,
					TotalBookingTime = SelectedBookingTime.TimeRequired
				});
				//if (response == 1)
				//{
				Models.PayOnRequest payOnRequest = new Models.PayOnRequest()
				{
					CheckedInId = Helper.Helper.HotelCheckedIn,
					ServiceType = 5,
					QloudIdPay = 1,
					WellnessId = Helper.Helper.WellnessId
				};
				string payJson = Newtonsoft.Json.JsonConvert.SerializeObject(payOnRequest);
				if (Device.RuntimePlatform == Device.iOS)
					await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/DstrictsAppPayOn/{payJson}");
				else
					await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/DstrictsAppPayOn/{payJson}");
				//}
				//else
				//await Helper.Alert.DisplayAlert("Something went wrong please try again.");
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.SelectEmployeeForSelectedServicesResponse> selectEmployeeForSelectedServicesList;
		public ObservableCollection<Models.SelectEmployeeForSelectedServicesResponse> SelectEmployeeForSelectedServicesList
		{
			get => selectEmployeeForSelectedServicesList;
			set
			{
				selectEmployeeForSelectedServicesList = value;
				OnPropertyChanged("SelectEmployeeForSelectedServicesList");
			}
		}

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

		private ObservableCollection<Models.EmployeeBookingCalenderInfoAppResponse> employeeBookingCalenderInfo;
		public ObservableCollection<Models.EmployeeBookingCalenderInfoAppResponse> EmployeeBookingCalenderInfo
		{
			get => employeeBookingCalenderInfo;
			set
			{
				employeeBookingCalenderInfo = value;
				OnPropertyChanged("EmployeeBookingCalenderInfo");
			}
		}

		private double employeeBookingCalenderHeightRequest;
		public double EmployeeBookingCalenderHeightRequest
		{
			get => employeeBookingCalenderHeightRequest;
			set
			{
				employeeBookingCalenderHeightRequest = value;
				OnPropertyChanged("EmployeeBookingCalenderHeightRequest");
			}
		}

		public Models.EmployeeBookingCalenderInfoAppResponse SelectedBookingTime { get; set; }
		public int EmployeeId { get; set; }
		public int DateId { get; set; }
		#endregion
	}
}
