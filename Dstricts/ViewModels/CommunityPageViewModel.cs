using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

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
	}
}
