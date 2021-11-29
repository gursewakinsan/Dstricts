using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class AllWaitListDetailInServicingPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AllWaitListDetailInServicingPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Properties.
		private Models.UserQueueListResponse selectedWaitInfo;
		public Models.UserQueueListResponse SelectedWaitInfo
		{
			get => selectedWaitInfo;
			set
			{
				selectedWaitInfo = value;
				OnPropertyChanged("SelectedWaitInfo");
			}
		}
		#endregion
	}
}
