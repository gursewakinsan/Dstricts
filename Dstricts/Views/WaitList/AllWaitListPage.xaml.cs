using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;

namespace Dstricts.Views.WaitList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AllWaitListPage : ContentPage
	{
		AllWaitListPageViewModel viewModel;
		public AllWaitListPage(List<Models.UserQueueListResponse> allWaitList)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AllWaitListPageViewModel(this.Navigation);
			viewModel.AllWaitListInfo = allWaitList;
		}

		private async void OnGridAllWaitListTapped(object sender, EventArgs e)
		{
			Grid grid = sender as Grid;
			Models.UserQueueListResponse selectedWaitList = grid.BindingContext as Models.UserQueueListResponse;
			if (!selectedWaitList.IsServiced)
			{
				if (selectedWaitList.WaitingCount > 0)
					await Navigation.PushAsync(new AllWaitListDetailPage(selectedWaitList));
				else
					await Navigation.PushAsync(new AllWaitListDetailBeforeZeroPage(selectedWaitList));
			}
			else
				await Navigation.PushAsync(new AllWaitListDetailInServicingPage(selectedWaitList));
		}

		private async void OnFrameAllWaitListTapped(object sender, EventArgs e)
		{
			Frame frame = sender as Frame;
			Models.UserQueueListResponse selectedWaitList = frame.BindingContext as Models.UserQueueListResponse;
			if (!selectedWaitList.IsServiced)
			{
				if (selectedWaitList.WaitingCount > 0)
					await Navigation.PushAsync(new AllWaitListDetailPage(selectedWaitList));
				else
					await Navigation.PushAsync(new AllWaitListDetailBeforeZeroPage(selectedWaitList));
			}
			else
				await Navigation.PushAsync(new AllWaitListDetailInServicingPage(selectedWaitList));
		}
	}
}