using System.Linq;
using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Dstricts.ViewModels
{
	public class InvitedVisitorsMeetingListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public InvitedVisitorsMeetingListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.InvitedVisitorsMeetingListResponse> invitedVisitorsMeetingList;
		public ObservableCollection<Models.InvitedVisitorsMeetingListResponse> InvitedVisitorsMeetingList
		{
			get => invitedVisitorsMeetingList;
			set
			{
				invitedVisitorsMeetingList = value;
				OnPropertyChanged("InvitedVisitorsMeetingList");
			}
		}
		#endregion
	}
}
