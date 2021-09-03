using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class RoomServiceMenuPageViewModel : BaseViewModel
	{
		#region Constructor.
		public RoomServiceMenuPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Room Service Menu Command.
		private ICommand getRoomServiceMenuCommand;
		public ICommand GetRoomServiceMenuCommand
		{
			get => getRoomServiceMenuCommand ?? (getRoomServiceMenuCommand = new Command(async () => await ExecuteGetRoomServiceMenuCommand()));
		}
		private async Task ExecuteGetRoomServiceMenuCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			if (RoomServiceAppMenu == null || RoomServiceAppMenu?.Count == 0)
			{
				IHotelService service = new HotelService();
				var response = await service.SelectedRoomServiceAppMenuAsync(new Models.SelectedRoomServiceAppMenuRequest()
				{
					QloudCheckOutId = Helper.Helper.HotelCheckedIn
				});
				RoomServiceAppMenu = response;
			}
			ICartService cartService = new CartService();
			int cartServiceResponse = await cartService.CartItemCountAsync(new Models.CartItemCountRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn
			});
			IsProceedToCheckOut = cartServiceResponse > 0 ? true : false;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Selected Room Service Menu Category Command.
		private ICommand selectedRoomServiceMenuCategoryCommand;
		public ICommand SelectedRoomServiceMenuCategoryCommand
		{
			get => selectedRoomServiceMenuCategoryCommand ?? (selectedRoomServiceMenuCategoryCommand = new Command(async () => await ExecuteSelectedRoomServiceMenuCategoryCommand()));
		}
		private async Task ExecuteSelectedRoomServiceMenuCategoryCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			await Navigation.PushAsync(new Views.Hotel.RoomServiceMenuDetailsPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Proceed To Check Out Command.
		private ICommand proceedToCheckOutCommand;
		public ICommand ProceedToCheckOutCommand
		{
			get => proceedToCheckOutCommand ?? (proceedToCheckOutCommand = new Command(async () => await ExecuteProceedToCheckOutCommand()));
		}
		private async Task ExecuteProceedToCheckOutCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			await Navigation.PushAsync(new Views.Hotel.FoodCartListPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		public Models.HotelCompleteInfoResponse HotelDetails => Helper.Helper.HotelDetails;

		private List<Models.SelectedRoomServiceAppMenuResponse> roomServiceAppMenu;
		public List<Models.SelectedRoomServiceAppMenuResponse> RoomServiceAppMenu
		{
			get => roomServiceAppMenu;
			set
			{
				roomServiceAppMenu = value;
				OnPropertyChanged("RoomServiceAppMenu");
			}
		}

		private bool isProceedToCheckOut;
		public bool IsProceedToCheckOut
		{
			get => isProceedToCheckOut;
			set
			{
				isProceedToCheckOut = value;
				OnPropertyChanged("IsProceedToCheckOut");
			}
		}
		#endregion
	}
}
