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
		}
	}
}