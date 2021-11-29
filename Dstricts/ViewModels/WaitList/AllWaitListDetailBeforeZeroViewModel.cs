using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class AllWaitListDetailBeforeZeroViewModel : BaseViewModel
	{
		#region Constructor.
		public AllWaitListDetailBeforeZeroViewModel(INavigation navigation)
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
