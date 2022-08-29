using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
    public class HouseWifiPageViewModel :  BaseViewModel
    {
        #region Constructor.
        public HouseWifiPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Properties.
        public string DisplayPropertyNickName => Helper.Helper.PropertyNickName;
        #endregion
    }
}
