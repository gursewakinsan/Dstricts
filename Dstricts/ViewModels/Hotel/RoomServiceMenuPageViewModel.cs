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
			IHotelService service = new HotelService();
			var response = await service.SelectedRoomServiceAppMenuAsync(new Models.SelectedRoomServiceAppMenuRequest()
			{
				QloudCheckOutId = Helper.Helper.HotelCheckedIn
			});
			RoomServiceAppMenu = response;
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
		#endregion
	}
}
