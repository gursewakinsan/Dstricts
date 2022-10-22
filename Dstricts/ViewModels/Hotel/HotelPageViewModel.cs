using Xamarin.Forms;
using System.Windows.Input;

namespace Dstricts.ViewModels
{
    public class HotelPageViewModel : BaseViewModel
    {
		#region Constructor.
		public HotelPageViewModel(INavigation navigation)
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
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.SocialPage());
		}
		#endregion

		#region Your Room Command.
		private ICommand yourRoomCommand;
		public ICommand YourRoomCommand
		{
			get => yourRoomCommand ?? (yourRoomCommand = new Command(() => ExecuteYourRoomCommand()));
		}
		private void ExecuteYourRoomCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Hotel.HotelDetailsPage());
		}
		#endregion

		#region Properties.
		public Models.HotelCompleteInfoResponse HotelDetailsInfo => Helper.Helper.HotelDetails;
        #endregion
    }
}
