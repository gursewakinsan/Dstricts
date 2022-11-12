using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
    public class TravelAppCompanyPageViewModel : BaseViewModel
    {
		#region Constructor.
		public TravelAppCompanyPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Travel App Company Command.
		private ICommand travelAppCompanyCommand;
		public ICommand TravelAppCompanyCommand
		{
			get => travelAppCompanyCommand ?? (travelAppCompanyCommand = new Command(async () => await ExecuteTravelAppCompanyCommand()));
		}
		private async Task ExecuteTravelAppCompanyCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ISosService service = new SosService();
			var response = await service.TravelAppCompanyAsync(new Models.TravelAppCompanyRequest()
			{
				UserId = Helper.Helper.LoggedInUserId,
				EmergencyId = SelectedTravelAppAvailable.Id,
				TabType = SelectedTravelAppAvailable.TabType
			});
            foreach (var item in response)
				item.IsSelected = false;
			
			if (response?.Count > 0)
			{
				SelectcedCompanyName = response[0].EmergencyName;
				response[0].IsSelected = true;
				TravelAppCompanyLocationsCommand.Execute(response[0].Id);
			}
			TravelAppCompanyList = response;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Travel App Company Locations Command.
		private ICommand travelAppCompanyLocationsCommand;
		public ICommand TravelAppCompanyLocationsCommand
		{
			get => travelAppCompanyLocationsCommand ?? (travelAppCompanyLocationsCommand = new Command<int>(async (emergencyId) => await ExecuteTravelAppCompanyLocationsCommand(emergencyId)));
		}
		private async Task ExecuteTravelAppCompanyLocationsCommand(int emergencyId)
		{
			DependencyService.Get<IProgressBar>().Show();
			ISosService service = new SosService();
			TravelAppCompanyLocationsList = await service.TravelAppCompanyLocationsAsync(new Models.TravelAppCompanyLocationsRequest()
			{
				UserId = Helper.Helper.LoggedInUserId,
				EmergencyId = emergencyId,
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.TravelAppCompanyResponse> travelAppCompanyList;
		public List<Models.TravelAppCompanyResponse> TravelAppCompanyList
		{
			get => travelAppCompanyList;
			set
			{
				travelAppCompanyList = value;
				OnPropertyChanged("TravelAppCompanyList");
			}
		}

		private List<Models.TravelAppCompanyLocationsResponse> travelAppCompanyLocationsList;
		public List<Models.TravelAppCompanyLocationsResponse> TravelAppCompanyLocationsList
		{
			get => travelAppCompanyLocationsList;
			set
			{
				travelAppCompanyLocationsList = value;
				OnPropertyChanged("TravelAppCompanyLocationsList");
			}
		}

		private Models.TravelAppAvailableSosResponse selectedTravelAppAvailable;
		public Models.TravelAppAvailableSosResponse SelectedTravelAppAvailable
		{
			get => selectedTravelAppAvailable;
			set
			{
				selectedTravelAppAvailable = value;
				OnPropertyChanged("SelectedTravelAppAvailable");
			}
		}

        public string SelectcedCompanyName { get; set; }
        #endregion
    }
}
