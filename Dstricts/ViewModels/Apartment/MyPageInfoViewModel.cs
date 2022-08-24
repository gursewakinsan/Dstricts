using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class MyPageInfoViewModel : BaseViewModel
	{
		#region Constructor.
		public MyPageInfoViewModel(INavigation navigation)
		{
			Navigation = navigation;
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

		#region Go To Apartment Page Command. 
		private ICommand goToApartmentPageCommand;
		public ICommand GoToApartmentPageCommand
		{
			get => goToApartmentPageCommand ?? (goToApartmentPageCommand = new Command(() => ExecuteGoToApartmentPageCommand()));
		}
		private void ExecuteGoToApartmentPageCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.QloudIdApartmentDetailsPage(Helper.Helper.ApartmentCheckedIn));
		}
		#endregion

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

		public string UserName => Helper.Helper.LoggedInUserName;
		#endregion
	}
}
