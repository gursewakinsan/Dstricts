using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
    public class SelectedAmenityDetailPageViewModel : BaseViewModel
    {
		#region Constructor.
		public SelectedAmenityDetailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			NoImageWidth = App.ScreenWidth - 50;
		}
		#endregion

		#region Community Selected Info Command.
		private ICommand communitySelectedInfoCommand;
		public ICommand CommunitySelectedInfoCommand
		{
			get => communitySelectedInfoCommand ?? (communitySelectedInfoCommand = new Command(async () => await ExecuteCommunitySelectedInfoCommand()));
		}
		private async Task ExecuteCommunitySelectedInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICommunityService service = new CommunityService();
			var response = await service.CommunitySelectedAmenitiesInfoAsync(new Models.CommunitySelectedAmenitiesInfoRequest()
			{
				CommunityDetailId = CommunityDetailId
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
			CommunitySelectedAmenitiesInfoList = response;

			CommunitySelectedAmenitiesRulesInfo = await service.CommunitySelectedAmenitiesRulesInfoAsync(new Models.CommunitySelectedAmenitiesRulesInfoRequest()
			{
				CommunityDetailId = CommunityDetailId
			});
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

		private List<Models.CommunitySelectedAmenitiesRulesInfoResponse> communitySelectedAmenitiesRulesInfo;
		public List<Models.CommunitySelectedAmenitiesRulesInfoResponse> CommunitySelectedAmenitiesRulesInfo
		{
			get => communitySelectedAmenitiesRulesInfo;
			set
			{
				communitySelectedAmenitiesRulesInfo = value;
				OnPropertyChanged("CommunitySelectedAmenitiesRulesInfo");
			}
		}

		private Models.CommunitySelectedAmenitiesInfoResponse communitySelectedAmenitiesInfoList;
		public Models.CommunitySelectedAmenitiesInfoResponse CommunitySelectedAmenitiesInfoList
		{
			get => communitySelectedAmenitiesInfoList;
			set
			{
				communitySelectedAmenitiesInfoList = value;
				OnPropertyChanged("CommunitySelectedAmenitiesInfoList");
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
		public int CommunityDetailId { get; set; }
        #endregion
    }
}
