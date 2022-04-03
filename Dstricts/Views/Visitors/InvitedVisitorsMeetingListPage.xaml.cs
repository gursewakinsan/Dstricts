using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;

namespace Dstricts.Views.Visitors
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InvitedVisitorsMeetingListPage : ContentPage
	{
		InvitedVisitorsMeetingListPageViewModel viewModel;
		public InvitedVisitorsMeetingListPage(List<Models.InvitedVisitorsMeetingListResponse> list)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new InvitedVisitorsMeetingListPageViewModel(this.Navigation);
			viewModel.InvitedVisitorsMeetingList = new System.Collections.ObjectModel.ObservableCollection<Models.InvitedVisitorsMeetingListResponse>(list);
			viewModel.InvitedVisitorsMeetingInfo = list[0];
		}

		#region On Visitors Item Tapped.
		private void OnLabelVisitorsItemTapped(object sender, System.EventArgs e)
		{
			Label control = sender as Label;
			Models.InvitedVisitorsMeetingListResponse invitedVisitors = control.BindingContext as Models.InvitedVisitorsMeetingListResponse;
			SelectedInvitedVisitorsForMeeting(invitedVisitors);
		}

		private void OnGridVisitorsItemTapped(object sender, System.EventArgs e)
		{
			Grid control = sender as Grid;
			Models.InvitedVisitorsMeetingListResponse invitedVisitors = control.BindingContext as Models.InvitedVisitorsMeetingListResponse;
			SelectedInvitedVisitorsForMeeting(invitedVisitors);
		}

		private void OnFrameVisitorsItemTapped(object sender, System.EventArgs e)
		{
			Frame control = sender as Frame;
			Models.InvitedVisitorsMeetingListResponse invitedVisitors = control.BindingContext as Models.InvitedVisitorsMeetingListResponse;
			SelectedInvitedVisitorsForMeeting(invitedVisitors);
		}

		private void SelectedInvitedVisitorsForMeeting(Models.InvitedVisitorsMeetingListResponse invitedVisitors)
		{
			foreach (var item in viewModel.InvitedVisitorsMeetingList)
			{
				if (invitedVisitors.Id.Equals(item.Id))
				{
					if (item.IsSelectedVisitors)
					{
						item.IsSelectedVisitors = false;
						viewModel.IsVisibleSubmit = false;
						item.VisitorsCardBorderColor = Color.FromHex("#363541");
						item.VisitorsNameTextOpacity = 0.4;
					}
					else
					{
						item.IsSelectedVisitors = true;
						viewModel.IsVisibleSubmit = true;
						item.VisitorsCardBorderColor = Color.FromHex("#45C366");
						item.VisitorsNameTextOpacity = 100;
					}
				}
				else
				{
					item.VisitorsCardBorderColor = Color.FromHex("#363541");
					item.VisitorsNameTextOpacity = 0.4;
				}
			}
		}
		#endregion
	}
}