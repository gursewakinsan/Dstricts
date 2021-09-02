using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class RoomServiceMenuDetailsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public RoomServiceMenuDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Increase Item Count Command.
		private ICommand increaseItemCountCommand;
		public ICommand IncreaseItemCountCommand
		{
			get => increaseItemCountCommand ?? (increaseItemCountCommand = new Command( () => ExecuteIncreaseItemCountCommand()));
		}
		private void ExecuteIncreaseItemCountCommand()
		{
			ItemCount = ItemCount + 1;
		}
		#endregion

		#region Decrease Item Count Command.
		private ICommand decreaseItemCountCommand;
		public ICommand DecreaseItemCountCommand
		{
			get => decreaseItemCountCommand ?? (decreaseItemCountCommand = new Command(() => ExecuteDecreaseItemCountCommand()));
		}
		private void ExecuteDecreaseItemCountCommand()
		{
			if (ItemCount > 1)
				ItemCount = ItemCount - 1;
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
			if (Helper.Helper.FoodCartItems == null)
				Helper.Helper.FoodCartItems = new System.Collections.Generic.List<Models.AddFoodItemToCartRequest>();
			Models.AddFoodItemToCartRequest foodItem = new Models.AddFoodItemToCartRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn,
				ItemId = SelectedRoomServiceMenuCategory.Id,
				DishName = SelectedRoomServiceMenuCategory.DishName,
				DishDetail = SelectedRoomServiceMenuCategory.DishDetail,
				DishImage = SelectedRoomServiceMenuCategory.DishImage,
				DishPrice = SelectedRoomServiceMenuCategory.DishPrice,
				Quantity = ItemCount,
				ServiceType = SelectedRoomServiceMenuCategory.ServeType
			};
			Helper.Helper.FoodCartItems.Add(foodItem);
			if (!Helper.Helper.IsProceedToCheckOut) Helper.Helper.IsProceedToCheckOut = true;
			await Navigation.PopAsync();
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		public CategoryInfo SelectedRoomServiceMenuCategory => Helper.Helper.SelectedRoomServiceMenuCategory;

		private int itemCount = 1;
		public int ItemCount
		{
			get => itemCount;
			set
			{
				itemCount = value;
				OnPropertyChanged("ItemCount");
			}
		}
		#endregion
	}
}
