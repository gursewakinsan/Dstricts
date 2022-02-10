using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Dstricts.ViewModels
{
	public class WellnessSelectedServiceInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public WellnessSelectedServiceInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Wellness Selected Service Info Command.
		private ICommand wellnessSelectedServiceInfoCommand;
		public ICommand WellnessSelectedServiceInfoCommand
		{
			get => wellnessSelectedServiceInfoCommand ?? (wellnessSelectedServiceInfoCommand = new Command(async () => await ExecuteWellnessSelectedServiceInfoCommand()));
		}
		private async Task ExecuteWellnessSelectedServiceInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IFittnessAndSpaService service = new FittnessAndSpaService();
			WellnessSelectedServiceInfo = await service.WellnessSelectedServiceInfoAsync(new Models.WellnessSelectedServiceInfoRequest()
			{
				DishId = DishId
			});
			if (WellnessSelectedServiceInfo == null)
			{
				await Helper.Alert.DisplayAlert("Something went wrong please try again!");
				await Navigation.PopAsync();
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Increase Company Size Command.
		private ICommand increaseCompanySizeCommand;
		public ICommand IncreaseCompanySizeCommand
		{
			get => increaseCompanySizeCommand ?? (increaseCompanySizeCommand = new Command( () => ExecuteIncreaseCompanySizeCommand()));
		}
		private void ExecuteIncreaseCompanySizeCommand()
		{
			if (WellnessSelectedServiceInfo.OpenTotalPerson > CompanySize)
				CompanySize = CompanySize + 1;
		}
		#endregion

		#region Reduce Company Size Command.
		private ICommand reduceCompanySizeCommand;
		public ICommand ReduceCompanySizeCommand
		{
			get => reduceCompanySizeCommand ?? (reduceCompanySizeCommand = new Command(() => ExecuteReduceCompanySizeCommand()));
		}
		private void ExecuteReduceCompanySizeCommand()
		{
			if (CompanySize > 1)
				CompanySize = CompanySize - 1;
		}
		#endregion

		#region Add Public Service To Cart App Command.
		private ICommand addPublicServiceToCartAppCommand;
		public ICommand AddPublicServiceToCartAppCommand
		{
			get => addPublicServiceToCartAppCommand ?? (addPublicServiceToCartAppCommand = new Command(async () => await ExecuteAddPublicServiceToCartAppCommand()));
		}
		private async Task ExecuteAddPublicServiceToCartAppCommand()
		{
			if (WellnessSelectedServiceInfo.RecurringEvent)
				await Navigation.PushAsync(new Views.FittnessAndSpa.WellnessOpenCalenderInfoPage(WellnessSelectedServiceInfo));
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IFittnessAndSpaService service = new FittnessAndSpaService();
				var response = await service.AddPublicServiceToCartAppAsync(new Models.AddPublicServiceToCartAppRequest()
				{
					WellnessId = Helper.Helper.WellnessId,
					DstrictsUserId = Helper.Helper.LoggedInUserId,
					DishDetail = WellnessSelectedServiceInfo.DishDetail,
					DishImage = WellnessSelectedServiceInfo.DishImage,
					DishName = WellnessSelectedServiceInfo.DishName,
					Price = WellnessSelectedServiceInfo.DishPrice,
					Quantity = CompanySize,
					ServiceType = 5,
					ItemId = WellnessSelectedServiceInfo.Id,
					OneShared = WellnessSelectedServiceInfo.OneShared,
					OneSharedType = WellnessSelectedServiceInfo.OneSharedType,
					Checkid = Helper.Helper.HotelCheckedIn,
					OpenEventDate = WellnessSelectedServiceInfo.OpenEventDate,
					OpenEventTime = WellnessSelectedServiceInfo.OpenEventTime
				});
				if (response == 1)
				{
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
				}
				else
					await Helper.Alert.DisplayAlert("Something went wrong please try again!");
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		private int companySize = 1;
		public int CompanySize
		{
			get => companySize;
			set
			{
				companySize = value;
				OnPropertyChanged("CompanySize");
			}
		}

		private Models.WellnessSelectedServiceInfoResponse wellnessSelectedServiceInfo;
		public Models.WellnessSelectedServiceInfoResponse WellnessSelectedServiceInfo
		{
			get => wellnessSelectedServiceInfo;
			set
			{
				wellnessSelectedServiceInfo = value;
				OnPropertyChanged("WellnessSelectedServiceInfo");
			}
		}
		public string WellnessName => Helper.Helper.WellnessName;
		public int DishId { get; set; }
		#endregion
	}
}
