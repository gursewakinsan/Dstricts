﻿using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
    public class SupportPageViewModel : BaseViewModel
	{
		#region Constructor.
		public SupportPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			if (!Helper.Helper.IsGuest)
			{
				if (Helper.Helper.IsPayment)
					ShowPaymentTab = true;
				else
					ShowPaymentTab = false;
			}
			else
				ShowBookingTab = true;
		}
		#endregion

		#region Apartment Community Ticket Created Count Command. 
		private ICommand apartmentCommunityTicketCreatedCountCommand;
		public ICommand ApartmentCommunityTicketCreatedCountCommand
		{
			get => apartmentCommunityTicketCreatedCountCommand ?? (apartmentCommunityTicketCreatedCountCommand = new Command(async () => await ExecuteApartmentCommunityTicketCreatedCountCommand()));
		}
		private async Task ExecuteApartmentCommunityTicketCreatedCountCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICommunityService service = new CommunityService();
			ApartmentCommunityTicketInfo = await service.ApartmentCommunityTicketCreatedCountAsync(new Models.ApartmentCommunityTicketCreatedCountRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn
			});
			DependencyService.Get<IProgressBar>().Hide();
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

		#region Go To Create Ticket Page Command. 
		private ICommand goTocreateTicketPageCommand;
		public ICommand GoTocreateTicketPageCommand
		{
			get => goTocreateTicketPageCommand ?? (goTocreateTicketPageCommand = new Command(async () => await ExecuteGoTocreateTicketPageCommand()));
		}
		private async Task ExecuteGoTocreateTicketPageCommand()
		{
			await Navigation.PushAsync(new Views.Apartment.CreateTicketPage());
		}
		#endregion

		#region Go To Apartment Page Command. 
		private ICommand goToApartmentPageCommand;
		public ICommand GoToApartmentPageCommand
		{
			get => goToApartmentPageCommand ?? (goToApartmentPageCommand = new Command( () =>  ExecuteGoToApartmentPageCommand()));
		}
		private void ExecuteGoToApartmentPageCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.QloudIdApartmentDetailsPage(Helper.Helper.ApartmentCheckedIn));
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
		private Models.ApartmentCommunityTicketCreatedCountResponse apartmentCommunityTicketInfo;
		public Models.ApartmentCommunityTicketCreatedCountResponse ApartmentCommunityTicketInfo
        {
			get => apartmentCommunityTicketInfo;
			set
			{
				apartmentCommunityTicketInfo = value;
				OnPropertyChanged("ApartmentCommunityTicketInfo");
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
		#endregion
	}
}
