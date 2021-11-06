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

		#region Add Food To Cart Command.
		private ICommand addFoodToCartCommand;
		public ICommand AddFoodToCartCommand
		{
			get => addFoodToCartCommand ?? (addFoodToCartCommand = new Command(async () => await ExecuteAddFoodToCartCommand()));
		}
		private async Task ExecuteAddFoodToCartCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			var response = await service.AddFoodToCartAsync(new Models.AddFoodToCartRequest()
			{
				QloudCheckoutId = Helper.Helper.HotelCheckedIn,
				DishId = SelectedFoodCategory.Id,
				DishName = SelectedFoodCategory.DishName,
				DishDetail = SelectedFoodCategory.DishDetail,
				DishImage = SelectedFoodCategory.DishImage,
				DishPrice = SelectedFoodCategory.DishPrice,
				DishQuantity = FoodCartCount,
				TotalPrice = SelectedFoodCategory.DishPrice * FoodCartCount
			});
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
