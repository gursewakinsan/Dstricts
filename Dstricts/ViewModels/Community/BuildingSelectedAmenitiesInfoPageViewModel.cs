using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
    public class BuildingSelectedAmenitiesInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public BuildingSelectedAmenitiesInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			NoImageWidth = App.ScreenWidth - 50;
		}
		#endregion

		#region Building Selected Amenities Info Command.
		private ICommand buildingSelectedAmenitiesInfoCommand;
		public ICommand BuildingSelectedAmenitiesInfoCommand
		{
			get => buildingSelectedAmenitiesInfoCommand ?? (buildingSelectedAmenitiesInfoCommand = new Command(async () => await ExecuteBuildingSelectedAmenitiesInfoCommand()));
		}
		private async Task ExecuteBuildingSelectedAmenitiesInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICommunityService service = new CommunityService();
			var response = await service.BuildingSelectedAmenitiesInfoAsync(new Models.BuildingSelectedAmenitiesInfoRequest()
			{
				BuildingDetailId = SelectedCommunityId
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
			BuildingSelectedAmenitiesInfo = response;

			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.ApartmentCommunity> communityList;
		public List<Models.ApartmentCommunity> CommunityList
		{
			get => communityList;
			set
			{
				communityList = value;
				OnPropertyChanged("CommunityList");
			}
		}

		private Models.BuildingSelectedAmenitiesInfoResponse buildingSelectedAmenitiesInfo;
		public Models.BuildingSelectedAmenitiesInfoResponse BuildingSelectedAmenitiesInfo
		{
			get => buildingSelectedAmenitiesInfo;
			set
			{
				buildingSelectedAmenitiesInfo = value;
				OnPropertyChanged("BuildingSelectedAmenitiesInfo");
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
		public int SelectedCommunityId { get; set; }
		#endregion
	}
}
