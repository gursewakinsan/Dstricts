using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class AllWaitListDetailViewModel : BaseViewModel
	{
		#region Constructor.
		public AllWaitListDetailViewModel(INavigation navigation)
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
