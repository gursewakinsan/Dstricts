using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Dstricts.ViewModels
{
	public class LaundryServiceCheckOutToPayViewModel : BaseViewModel
	{
		#region Constructor.
		public LaundryServiceCheckOutToPayViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Laundry Cart Info List Command.
		private ICommand laundryCartInfoListCommand;
		public ICommand LaundryCartInfoListCommand
		{
			get => laundryCartInfoListCommand ?? (laundryCartInfoListCommand = new Command(async () => await ExecuteLaundryCartInfoListCommand()));
		}
		private async Task ExecuteLaundryCartInfoListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICartService service = new CartService();
			var laundryCartInfoList = await service.CartInfoListAsync(new Models.CartInfoListRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn,
				ServiceType = 4
			});
			LaundryCartInfoList = new ObservableCollection<Models.CartInfoListResponse>(laundryCartInfoList);
			LaundryCartListItemTotalPrice = 0;
			foreach (var item in LaundryCartInfoList)
				LaundryCartListItemTotalPrice = LaundryCartListItemTotalPrice + item.TotalPrice;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Update Laundry Cart Item Count Command.
		private ICommand updateLaundryCartItemCountCommand;
		public ICommand UpdateLaundryCartItemCountCommand
		{
			get => updateLaundryCartItemCountCommand ?? (updateLaundryCartItemCountCommand = new Command<Models.CartInfoListResponse>(async (laundryCartItem) => await ExecuteUpdateLaundryCartItemCountCommand(laundryCartItem)));
		}
		private async Task ExecuteUpdateLaundryCartItemCountCommand(Models.CartInfoListResponse laundryCartItem)
		{
			DependencyService.Get<IProgressBar>().Show();
			ICartService service = new CartService();
			var response = await service.UpdateCartItemCountInfoAsync(new Models.UpdateCartItemCountInfoRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn,
				DishId = laundryCartItem.DishId,
				DishQuantity = laundryCartItem.DishQuantity,
				ServiceType = 4,
			});
			if (LaundryCartInfoList.Count == 0)
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
				ServiceType = 4,
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
				ServiceType = 4,
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
		private ObservableCollection<Models.CartInfoListResponse> laundryCartInfoList;
		public ObservableCollection<Models.CartInfoListResponse> LaundryCartInfoList
		{
			get => laundryCartInfoList;
			set
			{
				laundryCartInfoList = value;
				OnPropertyChanged("LaundryCartInfoList");
			}
		}

		private int laundryCartListItemTotalPrice;
		public int LaundryCartListItemTotalPrice
		{
			get => laundryCartListItemTotalPrice;
			set
			{
				laundryCartListItemTotalPrice = value;
				OnPropertyChanged("LaundryCartListItemTotalPrice");
			}
		}
		#endregion
	}
}
