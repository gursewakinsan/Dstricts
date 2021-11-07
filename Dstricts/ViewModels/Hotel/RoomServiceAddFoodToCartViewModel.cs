using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class RoomServiceAddFoodToCartViewModel : BaseViewModel
	{
		#region Constructor.
		public RoomServiceAddFoodToCartViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Submit Command.
		private ICommand submitCommand;
		public ICommand SubmitCommand
		{
			get => submitCommand ?? (submitCommand = new Command(async () => await ExecuteSubmitCommand()));
		}
		private async Task ExecuteSubmitCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICartService service = new CartService();
			Models.AddFoodItemToCartRequest foodItem = new Models.AddFoodItemToCartRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn,
				ItemId = SelectedFoodCategory.Id,
				DishName = SelectedFoodCategory.DishName,
				DishDetail = SelectedFoodCategory.DishDetail,
				DishImage = SelectedFoodCategory.DishImage,
				DishPrice = SelectedFoodCategory.DishPrice,
				Quantity = FoodCartCount,
				ServiceType = SelectedFoodCategory.ServeType
			};
			int response = await service.AddFoodItemToCartAsync(foodItem);
			if (response == 1)
				await Navigation.PopAsync();
			else
				await Helper.Alert.DisplayAlert("Something went wrong please try again!");
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Increase Food Cart Count Command.
		private ICommand increaseFoodCartCountCommand;
		public ICommand IncreaseFoodCartCountCommand
		{
			get => increaseFoodCartCountCommand ?? (increaseFoodCartCountCommand = new Command(() => ExecuteIncreaseFoodCartCountCommand()));
		}
		private void ExecuteIncreaseFoodCartCountCommand()
		{
			FoodCartCount = FoodCartCount + 1;
		}
		#endregion

		#region Decrease Food Cart Count Command.
		private ICommand decreaseFoodCartCountCommand;
		public ICommand DecreaseFoodCartCountCommand
		{
			get => decreaseFoodCartCountCommand ?? (decreaseFoodCartCountCommand = new Command(() => ExecuteDecreaseFoodCartCountCommand()));
		}
		private void ExecuteDecreaseFoodCartCountCommand()
		{
			if (FoodCartCount > 1)
				FoodCartCount = FoodCartCount - 1;
		}
		#endregion

		#region Properties.
		private Models.HotelCompleteInfoResponse hotelDetails = Helper.Helper.HotelDetails;
		public Models.HotelCompleteInfoResponse HotelDetails
		{
			get => hotelDetails;
			set
			{
				hotelDetails = value;
				OnPropertyChanged("HotelDetails");
			}
		}

		private Models.Category selectedFoodCategory;
		public Models.Category SelectedFoodCategory
		{
			get => selectedFoodCategory;
			set
			{
				selectedFoodCategory = value;
				OnPropertyChanged("SelectedFoodCategory");
			}
		}

		private int foodCartCount = 1;
		public int FoodCartCount
		{
			get => foodCartCount;
			set
			{
				foodCartCount = value;
				OnPropertyChanged("FoodCartCount");
			}
		}
		#endregion
	}
}
