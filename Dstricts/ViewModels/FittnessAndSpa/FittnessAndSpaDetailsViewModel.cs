using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Dstricts.ViewModels
{
	public class FittnessAndSpaDetailsViewModel : BaseViewModel
	{
		#region Constructor.
		public FittnessAndSpaDetailsViewModel(INavigation navigation)
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
			var response = await service.SelectedWellnessCategoriesAsync(new Models.FittnessAndSpaCategoryRequest()
			{
				WellnessId = Helper.Helper.WellnessId,
				DstrictsUserId = Helper.Helper.LoggedInUserId
			});
			if (response?.Count > 0)
			{
				IsSelectedWellnessCategories = true;
				BookableServiceId = response[0].Id;
				response[0].ButtonBg = Color.FromHex("#6263ED");
				SelectedWellnessBookingAppMenuCommand.Execute(null);
			}
			else IsSelectedWellnessCategories = false;

			/*response.Add(new Models.FittnessAndSpaCategoryResponse()
			{
				Id=1,
				ServiceCategoryName="Spa",
				ButtonBg= Color.FromHex("#6263ED")
			});
			response.Add(new Models.FittnessAndSpaCategoryResponse()
			{
				Id = 2,
				ServiceCategoryName = "Fittness",
				ButtonBg = Color.FromHex("#2A2A31")
			});
			response.Add(new Models.FittnessAndSpaCategoryResponse()
			{
				Id = 3,
				ServiceCategoryName = "Hairdresser",
				ButtonBg = Color.FromHex("#2A2A31")
			});

			response.Add(new Models.FittnessAndSpaCategoryResponse()
			{
				Id = 1,
				ServiceCategoryName = "Spa",
				ButtonBg = Color.FromHex("#2A2A31")
			});
			response.Add(new Models.FittnessAndSpaCategoryResponse()
			{
				Id = 2,
				ServiceCategoryName = "Fittness",
				ButtonBg = Color.FromHex("#2A2A31")
			});
			response.Add(new Models.FittnessAndSpaCategoryResponse()
			{
				Id = 3,
				ServiceCategoryName = "Hairdresser",
				ButtonBg = Color.FromHex("#2A2A31")
			});*/

			FittnessAndSpaCategoryList = new ObservableCollection<Models.FittnessAndSpaCategoryResponse>(response);
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
				DstrictsUserId = Helper.Helper.LoggedInUserId
			});
			/*for (int i = 0; i < 10; i++)
			{
				response.Add(new Models.FittnessAndSpaSelectedCategoryResponse()
				{
					Id = i,
					DishName = "Organic Apple" + i,
					DishDetail = "Unexpected organic fruits in Siwa, Egypt" + i,
					DishImage = "https://www.qloudid.com/html/usercontent/images/dstricts/4.png"
				});
			}*/
			
			FittnessAndSpaSelectedCategoryList = new ObservableCollection<Models.FittnessAndSpaSelectedCategoryResponse>(response);
			DependencyService.Get<IProgressBar>().Hide();
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

		public string WellnessName => Helper.Helper.WellnessName;
		public int BookableServiceId { get; set; }
		#endregion
	}
}
