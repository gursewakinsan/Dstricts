using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dstricts.ViewModels
{
	public class BookServiceDetailsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public BookServiceDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Selected Wellness Categories Command.
		private ICommand selectedWellnessCategoriesCommand;
		public ICommand SelectedWellnessCategoriesCommand
		{
			get => selectedWellnessCategoriesCommand ?? (selectedWellnessCategoriesCommand = new Command(async () => await ExecuteSelectedWellnessCategoriesCommand()));
		}
		private async Task ExecuteSelectedWellnessCategoriesCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IFittnessAndSpaService service = new FittnessAndSpaService();
			if (FittnessAndSpaSelectedCategoryList?.Count > 0)
				FittnessAndSpaSelectedCategoryList.Clear();
			var response = await service.SelectedWellnessCategoriesAsync(new Models.FittnessAndSpaCategoryRequest()
			{
				WellnessId = Helper.Helper.WellnessId,
				DstrictsUserId = Helper.Helper.LoggedInUserId,
				SelectedServicesType = Helper.Helper.SelectedServicesType
			});
			if (response?.Count > 0)
			{
				if (response.Count == 1)
					IsSelectedWellnessCategories = false;
				else
					IsSelectedWellnessCategories = true;
				BookableServiceId = response[0].Id;
				response[0].ButtonBg = Color.FromHex("#6263ED");
				SelectedWellnessBookingAppMenuCommand.Execute(null);
			}
			else IsSelectedWellnessCategories = false;
			FittnessAndSpaCategoryList = new ObservableCollection<Models.FittnessAndSpaCategoryResponse>(response);
			CartInfoWellnessListCommand.Execute(null);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Selected Wellness Booking App Menu Command.
		private ICommand selectedWellnessBookingAppMenuCommand;
		public ICommand SelectedWellnessBookingAppMenuCommand
		{
			get => selectedWellnessBookingAppMenuCommand ?? (selectedWellnessBookingAppMenuCommand = new Command(async () => await ExecuteSelectedWellnessBookingAppMenuCommand()));
		}
		private async Task ExecuteSelectedWellnessBookingAppMenuCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IFittnessAndSpaService service = new FittnessAndSpaService();
			var response = await service.SelectedWellnessBookingAppMenuAsync(new Models.FittnessAndSpaSelectedCategoryRequest()
			{
				WellnessId = Helper.Helper.WellnessId,
				BookableServiceId = BookableServiceId,
				DstrictsUserId = Helper.Helper.LoggedInUserId,
				SelectedServicesType = Helper.Helper.SelectedServicesType,
				CheckId = 0
			});
			FittnessAndSpaSelectedCategoryList = new ObservableCollection<Models.FittnessAndSpaSelectedCategoryResponse>(response);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Cart Info Wellness List Command.
		private ICommand cartInfoWellnessListCommand;
		public ICommand CartInfoWellnessListCommand
		{
			get => cartInfoWellnessListCommand ?? (cartInfoWellnessListCommand = new Command(async () => await ExecuteCartInfoWellnessListCommand()));
		}
		private async Task ExecuteCartInfoWellnessListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IFittnessAndSpaService service = new FittnessAndSpaService();
			AddServiceToCartList = await service.CartInfoWellnessListAsync(new Models.CartInfoWellnessListRequest()
			{
				WellnessId = Helper.Helper.WellnessId,
				Checkid = Helper.Helper.HotelCheckedIn,
				ServiceType = 5
			});
			if (AddServiceToCartList?.Count > 0)
				IsCartInfoWellnessList = true;
			else IsCartInfoWellnessList = false;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region View Cart Command.
		private ICommand viewCartCommand;
		public ICommand ViewCartCommand
		{
			get => viewCartCommand ?? (viewCartCommand = new Command(async () => await ExecuteViewCartCommand()));
		}
		private async Task ExecuteViewCartCommand()
		{
			Helper.Helper.IsFromViewCartButtonClicked = true;
			await Navigation.PushAsync(new Views.FittnessAndSpa.CartInfoWellnessListPage(AddServiceToCartList));
		}
		#endregion

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(async () => await ExecuteBackCommand()));
		}
		private async Task ExecuteBackCommand()
		{
			if (Helper.Helper.IsWellnessBookingType)
				Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
			await Navigation.PopAsync();
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.FittnessAndSpaCategoryResponse> fittnessAndSpaCategoryList;
		public ObservableCollection<Models.FittnessAndSpaCategoryResponse> FittnessAndSpaCategoryList
		{
			get => fittnessAndSpaCategoryList;
			set
			{
				fittnessAndSpaCategoryList = value;
				OnPropertyChanged("FittnessAndSpaCategoryList");
			}
		}

		private ObservableCollection<Models.FittnessAndSpaSelectedCategoryResponse> fittnessAndSpaSelectedCategoryList;
		public ObservableCollection<Models.FittnessAndSpaSelectedCategoryResponse> FittnessAndSpaSelectedCategoryList
		{
			get => fittnessAndSpaSelectedCategoryList;
			set
			{
				fittnessAndSpaSelectedCategoryList = value;
				OnPropertyChanged("FittnessAndSpaSelectedCategoryList");
			}
		}

		private bool isSelectedWellnessCategories;
		public bool IsSelectedWellnessCategories
		{
			get => isSelectedWellnessCategories;
			set
			{
				isSelectedWellnessCategories = value;
				OnPropertyChanged("IsSelectedWellnessCategories");
			}
		}

		private bool isCartInfoWellnessList;
		public bool IsCartInfoWellnessList
		{
			get => isCartInfoWellnessList;
			set
			{
				isCartInfoWellnessList = value;
				OnPropertyChanged("IsCartInfoWellnessList");
			}
		}

		public string WellnessName => Helper.Helper.WellnessName;
		public int BookableServiceId { get; set; }
		public List<Models.AddServiceToCartAppResponse> AddServiceToCartList { get; set; }
		#endregion
	}
}
