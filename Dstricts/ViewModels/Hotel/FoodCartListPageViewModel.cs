using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
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
			ICartService service = new CartService();
			var response = await service.CartInfoAsync(new Models.CartInfoRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn
			});
			FoodCartList = new ObservableCollection<Models.CartInfoResponse>(response);
			FoodCartListItemCount = FoodCartList.Count;
			foreach (var item in FoodCartList)
			{
				for (int i = 0; i < item.DishQuantity; i++)
					FoodCartListItemTotalPrice = FoodCartListItemTotalPrice + item.DishPrice;
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Update Cart Item Count Command.
		private ICommand updateCartItemCountCommand;
		public ICommand UpdateCartItemCountCommand
		{
			get => updateCartItemCountCommand ?? (updateCartItemCountCommand = new Command<Models.CartInfoResponse>(async (cartInfo) => await ExecuteUpdateCartItemCountCommand(cartInfo)));
		}
		private async Task ExecuteUpdateCartItemCountCommand(Models.CartInfoResponse cartInfo)
		{
			DependencyService.Get<IProgressBar>().Show();
			ICartService service = new CartService();
			var response = await service.UpdateCartItemCountAsync(new Models.UpdateCartItemCountRequest()
			{
				CheckId = cartInfo.QloudCheckOutId,
				DishId = cartInfo.DishId,
				DishQuantity = cartInfo.DishQuantity
			});
			if (FoodCartListItemCount == 0)
				await Navigation.PopAsync();
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Pay On Command.
		private ICommand payOnCommand;
		public ICommand PayOnCommand
		{
			get => payOnCommand ?? (payOnCommand = new Command(async () => await ExecutePayOnCommand()));
		}
		private async Task ExecutePayOnCommand()
		{
			Models.PayOnRequest payOnRequest = new Models.PayOnRequest()
			{
				CheckedInId = Helper.Helper.HotelCheckedIn,
				ServiceType = 1,
				QloudIdPay = 1
			};
			string payJson = Newtonsoft.Json.JsonConvert.SerializeObject(payOnRequest);
			if (Device.RuntimePlatform == Device.iOS)
				await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/DstrictsAppPayOn/{payJson}");
			else
				await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/DstrictsAppPayOn/{payJson}");
		}
		#endregion

		#region Add To Room Command.
		private ICommand addToRoomCommand;
		public ICommand AddToRoomCommand
		{
			get => addToRoomCommand ?? (addToRoomCommand = new Command(async () => await ExecuteAddToRoomCommand()));
		}
		private async Task ExecuteAddToRoomCommand()
		{
			Models.PayOnRequest payOnRequest = new Models.PayOnRequest()
			{
				CheckedInId = Helper.Helper.HotelCheckedIn,
				ServiceType = 1,
				QloudIdPay = 2
			};
			string payJson = Newtonsoft.Json.JsonConvert.SerializeObject(payOnRequest);
			if (Device.RuntimePlatform == Device.iOS)
				await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/DstrictsAppPayOn/{payJson}");
			else
				await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/DstrictsAppPayOn/{payJson}");
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.CartInfoResponse> foodCartList;
		public ObservableCollection<Models.CartInfoResponse> FoodCartList
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
