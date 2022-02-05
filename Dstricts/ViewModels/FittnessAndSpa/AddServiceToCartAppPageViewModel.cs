using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class AddServiceToCartAppPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AddServiceToCartAppPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Add Service To Cart App Command.
		private ICommand addServiceToCartAppCommand;
		public ICommand AddServiceToCartAppCommand
		{
			get => addServiceToCartAppCommand ?? (addServiceToCartAppCommand = new Command(async () => await ExecuteAddServiceToCartAppCommand()));
		}
		private async Task ExecuteAddServiceToCartAppCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IFittnessAndSpaService service = new FittnessAndSpaService();
			List<Models.AddServiceToCartAppResponse> response = await service.AddServiceToCartAppAsync(new Models.AddServiceToCartAppRequest()
			{
				WellnessId = Helper.Helper.WellnessId,
				DstrictsUserId = Helper.Helper.LoggedInUserId,
				DishDetail = SelectedFittnessAndSpaInfo.DishDetail,
				DishImage = SelectedFittnessAndSpaInfo.DishImage,
				DishName = SelectedFittnessAndSpaInfo.DishName,
				Price = SelectedFittnessAndSpaInfo.DishPrice,
				Quantity = 1,
				ServiceType = 5,
				ItemId = SelectedFittnessAndSpaInfo.Id,
				OneShared = SelectedFittnessAndSpaInfo.OneShared,
				OneSharedType = SelectedFittnessAndSpaInfo.OneSharedType,
				Checkid = Helper.Helper.HotelCheckedIn
			});
			if (response?.Count > 0)
			{
				if (SelectedFittnessAndSpaInfo.OneSharedType == 2)
					await Navigation.PushAsync(new Views.FittnessAndSpa.WellnessPrivateCalenderInfoPage());
				else
					await Navigation.PushAsync(new Views.FittnessAndSpa.CartInfoWellnessListPage(response));
			}
			else
				await Helper.Alert.DisplayAlert("Something went wrong please try again!");
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private Models.FittnessAndSpaSelectedCategoryResponse selectedFittnessAndSpaInfo;
		public Models.FittnessAndSpaSelectedCategoryResponse SelectedFittnessAndSpaInfo
		{
			get => selectedFittnessAndSpaInfo;
			set
			{
				selectedFittnessAndSpaInfo = value;
				OnPropertyChanged("SelectedFittnessAndSpaInfo");
			}
		}

		public string WellnessName => Helper.Helper.WellnessName;
		#endregion
	}
}
