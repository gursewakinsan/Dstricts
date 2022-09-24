using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
    public class SelectedParkingDetailPageViewModel : BaseViewModel
    {
		#region Constructor.
		public SelectedParkingDetailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			NoImageWidth = App.ScreenWidth - 50;
		}
		#endregion

		#region Building Selected Parking Info Command.
		private ICommand buildingSelectedParkingInfoCommand;
		public ICommand BuildingSelectedParkingInfoCommand
		{
			get => buildingSelectedParkingInfoCommand ?? (buildingSelectedParkingInfoCommand = new Command(async () => await ExecuteBuildingSelectedParkingInfoCommand()));
		}
		private async Task ExecuteBuildingSelectedParkingInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICommunityService service = new CommunityService();
			var response = await service.BuildingSelectedParkingInfoAsync(new Models.BuildingSelectedParkingInfoRequest()
			{
				BuildingId = BuildingId
			});
			if (response?.Images?.Count == 1)
				response.Images[0].ItemWidth = App.ScreenWidth - 50;
			else
			{
				int deviceWidth = App.ScreenWidth - 56;
				int imgWidth = deviceWidth * 90 / 100;
				foreach (var item in response.Images)
					item.ItemWidth = imgWidth;
			}
			BuildingSelectedParkingInfo = response;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private Models.BuildingSelectedParkingInfoResponse buildingSelectedParkingInfo;
		public Models.BuildingSelectedParkingInfoResponse BuildingSelectedParkingInfo
		{
			get => buildingSelectedParkingInfo;
			set
			{
				buildingSelectedParkingInfo = value;
				OnPropertyChanged("BuildingSelectedParkingInfo");
			}
		}


		private List<Models.ApartmentCommunityParkingsResponse> apartmentCommunityParkings;
		public List<Models.ApartmentCommunityParkingsResponse> ApartmentCommunityParkings
		{
			get => apartmentCommunityParkings;
			set
			{
				apartmentCommunityParkings = value;
				OnPropertyChanged("ApartmentCommunityParkings");
			}
		}

		private Models.ApartmentCommunityParkingsResponse selectedApartmentCommunityParking;
		public Models.ApartmentCommunityParkingsResponse SelectedApartmentCommunityParking
		{
			get => selectedApartmentCommunityParking;
			set
			{
				selectedApartmentCommunityParking = value;
				OnPropertyChanged("SelectedApartmentCommunityParking");
			}
		}

		private int noImageWidth;
		public int NoImageWidth
		{
			get => noImageWidth;
			set
			{
				noImageWidth = value;
				OnPropertyChanged("NoImageWidth");
			}
		}
		public int BuildingId { get; set; }
		#endregion
	}
}
