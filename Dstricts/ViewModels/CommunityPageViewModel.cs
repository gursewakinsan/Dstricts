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
			Application.Current.MainPage = new NavigationPage(new Views.Hotel.CheckedInListPage());
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

				ApartmentCommunityBookList = responseApartmentCommunityAmenities.BookList;
				CommunityAmenityList = responseApartmentCommunityAmenities.CommunityAmenityList;
			}
			IsBookAvailable = ApartmentCommunityBookList?.Count > 0 ? true : false;
			IsThingsToDoAvailable = CommunityAmenityList?.Count > 0 ? true : false;
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

		private List<Models.ApartmentCommunityBook> apartmentCommunityBookList;
		public List<Models.ApartmentCommunityBook> ApartmentCommunityBookList
		{
			get => apartmentCommunityBookList;
			set
			{
				apartmentCommunityBookList = value;
				OnPropertyChanged("ApartmentCommunityBookList");
			}
		}

		private List<Models.CommunityAmenity> communityAmenityList;
		public List<Models.CommunityAmenity> CommunityAmenityList
		{
			get => communityAmenityList;
			set
			{
				communityAmenityList = value;
				OnPropertyChanged("CommunityAmenityList");
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

		public bool IsPayment => Helper.Helper.IsPayment;
		public string DisplayPropertyNickName => Helper.Helper.PropertyNickName;
		#endregion
	}
}
