using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class WaitListResturantDetailPageViewModel : BaseViewModel
	{
		#region Constructor.
		public WaitListResturantDetailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Properties.
		private Models.WaitListResturantResponse selectedWaitResturantInfo;
		public Models.WaitListResturantResponse SelectedWaitResturantInfo
		{
			get => selectedWaitResturantInfo;
			set
			{
				selectedWaitResturantInfo = value;
				OnPropertyChanged("SelectedWaitResturantInfo");
			}
		}
		#endregion
	}
}
