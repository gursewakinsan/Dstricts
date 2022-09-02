using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
    public class HowToSwitchPageViewModel : BaseViewModel
    {
		#region Constructor.
		public HowToSwitchPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			NoImageWidth = App.ScreenWidth - 50;
	}
        #endregion

        #region Properties.
        private List<Models.GetSratedDetailResponse> switchInfo;
		public List<Models.GetSratedDetailResponse> SwitchInfo
		{
			get => switchInfo;
			set
			{
				switchInfo = value;
				OnPropertyChanged("SwitchInfo");
			}
		}

		private Models.GetSratedDetailResponse selectedSwitchInfo;
		public Models.GetSratedDetailResponse SelectedSwitchInfo
		{
			get => selectedSwitchInfo;
			set
			{
				selectedSwitchInfo = value;
				OnPropertyChanged("SelectedSwitchInfo");
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
		#endregion
	}
}
