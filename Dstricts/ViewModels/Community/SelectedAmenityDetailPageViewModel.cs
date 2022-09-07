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
		}
		#endregion
	}
}
