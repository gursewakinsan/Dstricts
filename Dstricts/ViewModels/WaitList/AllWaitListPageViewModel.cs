using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class AllWaitListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AllWaitListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Properties.
		private List<Models.UserQueueListResponse> allWaitListInfo;
		public List<Models.UserQueueListResponse> AllWaitListInfo
		{
			get => allWaitListInfo;
			set
			{
				allWaitListInfo = value;
				OnPropertyChanged("AllWaitListInfo");
			}
		}

		private bool isListOneRecord;
		public bool IsListOneRecord
		{
			get => isListOneRecord;
			set
			{
				isListOneRecord = value;
				OnPropertyChanged("IsListOneRecord");
			}
		}
		#endregion
	}
}
