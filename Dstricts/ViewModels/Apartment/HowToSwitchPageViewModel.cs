using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
    public class HowToSwitchPageViewModel : BaseViewModel
    {
		#region Constructor.
		public HowToSwitchPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
	}
}
