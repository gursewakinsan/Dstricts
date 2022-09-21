using System;
using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class CommunityPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CommunityPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
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
			HowToContactList = new List<HowToContact>();
			HowToContactList.Add(new HowToContact() { Id = 1, DisplayTitle = $"Your{Environment.NewLine}Neighbour" });
			HowToContactList.Add(new HowToContact() { Id = 2, DisplayTitle = $"Your{Environment.NewLine}Board" });
			HowToContactList.Add(new HowToContact() { Id = 3, DisplayTitle = $"Your{Environment.NewLine}Security" });
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

		#region Socail Click Command .
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

		#region Go To Tenants Page Command.
		private ICommand goToTenantsPageCommand;
		public ICommand GoToTenantsPageCommand
		{
			get => goToTenantsPageCommand ?? (goToTenantsPageCommand = new Command(async () => await ExecuteGoToTenantsPageCommand()));
		}
		private async Task ExecuteGoToTenantsPageCommand()
		{
			await Navigation.PushAsync(new Views.Community.TenantsPage());
		}
		#endregion

		#region Get Community Detail Info Command.
		private ICommand getCommunityDetailInfoCommand;
		public ICommand GetCommunityDetailInfoCommand
		{
			get => getCommunityDetailInfoCommand ?? (getCommunityDetailInfoCommand = new Command(async () => await ExecuteGetCommunityDetailInfoCommand()));
		}
		private async Task ExecuteGetCommunityDetailInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICommunityService service = new CommunityService();
			var response = await service.GetCommunityDetailInfoAsync(new Models.GetCommunityDetailInfoRequest()
			{
				CommunityId = Helper.Helper.CommunityId
			});
			if (response.ImagesList?.Count > 0)
			{
				int deviceWidth = App.ScreenWidth - 56;
				int imgWidth = deviceWidth * 90 / 100;
				foreach (var item in response.ImagesList)
					item.ImgWidth = imgWidth;
			}
			CommunityDetailInfo = response;

			var responseApartmentCommunityAmenities = await service.ApartmentCommunityAmenitiesAsync(new Models.ApartmentCommunityAmenitiesRequest()
			{
				CommunityId = Helper.Helper.CommunityId
			});
			if(responseApartmentCommunityAmenities !=null)
            {
				int deviceWidth = App.ScreenWidth - 56;
				int imgWidth = deviceWidth * 90 / 100;
				foreach (var item in responseApartmentCommunityAmenities.BookList)
					item.ItemWidth = imgWidth; 

				foreach (var item in responseApartmentCommunityAmenities.CommunityAmenityList)
					item.ItemWidth = imgWidth;

				foreach (var item in responseApartmentCommunityAmenities.CommunityChildrenAmenityList)
					item.ItemWidth = imgWidth;

				foreach (var item in responseApartmentCommunityAmenities.BuildingAmenityList)
					item.ItemWidth = imgWidth;

				ApartmentCommunityBookList = responseApartmentCommunityAmenities.BookList;
				CommunityAmenityList = responseApartmentCommunityAmenities.CommunityAmenityList;
				CommunityChildrenAmenityList = responseApartmentCommunityAmenities.CommunityChildrenAmenityList;
				BuildingAmenityList = responseApartmentCommunityAmenities.BuildingAmenityList;
			}
			IsBookAvailable = ApartmentCommunityBookList?.Count > 0 ? true : false;
			IsThingsToDoAvailable = CommunityAmenityList?.Count > 0 ? true : false;
			IsCommunityChildrenAmenityList = CommunityChildrenAmenityList?.Count > 0 ? true : false;
			IsBuildingAmenityList = BuildingAmenityList?.Count > 0 ? true : false;

			SocietyRulesList = await service.SocietyRulesListAsync(new Models.SocietyRulesListRequest()
			{
				CommunityId = Helper.Helper.CommunityId
			});
			IsCommunityRules = SocietyRulesList?.Count > 0 ? true : false;

			var eatAndDrinkList = new List<Models.ApartmentCommunity>();
			eatAndDrinkList.Add(new Models.ApartmentCommunity()
			{
				ImagePath = "https://www.qloudid.com/html/usercontent/images/amenities/bg/3.png",
				AmenityName = "Cocktail Bar",
				ItemWidth = App.ScreenWidth - 56
			});
			EatAndDrinkList = eatAndDrinkList;

			var parkeringList = new List<Models.ApartmentCommunity>();
			parkeringList.Add(new Models.ApartmentCommunity()
			{
				ImagePath = "https://www.qloudid.com/html/usercontent/images/amenities/bg/8.png",
				AmenityName = "Garage",
				ItemWidth = App.ScreenWidth - 56
			});
			ParkeringList = parkeringList;

			var trashAndRecycle = new List<Models.ApartmentCommunity>();
			trashAndRecycle.Add(new Models.ApartmentCommunity()
			{
				ImagePath = "https://www.qloudid.com/html/usercontent/images/amenities/bg/7.png",
				AmenityName = "Trash & Recycle",
				ItemWidth = App.ScreenWidth - 56
			});
			TrashAndRecycle = trashAndRecycle;

			int dWidth = App.ScreenWidth - 56;
			int width = dWidth * 90 / 100;
			var storageList = new List<Models.ApartmentCommunity>();
			storageList.Add(new Models.ApartmentCommunity()
			{
				ImagePath = "https://www.qloudid.com/html/usercontent/images/amenities/bg/6.png",
				AmenityName = "Bicycle room",
				ItemWidth = width
			});

			storageList.Add(new Models.ApartmentCommunity()
			{
				ImagePath = "https://www.qloudid.com/html/usercontent/images/amenities/bg/5.png",
				AmenityName = "Stroller",
				ItemWidth = width
			});
			StorageList = storageList;

			DependencyService.Get<IProgressBar>().Hide();
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
			await Navigation.PushAsync(new Views.Invoice.TenantInvoiceInfoPage(Helper.Helper.BuildingId, Helper.Helper.PropertyNickName));
		}
		#endregion

		#region Go To Rules Sub Rules Page View Command.
		private ICommand goToRulesSubRulesPageViewCommand;
		public ICommand GoToRulesSubRulesPageViewCommand
		{
			get => goToRulesSubRulesPageViewCommand ?? (goToRulesSubRulesPageViewCommand = new Command(async () => await ExecuteGoToRulesSubRulesPageViewCommand()));
		}
		private async Task ExecuteGoToRulesSubRulesPageViewCommand()
		{
			await Navigation.PushAsync(new Views.Community.RulesSubRulesPage(SocietyRulesList, CommunityDetailInfo.SocietyName));
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
			await Navigation.PushAsync(new Views.Apartment.MyPageInfo(Helper.Helper.ApartmentDetailInfo));
		}
		#endregion

		#region Go To Community Wifi Page Command.
		private ICommand goToCommunityWifiPageCommand;
		public ICommand GoToCommunityWifiPageCommand
		{
			get => goToCommunityWifiPageCommand ?? (goToCommunityWifiPageCommand = new Command(async () => await ExecuteGoToCommunityWifiPageCommand()));
		}
		private async Task ExecuteGoToCommunityWifiPageCommand()
		{
			if (CommunityDetailInfo.IsWifiAvailable)
				await Navigation.PushAsync(new Views.Community.CommunityWifiPage(CommunityDetailInfo.WifiUsername, CommunityDetailInfo.WifiPassword));
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

		#region Properties.
		private Models.GetCommunityDetailInfoResponse communityDetailInfo;
		public Models.GetCommunityDetailInfoResponse CommunityDetailInfo
		{
			get => communityDetailInfo;
			set
			{
				communityDetailInfo = value;
				OnPropertyChanged("CommunityDetailInfo");
			}
		}

		private List<Models.ApartmentCommunity> apartmentCommunityBookList;
		public List<Models.ApartmentCommunity> ApartmentCommunityBookList
		{
			get => apartmentCommunityBookList;
			set
			{
				apartmentCommunityBookList = value;
				OnPropertyChanged("ApartmentCommunityBookList");
			}
		}

		private List<HowToContact> howToContactList;
		public List<HowToContact> HowToContactList
		{
			get => howToContactList;
			set
			{
				howToContactList = value;
				OnPropertyChanged("HowToContactList");
			}
		}

		private List<Models.ApartmentCommunity> communityChildrenAmenityList;
		public List<Models.ApartmentCommunity> CommunityChildrenAmenityList
		{
			get => communityChildrenAmenityList;
			set
			{
				communityChildrenAmenityList = value;
				OnPropertyChanged("CommunityChildrenAmenityList");
			}
		}

		private bool isCommunityChildrenAmenityList;
		public bool IsCommunityChildrenAmenityList
		{
			get => isCommunityChildrenAmenityList;
			set
			{
				isCommunityChildrenAmenityList = value;
				OnPropertyChanged("IsCommunityChildrenAmenityList");
			}
		}

		private List<Models.ApartmentCommunity> buildingAmenityList;
		public List<Models.ApartmentCommunity> BuildingAmenityList
		{
			get => buildingAmenityList;
			set
			{
				buildingAmenityList = value;
				OnPropertyChanged("BuildingAmenityList");
			}
		}

		private bool isBuildingAmenityList;
		public bool IsBuildingAmenityList
		{
			get => isBuildingAmenityList;
			set
			{
				isBuildingAmenityList = value;
				OnPropertyChanged("IsBuildingAmenityList");
			}
		}

		private List<Models.ApartmentCommunity> communityAmenityList;
		public List<Models.ApartmentCommunity> CommunityAmenityList
		{
			get => communityAmenityList;
			set
			{
				communityAmenityList = value;
				OnPropertyChanged("CommunityAmenityList");
			}
		}

		private List<Models.ApartmentCommunity> eatAndDrinkList;
		public List<Models.ApartmentCommunity> EatAndDrinkList
		{
			get => eatAndDrinkList;
			set
			{
				eatAndDrinkList = value;
				OnPropertyChanged("EatAndDrinkList");
			}
		}

		private List<Models.ApartmentCommunity> parkeringList;
		public List<Models.ApartmentCommunity> ParkeringList
		{
			get => parkeringList;
			set
			{
				parkeringList = value;
				OnPropertyChanged("ParkeringList");
			}
		}

		private List<Models.ApartmentCommunity> trashAndRecycle;
		public List<Models.ApartmentCommunity> TrashAndRecycle
		{
			get => trashAndRecycle;
			set
			{
				trashAndRecycle = value;
				OnPropertyChanged("TrashAndRecycle");
			}
		}

		private List<Models.ApartmentCommunity> storageList;
		public List<Models.ApartmentCommunity> StorageList
		{
			get => storageList;
			set
			{
				storageList = value;
				OnPropertyChanged("StorageList");
			}
		}

		private bool isBookAvailable;
		public bool IsBookAvailable
		{
			get => isBookAvailable;
			set
			{
				isBookAvailable = value;
				OnPropertyChanged("IsBookAvailable");
			}
		}

		private bool isThingsToDoAvailable;
		public bool IsThingsToDoAvailable
		{
			get => isThingsToDoAvailable;
			set
			{
				isThingsToDoAvailable = value;
				OnPropertyChanged("IsThingsToDoAvailable");
			}
		}

		private bool isCommunityRules;
		public bool IsCommunityRules
		{
			get => isCommunityRules;
			set
			{
				isCommunityRules = value;
				OnPropertyChanged("IsCommunityRules");
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
		public string DisplayPropertyNickName => Helper.Helper.PropertyNickName;
		public List<Models.SocietyRulesListResponse> SocietyRulesList { get; set; }

		public string Bracelet => "https://www.qloudid.com/html/usercontent/images/amenities/bg/2.png";
		public string TheTag => "https://www.qloudid.com/html/usercontent/images/amenities/bg/1.png";
		#endregion
	}
}

public class HowToContact
{
    public int Id { get; set; }
    public string DisplayTitle { get; set; }
}