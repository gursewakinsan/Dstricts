using System.Linq;
using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dstricts.ViewModels
{
	public class AmenitiesServicePageViewModel : BaseViewModel
	{
		#region Constructor.
		public AmenitiesServicePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			GuestServicesList = new List<Models.GuestServices>();
			GuestServicesList.Add(new Models.GuestServices() { Id = 0, ServiceName = "Room" });
			GuestServicesList.Add(new Models.GuestServices() { Id = 1, ServiceName = "Bed" });
			GuestServicesList.Add(new Models.GuestServices() { Id = 2, ServiceName = "Bathroom" });
			GuestServicesList.Add(new Models.GuestServices() { Id = 3, ServiceName = "Media" });
		}
		#endregion

		#region Get App Amenities Command.
		private ICommand getAppAmenitiesCommand;
		public ICommand GetAppAmenitiesCommand
		{
			get => getAppAmenitiesCommand ?? (getAppAmenitiesCommand = new Command(() => ExecuteGetAppAmenitiesCommand()));
		}
		private void ExecuteGetAppAmenitiesCommand()
		{
			foreach (var guestServices in GuestServicesList)
			{
				if (guestServices.Id == SelectedGuestServicesId)
					guestServices.SelectedServiceBg = Color.FromHex("#6263ED");
				else
					guestServices.SelectedServiceBg = Color.FromHex("#2A2A31");
			}
			switch (SelectedGuestServicesId)
			{
				case 0:
					HotelRoomAppAmenitiesCommand.Execute(null);
					break;
				case 1:
					HotelBedAppAmenitiesCommand.Execute(null);
					break;
				case 2:
					HotelBathroomAppAmenitiesCommand.Execute(null);
					break;
				case 3:
					HotelMediaAppAmenitiesCommand.Execute(null);
					break;
			}
		}
		#endregion

		#region Hotel Room App Amenities Command.
		private ICommand hotelRoomAppAmenitiesCommand;
		public ICommand HotelRoomAppAmenitiesCommand
		{
			get => hotelRoomAppAmenitiesCommand ?? (hotelRoomAppAmenitiesCommand = new Command(async () => await ExecuteHotelRoomAppAmenitiesCommand()));
		}
		private async Task ExecuteHotelRoomAppAmenitiesCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IAmenitiesService amenitiesService = new AmenitiesService();
			var roomAppAmenities = await amenitiesService.HotelRoomAppAmenitiesAsync(new Models.AmenitiesRequest()
			{
				Id = Helper.Helper.HotelCheckedIn
			});
			foreach (var item in roomAppAmenities)
			{
				if (item.Quantity > 0)
				{
					item.QuantityBg = Color.FromHex("#223426");
					item.QuantityText = Color.FromHex("#4FD471");
					item.CardBoarder = Color.FromHex("#6F70FB");
					item.CardBoarderOpacity = 10;
				}
				else
				{
					item.QuantityBg = Color.FromHex("#242A37");
					item.QuantityText = Color.FromHex("#6F70FB");
					item.CardBoarder = Color.FromHex("#E4E4E4");
					item.CardBoarderOpacity = 0.2;
				}
			}
			AmenitiesList = new ObservableCollection<Models.AmenitiesResponse>(roomAppAmenities);

			int cartAmenityResponse = await amenitiesService.CartAmenityItemCountAsync(new Models.CartAmenityItemCountRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn
			});
			IsCheckOut = cartAmenityResponse > 0 ? true : false;

			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Hotel Bed App Amenities Command.
		private ICommand hotelBedAppAmenitiesCommand;
		public ICommand HotelBedAppAmenitiesCommand
		{
			get => hotelBedAppAmenitiesCommand ?? (hotelBedAppAmenitiesCommand = new Command(async () => await ExecuteHotelBedAppAmenitiesCommand()));
		}
		private async Task ExecuteHotelBedAppAmenitiesCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IAmenitiesService amenitiesService = new AmenitiesService();
			var bedAppAmenities = await amenitiesService.HotelBedAppAmenitiesAsync(new Models.AmenitiesRequest()
			{
				Id = Helper.Helper.HotelCheckedIn
			});
			foreach (var item in bedAppAmenities)
			{
				if (item.Quantity > 0)
				{
					item.QuantityBg = Color.FromHex("#223426");
					item.QuantityText = Color.FromHex("#4FD471");
					item.CardBoarder = Color.FromHex("#6F70FB");
					item.CardBoarderOpacity = 10;
				}
				else
				{
					item.QuantityBg = Color.FromHex("#242A37");
					item.QuantityText = Color.FromHex("#6F70FB");
					item.CardBoarder = Color.FromHex("#E4E4E4");
					item.CardBoarderOpacity = 0.2;
				}
			}
			AmenitiesList = new ObservableCollection<Models.AmenitiesResponse>(bedAppAmenities);

			int cartAmenityResponse = await amenitiesService.CartAmenityItemCountAsync(new Models.CartAmenityItemCountRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn
			});
			IsCheckOut = cartAmenityResponse > 0 ? true : false;

			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Hotel Media App Amenities Command.
		private ICommand hotelMediaAppAmenitiesCommand;
		public ICommand HotelMediaAppAmenitiesCommand
		{
			get => hotelMediaAppAmenitiesCommand ?? (hotelMediaAppAmenitiesCommand = new Command(async () => await ExecuteHotelMediaAppAmenitiesCommand()));
		}
		private async Task ExecuteHotelMediaAppAmenitiesCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IAmenitiesService amenitiesService = new AmenitiesService();
			var mediaAppAmenities = await amenitiesService.HotelMediaAppAmenitiesAsync(new Models.AmenitiesRequest()
			{
				Id = Helper.Helper.HotelCheckedIn
			});
			foreach (var item in mediaAppAmenities)
			{
				if (item.Quantity > 0)
				{
					item.QuantityBg = Color.FromHex("#223426");
					item.QuantityText = Color.FromHex("#4FD471");
					item.CardBoarder = Color.FromHex("#6F70FB");
					item.CardBoarderOpacity = 10;
				}
				else
				{
					item.QuantityBg = Color.FromHex("#242A37");
					item.QuantityText = Color.FromHex("#6F70FB");
					item.CardBoarder = Color.FromHex("#E4E4E4");
					item.CardBoarderOpacity = 0.2;
				}
			}
			AmenitiesList = new ObservableCollection<Models.AmenitiesResponse>(mediaAppAmenities);

			int cartAmenityResponse = await amenitiesService.CartAmenityItemCountAsync(new Models.CartAmenityItemCountRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn
			});
			IsCheckOut = cartAmenityResponse > 0 ? true : false;

			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Hotel Bathroom App Amenities Command.
		private ICommand hotelBathroomAppAmenitiesCommand;
		public ICommand HotelBathroomAppAmenitiesCommand
		{
			get => hotelBathroomAppAmenitiesCommand ?? (hotelBathroomAppAmenitiesCommand = new Command(async () => await ExecuteHotelBathroomAppAmenitiesCommand()));
		}
		private async Task ExecuteHotelBathroomAppAmenitiesCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IAmenitiesService amenitiesService = new AmenitiesService();
			var bathroomAppAmenities = await amenitiesService.HotelBathroomAppAmenitiesAsync(new Models.AmenitiesRequest()
			{
				Id = Helper.Helper.HotelCheckedIn
			});
			foreach (var item in bathroomAppAmenities)
			{
				if (item.Quantity > 0)
				{
					item.QuantityBg = Color.FromHex("#223426");
					item.QuantityText = Color.FromHex("#4FD471");
					item.CardBoarder = Color.FromHex("#6F70FB");
					item.CardBoarderOpacity = 10;
				}
				else
				{
					item.QuantityBg = Color.FromHex("#242A37");
					item.QuantityText = Color.FromHex("#6F70FB");
					item.CardBoarder = Color.FromHex("#E4E4E4");
					item.CardBoarderOpacity = 0.2;
				}
			}
			AmenitiesList = new ObservableCollection<Models.AmenitiesResponse>(bathroomAppAmenities);

			int cartAmenityResponse = await amenitiesService.CartAmenityItemCountAsync(new Models.CartAmenityItemCountRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn
			});
			IsCheckOut = cartAmenityResponse > 0 ? true : false;

			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Check Out Amenity Service Command.
		private ICommand checkOutAmenityServiceCommand;
		public ICommand CheckOutAmenityServiceCommand
		{
			get => checkOutAmenityServiceCommand ?? (checkOutAmenityServiceCommand = new Command(async () => await ExecuteCheckOutAmenityServiceCommand()));
		}
		private async Task ExecuteCheckOutAmenityServiceCommand()
		{
			await Navigation.PushAsync(new Views.Amenities.AmenitiesServiceCheckOutToPayPage());
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.AmenitiesResponse> amenitiesList;
		public ObservableCollection<Models.AmenitiesResponse> AmenitiesList
		{
			get => amenitiesList;
			set
			{
				amenitiesList = value;
				OnPropertyChanged("AmenitiesList");
			}
		}

		private List<Models.GuestServices> guestServicesList;
		public List<Models.GuestServices> GuestServicesList
		{
			get => guestServicesList;
			set
			{
				guestServicesList = value;
				OnPropertyChanged("GuestServicesList");
			}
		}

		private int selectedGuestServicesId;
		public int SelectedGuestServicesId
		{
			get => selectedGuestServicesId;
			set
			{
				selectedGuestServicesId = value;
				OnPropertyChanged("SelectedGuestServicesId");
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

		private bool isCheckOut;
		public bool IsCheckOut
		{
			get => isCheckOut;
			set
			{
				isCheckOut = value;
				OnPropertyChanged("IsCheckOut");
			}
		}
		#endregion
	}
}
