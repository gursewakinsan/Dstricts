using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class UpdateAdultsAndChildrenInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public UpdateAdultsAndChildrenInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
	}
}
