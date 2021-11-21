﻿using System;
using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class HotelDetailsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public HotelDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Hotel Complete Info Command.
		private ICommand hotelCompleteInfoCommand;
		public ICommand HotelCompleteInfoCommand
		{
			get => hotelCompleteInfoCommand ?? (hotelCompleteInfoCommand = new Command(async () => await ExecuteHotelCompleteInfoCommand()));
		}
		private async Task ExecuteHotelCompleteInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			Models.HotelCompleteInfoResponse response = await service.HotelCompleteInfoAsync(new Models.HotelCompleteInfoRequest()
			{
				Id =Helper.Helper.HotelCheckedIn
			});

			//Resturants
			if (response.InhouseResturants?.Count > 0)
			{
				IsInhouseResturantsList = true;
				InhouseResturantsInfo inhouseResturantsInfo = new InhouseResturantsInfo()
				{
					ResturantType = "Room Service",
					ImageUrl = "https://media.istockphoto.com/photos/beautiful-woman-laying-and-enjoying-breakfast-in-bed-picture-id1151357999?k=20&m=1151357999&s=612x612&w=0&h=SegUpGW4gDuhfuYyp_P5oIzz4Za4w9bk_uEIwwyrz5k="
				};
				foreach (var resturants in response.InhouseResturants)
					if (!string.IsNullOrWhiteSpace(resturants.ResturantType))
						resturants.ImageUrl = "https://www.elitetraveler.com/wp-content/uploads/2007/02/Alain-Ducasse-scaled.jpg";
				response.InhouseResturants.Insert(0, inhouseResturantsInfo);
			}
			else
				IsInhouseResturantsList = false;

			//Fittness
			if (response.InhouseFittness?.Count > 0)
			{
				IsInhouseFittnessList = true;
				InhouseFittnessInfo inhouseFittnessInfo = new InhouseFittnessInfo()
				{
					CenterType = "Fittness",
					ImageUrl = "https://ychef.files.bbci.co.uk/1376x774/p07ztf1q.jpg"
				};
				foreach (var fittness in response.InhouseFittness)
					if (!string.IsNullOrWhiteSpace(fittness.CenterType))
						fittness.ImageUrl = "https://d1heoihvzm7u4h.cloudfront.net/40d13e2df255a7bff04453dc1531cc416c8c443f_APRIL_banner_18.jpg";
				response.InhouseFittness.Insert(0, inhouseFittnessInfo);
			}
			else
				IsInhouseFittnessList = false;
			HotelDetails = response;
			Helper.Helper.HotelDetails = HotelDetails;

			#region Amenities Service.
			IAmenitiesService amenitiesService = new AmenitiesService();
			var roomAppAmenities = await amenitiesService.HotelRoomAppAmenitiesAsync(new Models.AmenitiesRequest()
			{
				Id = Helper.Helper.HotelCheckedIn
			});
			RoomAppAmenitiesCount = Convert.ToInt32(roomAppAmenities?.Count);

			var bedAppAmenities = await amenitiesService.HotelBedAppAmenitiesAsync(new Models.AmenitiesRequest()
			{
				Id = Helper.Helper.HotelCheckedIn
			});
			BedAppAmenitiesCount = Convert.ToInt32(bedAppAmenities?.Count);

			var mediaAppAmenities = await amenitiesService.HotelMediaAppAmenitiesAsync(new Models.AmenitiesRequest()
			{
				Id = Helper.Helper.HotelCheckedIn
			});
			MediaAppAmenitiesCount = Convert.ToInt32(mediaAppAmenities?.Count);

			var bathroomAppAmenities = await amenitiesService.HotelBathroomAppAmenitiesAsync(new Models.AmenitiesRequest()
			{
				Id = Helper.Helper.HotelCheckedIn
			});
			BathroomAppAmenitiesCount = Convert.ToInt32(bathroomAppAmenities?.Count);
			#endregion

			#region Laundry Service.
			if (response.IsDryCleaning)
			{
				ILaundryService laundryService = new LaundryService();
				var laundryServiceResponse = await laundryService.SelectedLaundaryCategoriesAsync(new Models.SelectedLaundaryCategoriesRequest()
				{
					Id = Helper.Helper.HotelCheckedIn
				});
				int deviceWidth = App.ScreenWidth - 56;
				int w = deviceWidth * 42 / 100;
				int h = w * 97 / 100;

				foreach (var item in laundryServiceResponse)
				{
					item.ImgWidth = w;
					item.ImgHeight = h;
				}
				LaundryServiceInfo = laundryServiceResponse;
				IsLaundryService = LaundryServiceInfo?.Count > 0 ? true : false;
			}
			#endregion

			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Room And Food Service Command.
		private ICommand roomAndFoodServiceCommand;
		public ICommand RoomAndFoodServiceCommand
		{
			get => roomAndFoodServiceCommand ?? (roomAndFoodServiceCommand = new Command(async () => await ExecuteRoomAndFoodServiceCommand()));
		}
		private async Task ExecuteRoomAndFoodServiceCommand()
		{
			if (Helper.Helper.IsRoomService)
			{
				DependencyService.Get<IProgressBar>().Show();
				Helper.Helper.HotelDetails = HotelDetails;
				await Navigation.PushAsync(new Views.Hotel.RoomServiceMenuPage());
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Selected Room Service App Serves Command.
		private ICommand selectedRoomServiceAppServesCommand;
		public ICommand SelectedRoomServiceAppServesCommand
		{
			get => selectedRoomServiceAppServesCommand ?? (selectedRoomServiceAppServesCommand = new Command(async () => await ExecuteSelectedRoomServiceAppServesCommand()));
		}
		private async Task ExecuteSelectedRoomServiceAppServesCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			var response = await service.SelectedRoomServiceAppServesAsync(new Models.SelectedRoomServiceAppServesRequest()
			{
				Id = Helper.Helper.HotelCheckedIn
			});

			int deviceWidth = App.ScreenWidth - 56;
			int w = deviceWidth * 42 / 100;
			int h = w * 97 / 100;

			foreach (var item in response)
			{
				item.ImgWidth = w;
				item.ImgHeight = h;
			}
			SelectedRoomServiceAppServesInfo = new List<Models.SelectedRoomServiceAppServesResponse>(response);
			IsRoomService = SelectedRoomServiceAppServesInfo?.Count > 0 ? true : false;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Selected Guest Service Command.
		private ICommand selectedGuestServiceCommand;
		public ICommand SelectedGuestServiceCommand
		{
			get => selectedGuestServiceCommand ?? (selectedGuestServiceCommand = new Command<string>(async (id) => await ExecuteSelectedGuestServiceCommand(id)));
		}
		private async Task ExecuteSelectedGuestServiceCommand(string id)
		{
			await Navigation.PushAsync(new Views.Amenities.AmenitiesServicePage(Convert.ToInt32(id)));
		}
		#endregion

		#region Properties.
		private List<Models.SelectedRoomServiceAppServesResponse> selectedRoomServiceAppServesInfo;
		public List<Models.SelectedRoomServiceAppServesResponse> SelectedRoomServiceAppServesInfo
		{
			get => selectedRoomServiceAppServesInfo;
			set
			{
				selectedRoomServiceAppServesInfo = value;
				OnPropertyChanged("SelectedRoomServiceAppServesInfo");
			}
		}

		private Models.HotelCompleteInfoResponse hotelDetails;
		public Models.HotelCompleteInfoResponse HotelDetails
		{
			get => hotelDetails;
			set
			{
				hotelDetails = value;
				OnPropertyChanged("HotelDetails");
			}
		}

		private bool isInhouseResturantsList = false;
		public bool IsInhouseResturantsList
		{
			get => isInhouseResturantsList;
			set
			{
				isInhouseResturantsList = value;
				OnPropertyChanged("IsInhouseResturantsList");
			}
		}

		private bool isInhouseFittnessList = false;
		public bool IsInhouseFittnessList
		{
			get => isInhouseFittnessList;
			set
			{
				isInhouseFittnessList = value;
				OnPropertyChanged("IsInhouseFittnessList");
			}
		}

		private List<Models.SelectedLaundaryCategoriesResponse> laundryServiceInfo;
		public List<Models.SelectedLaundaryCategoriesResponse> LaundryServiceInfo
		{
			get => laundryServiceInfo;
			set
			{
				laundryServiceInfo = value;
				OnPropertyChanged("LaundryServiceInfo");
			}
		}

		private bool isLaundryService;
		public bool IsLaundryService
		{
			get => isLaundryService;
			set
			{
				isLaundryService = value;
				OnPropertyChanged("IsLaundryService");
			}
		}


		private bool isRoomService;
		public bool IsRoomService
		{
			get => isRoomService;
			set
			{
				isRoomService = value;
				OnPropertyChanged("IsRoomService");
			}
		}

		private int roomAppAmenitiesCount;
		public int RoomAppAmenitiesCount
		{
			get => roomAppAmenitiesCount;
			set
			{
				roomAppAmenitiesCount = value;
				OnPropertyChanged("RoomAppAmenitiesCount");
			}
		}

		private int bedAppAmenitiesCount;
		public int BedAppAmenitiesCount
		{
			get => bedAppAmenitiesCount;
			set
			{
				bedAppAmenitiesCount = value;
				OnPropertyChanged("BedAppAmenitiesCount");
			}
		}

		private int mediaAppAmenitiesCount;
		public int MediaAppAmenitiesCount
		{
			get => mediaAppAmenitiesCount;
			set
			{
				mediaAppAmenitiesCount = value;
				OnPropertyChanged("MediaAppAmenitiesCount");
			}
		}

		private int bathroomAppAmenitiesCount;
		public int BathroomAppAmenitiesCount
		{
			get => bathroomAppAmenitiesCount;
			set
			{
				bathroomAppAmenitiesCount = value;
				OnPropertyChanged("BathroomAppAmenitiesCount");
			}
		}
		public string EatAndDrinkText => $"Eat & Drink";
		#endregion
	}
}

