using Xamarin.Forms;
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

		#region Properties.
		public string DisplayPropertyNickName => Helper.Helper.PropertyNickName;
		#endregion
	}
}
