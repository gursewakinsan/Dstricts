using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoomServiceFoodCartListPage : ContentPage
	{
		RoomServiceFoodCartListPageViewModels viewModel;
		public RoomServiceFoodCartListPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new RoomServiceFoodCartListPageViewModels(this.Navigation);
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GetAllFoodCartItemsCommand.Execute(null);
		}

		private void OnDecreaseFoodItemCountClicked(object sender, System.EventArgs e)
		{
			Button buttonDecreaseCount = sender as Button;
			var foodItem = buttonDecreaseCount.BindingContext as Models.CartInfoResponse;
			if (foodItem.DishQuantity == 1)
			{
				viewModel.FoodCartListItemCount = viewModel.FoodCartListItemCount - 1;
				viewModel.FoodCartList.Remove(foodItem);
			}
			foodItem.DishQuantity = foodItem.DishQuantity - 1;
			viewModel.FoodCartListItemTotalPrice = viewModel.FoodCartListItemTotalPrice - foodItem.DishPrice;
			viewModel.UpdateCartItemCountCommand.Execute(foodItem);
		}

		private void OnIncreaseFoodItemCountClicked(object sender, System.EventArgs e)
		{
			Button buttonIncreaseCount = sender as Button;
			var foodItem = buttonIncreaseCount.BindingContext as Models.CartInfoResponse;
			foodItem.DishQuantity = foodItem.DishQuantity + 1;
			viewModel.FoodCartListItemTotalPrice = viewModel.FoodCartListItemTotalPrice + foodItem.DishPrice;
			viewModel.UpdateCartItemCountCommand.Execute(foodItem);
		}
	}
}