using Xamarin.Forms;
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
			Application.Current.MainPage = new NavigationPage(new Views.Hotel.CheckedInListPage());
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

		public string DisplayPropertyNickName => Helper.Helper.PropertyNickName;
		#endregion
	}
}
