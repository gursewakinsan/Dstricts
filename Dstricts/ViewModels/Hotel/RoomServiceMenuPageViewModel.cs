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
			HotelImagesList = new List<HotelImages>();
			HotelImagesList.Add(new HotelImages() {ImageUrl= "https://cdn.dnaindia.com/sites/default/files/styles/full/public/2021/01/02/947331-grand-chola.jpg" });
			HotelImagesList.Add(new HotelImages() { ImageUrl = "https://images.indianexpress.com/2021/01/itc-grand-cholda-chennai.jpg" });
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
			await Task.CompletedTask;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<HotelImages> hotelImagesList;
		public List<HotelImages> HotelImagesList
		{
			get => hotelImagesList;
			set
			{
				hotelImagesList = value;
				OnPropertyChanged("HotelImagesList");
			}
		}
		#endregion
	}
}
