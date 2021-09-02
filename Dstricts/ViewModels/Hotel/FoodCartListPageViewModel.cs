using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dstricts.ViewModels
{
	public class FoodCartListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public FoodCartListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get All Food Cart Items Command.
		private ICommand getAllFoodCartItemsCommand;
		public ICommand GetAllFoodCartItemsCommand
		{
			get => getAllFoodCartItemsCommand ?? (getAllFoodCartItemsCommand = new Command(async () => await ExecuteGetAllFoodCartItemsCommand()));
		}
		private async Task ExecuteGetAllFoodCartItemsCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			FoodCartList = new ObservableCollection<Models.AddFoodItemToCartRequest>(Helper.Helper.FoodCartItems);
			FoodCartListItemCount = FoodCartList.Count;
			foreach (var item in FoodCartList)
			{
				for (int i = 0; i < item.Quantity; i++)
					FoodCartListItemTotalPrice = FoodCartListItemTotalPrice + item.DishPrice;
			}
			DependencyService.Get<IProgressBar>().Hide();
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.AddFoodItemToCartRequest> foodCartList;
		public ObservableCollection<Models.AddFoodItemToCartRequest> FoodCartList
		{
			get => foodCartList;
			set
			{
				foodCartList = value;
				OnPropertyChanged("FoodCartList");
			}
		}

		private int foodCartListItemCount;
		public int FoodCartListItemCount
		{
			get => foodCartListItemCount;
			set
			{
				foodCartListItemCount = value;
				OnPropertyChanged("FoodCartListItemCount");
			}
		}

		private int foodCartListItemTotalPrice;
		public int FoodCartListItemTotalPrice
		{
			get => foodCartListItemTotalPrice;
			set
			{
				foodCartListItemTotalPrice = value;
				OnPropertyChanged("FoodCartListItemTotalPrice");
			}
		}
		#endregion
	}
}
