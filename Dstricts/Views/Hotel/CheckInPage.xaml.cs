using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using ZXing.Net.Mobile.Forms;
using System.Threading.Tasks;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckInPage : ContentPage
	{
		#region Variables.
		CheckInPageViewModel viewModel;
		ZXingScannerPage scanPage;
		#endregion

		#region Constructor.
		public CheckInPage ()
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CheckInPageViewModel(this.Navigation);
		}
		#endregion

		#region On Appearing.
		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GetCheckInCommand.Execute(null);
		}
		#endregion

		#region On Check In List Item Tapped.
		private async void OnGridCheckInTapped(object sender, System.EventArgs e)
		{
			Grid grid = sender as Grid;
			Models.CheckedInResponse checkedIn = grid.BindingContext as Models.CheckedInResponse;
			await OnCheckInListClicked(checkedIn);
		}

		private async void OnLabelCheckInTapped(object sender, System.EventArgs e)
		{
			Label label = sender as Label;
			Models.CheckedInResponse checkedIn = label.BindingContext as Models.CheckedInResponse;
			await OnCheckInListClicked(checkedIn);
		}

		private async void OnFrameCheckInTapped(object sender, System.EventArgs e)
		{
			Frame frame = sender as Frame;
			Models.CheckedInResponse checkedIn = frame.BindingContext as Models.CheckedInResponse;
			await OnCheckInListClicked(checkedIn);
		}
		private async void OnButtonCheckInTapped(object sender, System.EventArgs e)
		{
			Button button = sender as Button;
			Models.CheckedInResponse checkedIn = button.BindingContext as Models.CheckedInResponse;
			await OnCheckInListClicked(checkedIn);
		}

		private async void OnImageCheckInTapped(object sender, System.EventArgs e)
		{
			Image button = sender as Image;
			Models.CheckedInResponse checkedIn = button.BindingContext as Models.CheckedInResponse;
			await OnCheckInListClicked(checkedIn);
		}

        private async void OnImageButtonCheckInTapped(object sender, System.EventArgs e)
        {
            ImageButton button = sender as ImageButton;
            Models.CheckedInResponse checkedIn = button.BindingContext as Models.CheckedInResponse;
            await OnCheckInListClicked(checkedIn);
        }

        private async Task OnCheckInListClicked(Models.CheckedInResponse checkedIn)
		{
			if (checkedIn.IsSingleRecord) return;

			Helper.Helper.HotelCheckedIn = checkedIn.QloudCheckOutId;
			Helper.Helper.PropertyNickName = checkedIn.PropertyNickName;
			Helper.Helper.ApartmentCheckedIn = checkedIn;
			Helper.Helper.IsGuest = checkedIn.IsGuest;
			if (checkedIn.Enc == 0) //Queue
				await Navigation.PushAsync(new Queue.UserQueueWaitingDetailPage(checkedIn.Id));
			else if (checkedIn.Enc == 1) //Hotel
			{
				Helper.Helper.IsRoomService = checkedIn.RoomService;
				viewModel.HotelDetailsCommand.Execute(null);
			}
			else if (checkedIn.Enc == 2) //Apartment
				viewModel.GetCommunityInfoCommand.Execute(null);
		}
		#endregion

		#region Scan QR Code.
		private void OnBackClicked(object sender, System.EventArgs e)
		{
			Device.BeginInvokeOnMainThread(async () =>
			{
				this.scanPage.IsScanning = false;
				await Navigation.PopModalAsync();
			});
		}

		private async void OnBtnOpenCameraToScanQrCodeClicked(object sender, System.EventArgs e)
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