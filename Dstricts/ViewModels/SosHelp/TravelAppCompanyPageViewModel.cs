using System;
using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Forms.Maps;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Essentials;

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
		public async Task ExecuteTravelAppCompanyCommand()
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
				await ExecuteTravelAppCompanyLocationsCommand(response[0].Id);
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
		public async Task ExecuteTravelAppCompanyLocationsCommand(int emergencyId)
		{
			DependencyService.Get<IProgressBar>().Show();
			ISosService service = new SosService();
            var myCurrentLocation = await Geolocation.GetLocationAsync();
            Helper.Helper.MyCurrentLocationLatitude= myCurrentLocation.Latitude;
			Helper.Helper.MyCurrentLocationLongitude= myCurrentLocation.Longitude;
			TravelAppCompanyLocationsList = await service.TravelAppCompanyLocationsAsync(new Models.TravelAppCompanyLocationsRequest()
			{
				UserId = Helper.Helper.LoggedInUserId,
				EmergencyId = emergencyId,
				CurrentLatitude = myCurrentLocation.Latitude,
				CurrentLongitude = myCurrentLocation.Longitude
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

        private ObservableCollection<MapLocation> mapLocations;
        public ObservableCollection<MapLocation> MapLocations
        {
            get => mapLocations;
            set
            {
                mapLocations = value;
                OnPropertyChanged("MapLocations");
            }
        }

        public string SelectcedCompanyName { get; set; }
        #endregion
    }

	public class MapLocation : Models.BaseModel
	{
        private string locationName;
        public string LocationName
        {
            get => locationName;
            set
            {
                locationName = value;
                OnPropertyChanged("LocationName");
            }
        }

        private string locationAddress;
        public string LocationAddress
        {
            get => locationAddress;
            set
            {
                locationAddress = value;
                OnPropertyChanged("LocationAddress");
            }
        }


        private Position positionPins;
        public Position PositionPins
        {
            get => positionPins;
            set
            {
                positionPins = value;
                OnPropertyChanged("PositionPins");
            }
        }
	}
}
