using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
    public class TravelAppCompanyDetailsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public TravelAppCompanyDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
	}
}
