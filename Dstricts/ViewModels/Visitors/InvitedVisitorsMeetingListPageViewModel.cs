using System.Linq;
using Xamarin.Forms;
using Xamarin.Essentials;
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

		#region Sumbit Selected Invited Visitors Command.
		private ICommand sumbitSelectedInvitedVisitorsCommand;
		public ICommand SumbitSelectedInvitedVisitorsCommand
		{
			get => sumbitSelectedInvitedVisitorsCommand ?? (sumbitSelectedInvitedVisitorsCommand = new Command(async () => await ExecuteSumbitSelectedInvitedVisitorsCommand()));
		}
		private async Task ExecuteSumbitSelectedInvitedVisitorsCommand()
		{
			int selectedMeetingId = InvitedVisitorsMeetingList.FirstOrDefault(x => x.IsSelectedVisitors).Id;
			if (Device.RuntimePlatform == Device.iOS)
				await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/InvitedVisitorsMeetingId/{selectedMeetingId}");
			else
				await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/InvitedVisitorsMeetingId/{selectedMeetingId}");
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

		private Models.InvitedVisitorsMeetingListResponse invitedVisitorsMeetingInfo;
		public Models.InvitedVisitorsMeetingListResponse InvitedVisitorsMeetingInfo
		{
			get => invitedVisitorsMeetingInfo;
			set
			{
				invitedVisitorsMeetingInfo = value;
				OnPropertyChanged("InvitedVisitorsMeetingInfo");
			}
		}

		private bool isVisibleSubmit;
		public bool IsVisibleSubmit
		{
			get => isVisibleSubmit;
			set
			{
				isVisibleSubmit = value;
				OnPropertyChanged("IsVisibleSubmit");
			}
		}
		#endregion
	}
}
