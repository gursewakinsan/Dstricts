using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
    public class SosHelpPageViewModel : BaseViewModel
    {
		#region Constructor.
		public SosHelpPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Travel App Available Sos Command.
		private ICommand travelAppAvailableSosCommand;
		public ICommand TravelAppAvailableSosCommand
		{
			get => travelAppAvailableSosCommand ?? (travelAppAvailableSosCommand = new Command(async () => await ExecuteTravelAppAvailableSosCommand()));
		}
		private async Task ExecuteTravelAppAvailableSosCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ISosService service = new SosService();
			TravelAppAvailableSosList = await service.TravelAppAvailableSosAsync(new Models.TravelAppAvailableSosRequest()
			{
				UserId = Helper.Helper.LoggedInUserId
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.TravelAppAvailableSosResponse> travelAppAvailableSosList;
		public List<Models.TravelAppAvailableSosResponse> TravelAppAvailableSosList
		{
			get => travelAppAvailableSosList;
			set
			{
				travelAppAvailableSosList = value;
				OnPropertyChanged("TravelAppAvailableSosList");
			}
		}
		#endregion
	}
}
