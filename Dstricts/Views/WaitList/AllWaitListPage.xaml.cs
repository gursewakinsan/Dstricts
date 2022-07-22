using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using ZXing.Net.Mobile.Forms;
using System.Collections.Generic;

namespace Dstricts.Views.WaitList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AllWaitListPage : ContentPage
	{
		#region Variables.
		AllWaitListPageViewModel viewModel;
		ZXingScannerPage scanPage;
		#endregion

		public AllWaitListPage(List<Models.UserQueueListResponse> allWaitList)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AllWaitListPageViewModel(this.Navigation);
			if (allWaitList.Count > 1)
				viewModel.IsListOneRecord = true;
			else if (allWaitList.Count == 1)
				viewModel.IsListOneRecord = false;
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

		private async void OnImageAllWaitListTapped(object sender, EventArgs e)
		{
			Image frame = sender as Image;
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

		private async void OnLabelAllWaitListTapped(object sender, EventArgs e)
		{
			Label frame = sender as Label;
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

		#region Scan QR Code.
		private void OnBackClicked(object sender, EventArgs e)
		{
			Device.BeginInvokeOnMainThread(async () =>
			{
				this.scanPage.IsScanning = false;
				await Navigation.PopModalAsync();
			});
		}

		private async void OnBtnOpenCameraToScanQrCodeClicked(object sender, EventArgs e)
		{
			var customOverlay = new StackLayout
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.StartAndExpand
			};

			var back = new ImageButton
			{
				Margin = new Thickness(15, 20, 0, 0),
				BackgroundColor = Color.Transparent,
				Source = "iconBack.png",
				Padding = 10,
				HeightRequest = 50,
				WidthRequest = 50,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.StartAndExpand
			};

			back.Clicked += OnBackClicked;
			customOverlay.Children.Add(back);

			this.scanPage = new ZXingScannerPage(customOverlay: customOverlay);
			scanPage.OnScanResult += (result) => {
				scanPage.IsScanning = false;
				Device.BeginInvokeOnMainThread(async () => {
					await Navigation.PopModalAsync();
					viewModel.VerifyQrCodeCommand.Execute(result.Text);
				});
			};
			scanPage.IsScanning = true;
			await Navigation.PushModalAsync(scanPage);
		}
		#endregion
	}
}