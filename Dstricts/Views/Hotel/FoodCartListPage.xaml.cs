using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FoodCartListPage : ContentPage
	{
		FoodCartListPageViewModel viewModel;
		public FoodCartListPage ()
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new FoodCartListPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GetAllFoodCartItemsCommand.Execute(null);
		}

		private void OnDecreaseFoodItemCountClicked(object sender, System.EventArgs e)
		{
			Button buttonDecreaseCount = sender as Button;
			var foodItem = buttonDecreaseCount.BindingContext as Models.AddFoodItemToCartRequest;
			if (foodItem.Quantity == 1)
			{
				viewModel.FoodCartListItemCount = viewModel.FoodCartListItemCount - 1;
				viewModel.FoodCartList.Remove(foodItem);
				Helper.Helper.FoodCartItems.Remove(foodItem);
				if (viewModel.FoodCartListItemCount == 0)
					Helper.Helper.IsProceedToCheckOut = false;
			}
			else
				foodItem.Quantity = foodItem.Quantity - 1;
			viewModel.FoodCartListItemTotalPrice = viewModel.FoodCartListItemTotalPrice - foodItem.DishPrice;
		}

		private void OnIncreaseFoodItemCountClicked(object sender, System.EventArgs e)
		{
			Button buttonIncreaseCount = sender as Button;
			var foodItem = buttonIncreaseCount.BindingContext as Models.AddFoodItemToCartRequest;
			foodItem.Quantity = foodItem.Quantity + 1;
			viewModel.FoodCartListItemTotalPrice = viewModel.FoodCartListItemTotalPrice + foodItem.DishPrice;
		}
	}
}