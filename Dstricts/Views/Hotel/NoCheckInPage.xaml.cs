using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using ZXing.Net.Mobile.Forms;

namespace Dstricts.Views.Hotel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoCheckInPage : ContentPage
    {
        NoCheckInPageViewModel viewModel;
        ZXingScannerPage scanPage;
        public NoCheckInPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new NoCheckInPageViewModel(this.Navigation);
        }

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