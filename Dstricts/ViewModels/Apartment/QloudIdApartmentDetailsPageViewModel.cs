using System.Linq;
using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class QloudIdApartmentDetailsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public QloudIdApartmentDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Apartment Detail Info Command.
		private ICommand apartmentDetailInfoCommand;
		public ICommand ApartmentDetailInfoCommand
		{
			get => apartmentDetailInfoCommand ?? (apartmentDetailInfoCommand = new Command(async () => await ExecuteApartmentDetailInfoCommand()));
		}
		private async Task ExecuteApartmentDetailInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IApartmentService service = new ApartmentService();
			ApartmentDetailInfo = await service.ApartmentDetailInfoAsync(new Models.ApartmentDetailInfoRequest()
			{
				Id = ApartmentDetails.QloudCheckOutId
			});
			Helper.Helper.ApartmentDetailInfo = ApartmentDetailInfo;

			ICommunityService communityService = new CommunityService();
			Helper.Helper.CommunityId = await communityService.GetCommunityInfoAsync(new Models.CommunityInfoRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn
			});
			Helper.Helper.IsPayment = ApartmentDetailInfo.IsPayment;
			Helper.Helper.BuildingId = ApartmentDetailInfo.BuildingId;

			ShowPaymentTab = ShowBookingTab = false;
			if (!Helper.Helper.IsGuest)
			{
				if (Helper.Helper.IsPayment)
					ShowPaymentTab = true;
				else
					ShowPaymentTab = false;
			}
			else
				ShowBookingTab = true;

			var responses = await service.GetSratedDetailAsync(new Models.GetSratedDetailRequest()
			{
				ApartmentId = SelectedCheckedIn.Id
			});
			if (responses?.Count > 0)
			{
				HowToSwitchInfo = responses.Where(x => x.IsSwitchOn == true).ToList();
				var howToUseInfo = responses.Where(x => x.IsSwitchOn == false).ToList();
                foreach (var item in howToUseInfo)
                {
					if (item.GetStartedTitle.Contains("Dish machine"))
						item.ButtonTextIcon = Helper.DstrictsAppFlatIcons.Dishwasher;
					else if (item.GetStartedTitle.Contains("Washing machine"))
						item.ButtonTextIcon = Helper.DstrictsAppFlatIcons.AccountCircleOutline;
				}
				HowToUseInfo = howToUseInfo;
			}
			BindListDecorated();
			Models.ApartmentCommunityAmenitiesResponse response = null;
			if (SelectedCheckedIn.BuildingId > 0)
			{
				response = await service.ApartmentBuildingAmenitiesAsync(new Models.ApartmentBuildingAmenitiesRequest()
				{
					BuildingId = SelectedCheckedIn.BuildingId,
				});

				var parkeringList = await service.ApartmentBuildingParkingsAsync(new Models.ApartmentBuildingAmenitiesRequest()
				{
					BuildingId = SelectedCheckedIn.BuildingId
				});
				if (parkeringList?.Count > 0)
					parkeringList[0].ItemWidth = App.ScreenWidth - 50;
				ParkeringList = parkeringList;
			}

			if (response != null)
			{
				int deviceWidth = App.ScreenWidth - 56;
				int imgWidth = deviceWidth * 90 / 100;
				foreach (var item in response.AmenitiesList)
					item.ItemWidth = imgWidth;

				foreach (var item in response.StorageAmenitiesList)
					item.ItemWidth = imgWidth;
				
				foreach (var item in response.TrashRecycleList)
					item.ItemWidth = imgWidth;

				AmenitiesListInfo = response.AmenitiesList;
				StorageAmenitiesListInfo = response.StorageAmenitiesList;
				TrashRecycleListInfo = response.TrashRecycleList;
			}
			IsAmenitiesListInfo = AmenitiesListInfo?.Count > 0 ? true : false;
			IsStorageAmenitiesListInfo = StorageAmenitiesListInfo?.Count > 0 ? true : false;
			IsTrashRecycleListInfo = TrashRecycleListInfo?.Count > 0 ? true : false;
			IsParkeringList = ParkeringList?.Count > 0 ? true : false;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Go To Community Page Command.
		private ICommand goToCommunityPageCommand;
		public ICommand GoToCommunityPageCommand
		{
			get => goToCommunityPageCommand ?? (goToCommunityPageCommand = new Command(async () => await ExecuteGoToCommunityPageCommand()));
		}
		private async Task ExecuteGoToCommunityPageCommand()
		{
			if (Helper.Helper.CommunityId > 0)
				await Navigation.PushAsync(new Views.Community.CommunityPage());
		}
		#endregion

		#region Go To My Page Command.
		private ICommand goToMyPageCommand;
		public ICommand GoToMyPageCommand
		{
			get => goToMyPageCommand ?? (goToMyPageCommand = new Command(async () => await ExecuteGoToMyPageCommand()));
		}
		private async Task ExecuteGoToMyPageCommand()
		{
			await Navigation.PushAsync(new Views.Apartment.MyPageInfo(ApartmentDetailInfo));
		}
		#endregion

		#region Go To Support Page Command.
		private ICommand goToSupportPageCommand;
		public ICommand GoToSupportPageCommand
		{
			get => goToSupportPageCommand ?? (goToSupportPageCommand = new Command(async () => await ExecuteGoToSupportPageCommand()));
		}
		private async Task ExecuteGoToSupportPageCommand()
		{
			await Navigation.PushAsync(new Views.Apartment.SupportPage());
		}
		#endregion

		#region Socail Click Command.
		private ICommand socailClickCommand;
		public ICommand SocailClickCommand
		{
			get => socailClickCommand ?? (socailClickCommand = new Command(() => ExecuteSocailClickCommand()));
		}
		private void ExecuteSocailClickCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.SocialPage());
		}
		#endregion

		#region Go To Tenant Invoice Info Command.
		private ICommand goToTenantInvoiceInfoCommand;
		public ICommand GoToTenantInvoiceInfoCommand
		{
			get => goToTenantInvoiceInfoCommand ?? (goToTenantInvoiceInfoCommand = new Command(async () => await ExecuteGoToTenantInvoiceInfoCommand()));
		}
		private async Task ExecuteGoToTenantInvoiceInfoCommand()
		{
			await Navigation.PushAsync(new Views.Invoice.TenantInvoiceInfoPage(ApartmentDetailInfo.BuildingId, ApartmentDetails.PropertyNickName));
		}
		#endregion

		#region Go To House Rules Page Command.
		private ICommand goToHouseRulesPageCommand;
		public ICommand GoToHouseRulesPageCommand
		{
			get => goToHouseRulesPageCommand ?? (goToHouseRulesPageCommand = new Command(async () => await ExecuteGoToHouseRulesPageCommand()));
		}
		private async Task ExecuteGoToHouseRulesPageCommand()
		{
			await Navigation.PushAsync(new Views.Apartment.HouseRulesPage());
		}
		#endregion

		#region Go To House Wifi Page Command.
		private ICommand goToHouseWifiPageCommand;
		public ICommand GoToHouseWifiPageCommand
		{
			get => goToHouseWifiPageCommand ?? (goToHouseWifiPageCommand = new Command(async () => await ExecuteGoToHouseWifiPageCommand()));
		}
		private async Task ExecuteGoToHouseWifiPageCommand()
		{
			if (ApartmentDetailInfo.IsWifiAvailable)
				await Navigation.PushAsync(new Views.Apartment.HouseWifiPage(ApartmentDetailInfo.WifiUserName, ApartmentDetailInfo.WifiPassword));
		}
		#endregion

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(() => ExecuteBackCommand()));
		}
		private void ExecuteBackCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Hotel.CheckInPage());
		}
		#endregion

		void BindListDecorated()
		{
			List<Models.CheckedInResponse> listDecorated = new List<Models.CheckedInResponse>();
			int deviceWidth = App.ScreenWidth - 56;
			int imgWidth = deviceWidth * 80 / 100;
			listDecorated.Add(new Models.CheckedInResponse()
			{
				ImgWidth = imgWidth,
				ImagePath = "imgGuestRoom",
				PropertyNickName = "Bedroom " + ApartmentDetailInfo.Bedrooms,
				BookingOverdate = "No window, 18-22 m2"
			});

			listDecorated.Add(new Models.CheckedInResponse()
			{
				ImgWidth = imgWidth,
				ImagePath = "imgBathroom",
				PropertyNickName = "Bathroom " + ApartmentDetailInfo.Bath,
				BookingOverdate = "No window, 18-22 m2"
			});

			listDecorated.Add(new Models.CheckedInResponse()
			{
				ImgWidth = imgWidth,
				ImagePath = "imgkitchen",
				PropertyNickName = "Kitchen 1",
				BookingOverdate = "No window, 18-22 m2"
			});

			listDecorated.Add(new Models.CheckedInResponse()
			{
				ImgWidth = imgWidth,
				ImagePath = "imgBalcony",
				PropertyNickName = "Hallway 1",
				BookingOverdate = "No window, 18-22 m2"
			});

			listDecorated.Add(new Models.CheckedInResponse()
			{
				ImgWidth = imgWidth,
				ImagePath = "imgGuestRoom",
				PropertyNickName = "Livingroom 1",
				BookingOverdate = "No window, 18-22 m2"
			});

			listDecorated.Add(new Models.CheckedInResponse()
			{
				ImgWidth = imgWidth,
				ImagePath = "imgHotelView",
				PropertyNickName = "Balcony 1",
				BookingOverdate = "No window, 18-22 m2"
			});

			listDecorated.Add(new Models.CheckedInResponse()
			{
				ImgWidth = imgWidth,
				ImagePath = "imgBalcony",
				PropertyNickName = "Terrace 1",
				BookingOverdate = "No window, 18-22 m2"
			});
			ListDecorated = listDecorated;
		}

		#region Properties.
		private Models.CheckedInResponse apartmentDetails;
		public Models.CheckedInResponse ApartmentDetails
		{
			get => apartmentDetails;
			set
			{
				apartmentDetails = value;
				OnPropertyChanged("ApartmentDetails");
			}
		}

		private List<Models.GetSratedDetailResponse> howToSwitchInfo;
		public List<Models.GetSratedDetailResponse> HowToSwitchInfo
		{
			get => howToSwitchInfo;
			set
			{
				howToSwitchInfo = value;
				OnPropertyChanged("HowToSwitchInfo");
			}
		}

		private List<Models.GetSratedDetailResponse> howToUseInfo;
		public List<Models.GetSratedDetailResponse> HowToUseInfo
		{
			get => howToUseInfo;
			set
			{
				howToUseInfo = value;
				OnPropertyChanged("HowToUseInfo");
			}
		}

		private Models.ApartmentDetailInfoResponse apartmentDetailInfo;
		public Models.ApartmentDetailInfoResponse ApartmentDetailInfo
		{
			get => apartmentDetailInfo;
			set
			{
				apartmentDetailInfo = value;
				OnPropertyChanged("ApartmentDetailInfo");
			}
		}

		private List<Models.CheckedInResponse> listDecorated;
		public List<Models.CheckedInResponse> ListDecorated
		{
			get => listDecorated;
			set
			{
				listDecorated = value;
				OnPropertyChanged("ListDecorated");
			}
		}

		private bool showPaymentTab;
		public bool ShowPaymentTab
		{
			get => showPaymentTab;
			set
			{
				showPaymentTab = value;
				OnPropertyChanged("ShowPaymentTab");
			}
		}

		private bool showBookingTab;
		public bool ShowBookingTab
		{
			get => showBookingTab;
			set
			{
				showBookingTab = value;
				OnPropertyChanged("ShowBookingTab");
			}
		}

		private List<Models.ApartmentCommunity> amenitiesListInfo;
		public List<Models.ApartmentCommunity> AmenitiesListInfo
		{
			get => amenitiesListInfo;
			set
			{
				amenitiesListInfo = value;
				OnPropertyChanged("AmenitiesListInfo");
			}
		}

		private bool isAmenitiesListInfo;
		public bool IsAmenitiesListInfo
		{
			get => isAmenitiesListInfo;
			set
			{
				isAmenitiesListInfo = value;
				OnPropertyChanged("IsAmenitiesListInfo");
			}
		}

		private List<Models.ApartmentCommunity> storageAmenitiesListInfo;
		public List<Models.ApartmentCommunity> StorageAmenitiesListInfo
		{
			get => storageAmenitiesListInfo;
			set
			{
				storageAmenitiesListInfo = value;
				OnPropertyChanged("StorageAmenitiesListInfo");
			}
		}

		private bool isStorageAmenitiesListInfo;
		public bool IsStorageAmenitiesListInfo
		{
			get => isStorageAmenitiesListInfo;
			set
			{
				isStorageAmenitiesListInfo = value;
				OnPropertyChanged("IsStorageAmenitiesListInfo");
			}
		}

		private List<Models.ApartmentCommunity> trashRecycleListInfo;
		public List<Models.ApartmentCommunity> TrashRecycleListInfo
		{
			get => trashRecycleListInfo;
			set
			{
				trashRecycleListInfo = value;
				OnPropertyChanged("TrashRecycleListInfo");
			}
		}

		private bool isTrashRecycleListInfo;
		public bool IsTrashRecycleListInfo
		{
			get => isTrashRecycleListInfo;
			set
			{
				isTrashRecycleListInfo = value;
				OnPropertyChanged("IsTrashRecycleListInfo");
			}
		}

		private Models.BuildingSelectedParkingInfoResponse buildingSelectedParkingInfo;
		public Models.BuildingSelectedParkingInfoResponse BuildingSelectedParkingInfo
		{
			get => buildingSelectedParkingInfo;
			set
			{
				buildingSelectedParkingInfo = value;
				OnPropertyChanged("BuildingSelectedParkingInfo");
			}
		}

		private bool isBuildingSelectedParkingInfo;
		public bool IsBuildingSelectedParkingInfo
		{
			get => isBuildingSelectedParkingInfo;
			set
			{
				isBuildingSelectedParkingInfo = value;
				OnPropertyChanged("IsBuildingSelectedParkingInfo");
			}
		}

		private List<Models.ApartmentCommunityParkingsResponse> parkeringList;
		public List<Models.ApartmentCommunityParkingsResponse> ParkeringList
		{
			get => parkeringList;
			set
			{
				parkeringList = value;
				OnPropertyChanged("ParkeringList");
			}
		}

		private bool isParkeringList;
		public bool IsParkeringList
		{
			get => isParkeringList;
			set
			{
				isParkeringList = value;
				OnPropertyChanged("IsParkeringList");
			}
		}
		public string UserName => Helper.Helper.LoggedInUserName;
		public Models.CheckedInResponse SelectedCheckedIn => Helper.Helper.ApartmentCheckedIn;
		#endregion
	}
}
