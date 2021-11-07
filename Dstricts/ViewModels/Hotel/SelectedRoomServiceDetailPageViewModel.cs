using System.Linq;
using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class SelectedRoomServiceDetailPageViewModel : BaseViewModel
	{
		#region Constructor.
		public SelectedRoomServiceDetailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Selected Room Service Serve Based App Menu Command.
		private ICommand selectedRoomServiceServeBasedAppMenuCommand;
		public ICommand SelectedRoomServiceServeBasedAppMenuCommand
		{
			get => selectedRoomServiceServeBasedAppMenuCommand ?? (selectedRoomServiceServeBasedAppMenuCommand = new Command(async () => await ExecuteSelectedRoomServiceServeBasedAppMenuCommand()));
		}
		private async Task ExecuteSelectedRoomServiceServeBasedAppMenuCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			SelectedRoomService = RoomServiceList.FirstOrDefault(x => x.IsSelectedRoomService);
			var response = await service.SelectedRoomServiceServeBasedAppMenuAsync(new Models.SelectedRoomServiceServeBasedAppMenuRequest()
			{
				Id = Helper.Helper.HotelCheckedIn,
				ServeType = SelectedRoomService.ServeType
			});
			int deviceWidth = App.ScreenWidth - 56;
			int w = deviceWidth * 42 / 100;
			int h = w * 97 / 100;

			foreach (var item in response)
			{
				foreach (var category in item.Category)
				{
					category.ImgWidth = w;
					category.ImgHeight = h;
				}
			}
			SelectedRoomServiceDetailInfo = new List<Models.SelectedRoomServiceServeBasedAppMenuResponse>(response);

			ICartService cartService = new CartService();
			int cartServiceResponse = await cartService.CartItemCountAsync(new Models.CartItemCountRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn
			});
			IsProceedToCheckOut = cartServiceResponse > 0 ? true : false;
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
			await Navigation.PushAsync(new Views.Hotel.RoomServiceFoodCartListPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.SelectedRoomServiceServeBasedAppMenuResponse> selectedRoomServiceDetailInfo;
		public List<Models.SelectedRoomServiceServeBasedAppMenuResponse> SelectedRoomServiceDetailInfo
		{
			get => selectedRoomServiceDetailInfo;
			set
			{
				selectedRoomServiceDetailInfo = value;
				OnPropertyChanged("SelectedRoomServiceDetailInfo");
			}
		}

		private List<Models.SelectedRoomServiceAppServesResponse> roomServiceList;
		public List<Models.SelectedRoomServiceAppServesResponse> RoomServiceList
		{
			get => roomServiceList;
			set
			{
				roomServiceList = value;
				OnPropertyChanged("RoomServiceList");
			}
		}

		public Models.SelectedRoomServiceAppServesResponse selectedRoomService;
		public Models.SelectedRoomServiceAppServesResponse SelectedRoomService
		{
			get => selectedRoomService;
			set
			{
				selectedRoomService = value;
				OnPropertyChanged("SelectedRoomService");
			}
		}

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

