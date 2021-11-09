using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Laundry
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LaundryServiceCheckOutToPayPage : ContentPage
	{
		LaundryServiceCheckOutToPayViewModel viewModel;
		public LaundryServiceCheckOutToPayPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new LaundryServiceCheckOutToPayViewModel(this.Navigation);
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.LaundryCartInfoListCommand.Execute(null);
		}

		private void OnDecreaseLaundryCartItemCountClicked(object sender, System.EventArgs e)
		{
			Button buttonDecreaseCount = sender as Button;
			var laundryItem = buttonDecreaseCount.BindingContext as Models.CartInfoListResponse;
			if (laundryItem.DishQuantity == 1)
			{
				//viewModel.FoodCartListItemCount = viewModel.FoodCartListItemCount - 1;
				viewModel.LaundryCartInfoList.Remove(laundryItem);
			}
			laundryItem.DishQuantity = laundryItem.DishQuantity - 1;
			viewModel.LaundryCartListItemTotalPrice = viewModel.LaundryCartListItemTotalPrice - laundryItem.DishPrice;
			viewModel.UpdateLaundryCartItemCountCommand.Execute(laundryItem);
		}

		private void OnIncreaseLaundryCartItemCountClicked(object sender, System.EventArgs e)
		{
			Button buttonIncreaseCount = sender as Button;
			var laundryItem = buttonIncreaseCount.BindingContext as Models.CartInfoListResponse;
			laundryItem.DishQuantity = laundryItem.DishQuantity + 1;
			viewModel.LaundryCartListItemTotalPrice = viewModel.LaundryCartListItemTotalPrice + laundryItem.DishPrice;
			viewModel.UpdateLaundryCartItemCountCommand.Execute(laundryItem);
		}
	}
}