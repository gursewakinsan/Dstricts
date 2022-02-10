using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Dstricts.ViewModels
{
	public class WellnessOpenCalenderInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public WellnessOpenCalenderInfoPageViewModel(INavigation navigation)
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
				CheckId = Helper.Helper.HotelCheckedIn,
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
			//WellnessOpenCalenderInfoCommand.Execute(null);
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
			var response = await service.WellnessOpenCalenderInfoAsync(new Models.WellnessOpenCalenderInfoRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn,
				DstrictsUserId = Helper.Helper.LoggedInUserId,
				WellnessId = Helper.Helper.WellnessId,
				EmployeeId = 0,
				DateId = DateId
			});
			/*if (response?.Count > 0)
			{
			}
			else
				await Helper.Alert.DisplayAlert("Something went wrong please try again!");*/
			DependencyService.Get<IProgressBar>().Hide();
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

		public int DateId { get; set; }
		public string WellnessName => Helper.Helper.WellnessName;
		#endregion
	}
}
