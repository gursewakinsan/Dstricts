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

		#region Go To 499 Page Command.
		private ICommand goTo499PageCommand;
		public ICommand GoTo499PageCommand
		{
			get => goTo499PageCommand ?? (goTo499PageCommand = new Command(async () => await ExecuteGoTo499PageCommand()));
		}
		private async Task ExecuteGoTo499PageCommand()
		{
			await Navigation.PushAsync(new Views.DesignTestPages.TestPage499());
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
