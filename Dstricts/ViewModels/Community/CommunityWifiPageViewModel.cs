using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
    public class CommunityWifiPageViewModel :  BaseViewModel
    {
		#region Constructor.
		public CommunityWifiPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
        #endregion

        #region Properties.
        public string DisplayPropertyNickName => Helper.Helper.PropertyNickName;
        #endregion
    }
}
