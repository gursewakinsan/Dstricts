using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using ZXing.Net.Mobile.Forms;
using System.Collections.Generic;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckedInListPage : ContentPage
	{
		CheckedInListPageViewModel viewModel;
		ZXingScannerPage scanPage;
		public CheckedInListPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CheckedInListPageViewModel(this.Navigation);
			rr();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		void rr()
		{
			List<DemoCards> demoCardsList = new List<DemoCards>();
			List<Images> CardsImages = new List<Images>();
			CardsImages.Add(new Images() { URL = "https://www.gstatic.com/webp/gallery/2.webp" });
			CardsImages.Add(new Images() { URL = "https://www.gstatic.com/webp/gallery/4.webp" });
			CardsImages.Add(new Images() { URL = "https://www.gstatic.com/webp/gallery/5.webp" });
			CardsImages.Add(new Images() { URL = "https://www.gstatic.com/webp/gallery/2.webp" });

			demoCardsList.Add(new DemoCards()
			{
				UserImage = "https://www.photodoozy.com/uploads/pak-army-handsome-boy-hd-stylish-dp-2020-photodoozy.jpg",
				CardsImage = CardsImages,
				ImgURL= "https://www.gstatic.com/webp/gallery/2.webp"
			});
			demoCardsList.Add(new DemoCards()
			{
				UserImage = "https://images.pexels.com/photos/1190208/pexels-photo-1190208.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
				CardsImage = CardsImages,
				ImgURL= "https://www.gstatic.com/webp/gallery/4.webp"
			});
			BindableLayout.SetItemsSource(cards, demoCardsList);
		}

		private async void OnHotelImageClicked(object sender, EventArgs e)
		{
			ImageButton image = sender as ImageButton;
			Models.CheckedInResponse checkedIn = image.BindingContext as Models.CheckedInResponse;
			if (checkedIn.Enc == 0) //Queue
				await Navigation.PushAsync(new Queue.UserQueueWaitingDetailPage(checkedIn.Id));
			else if (checkedIn.Enc == 1) //Hotel
			{
				Helper.Helper.IsRoomService = checkedIn.RoomService;
				Helper.Helper.HotelCheckedIn = checkedIn.QloudCheckOutId;
				viewModel.HotelDetailsCommand.Execute(null);
			}
			else if (checkedIn.Enc == 2) //Apartment
			{ 
			}
		}

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
	}
}
public class DemoCards
{
	public string UserImage { get; set; }
	public string ImgURL { get; set; }
	public List<Images> CardsImage { get; set; }
}
public class Images
{
	public string URL { get; set; }
}