using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using ZXing.Net.Mobile.Forms;
using System.Threading.Tasks;

namespace Dstricts.Views.WaitList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmptyWaitListPage : ContentPage
	{
		#region Variables.
		EmptyWaitListPageViewModel viewModel;
		ZXingScannerPage scanPage;
		#endregion
		public EmptyWaitListPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new EmptyWaitListPageViewModel(this.Navigation);
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