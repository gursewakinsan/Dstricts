using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HotelDetailsPage : ContentPage
	{
		HotelDetailsPageViewModel viewModel;
		public HotelDetailsPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new HotelDetailsPageViewModel(this.Navigation);
			//imgRoomService.Source = ImageSource.FromUri(new System.Uri("https://media.istockphoto.com/photos/beautiful-woman-laying-and-enjoying-breakfast-in-bed-picture-id1151357999?k=20&m=1151357999&s=612x612&w=0&h=SegUpGW4gDuhfuYyp_P5oIzz4Za4w9bk_uEIwwyrz5k="));
			//imgFittness.Source = ImageSource.FromUri(new System.Uri("https://ychef.files.bbci.co.uk/1376x774/p07ztf1q.jpg"));
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.HotelCompleteInfoCommand.Execute(null);
			lblEatDrink.Text = $"Eat & Drink";
			lblFitnessSpa.Text = "Fitness & Spa";

			imgRoom.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/4.png";
			imgBed.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/5.png";
			imgMedia.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/1.png";
			imgBathroom.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/7.png";

			viewModel.SelectedRoomServiceAppServesCommand.Execute(null);

			//BindRoomServiceInfo();
			BindEatDrinkAtTheHotelInfo();
			//BindFitnessSpaInfo();
		}

		void BindRoomServiceInfo()
		{
			int deviceWidth = App.ScreenWidth - 56;
			int w = deviceWidth * 42 / 100;
			int h = w * 97 / 100;

			List<abc> abcs = new List<abc>();
			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/8.png",
				Name = "Breakfast",
				Detail = "32 Item",
				ImgWidth = w,
				ImgHeight = h
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/9.png",
				Name = "Lunch",
				Detail = "15 Item",
				ImgWidth = w,
				ImgHeight = h
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/8.png",
				Name = "Breakfast",
				Detail = "32 Item",
				ImgWidth = w,
				ImgHeight = h
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/9.png",
				Name = "Lunch",
				Detail = "15 Item",
				ImgWidth = w,
				ImgHeight = h
			});
			BindableLayout.SetItemsSource(layoutRoomService, abcs);
		}

		void BindEatDrinkAtTheHotelInfo()
		{
			int deviceWidth = App.ScreenWidth - 56;
			int w = deviceWidth * 80 / 100;
			int h = w * 68 / 100;

			List<abc> abcs = new List<abc>();
			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/11.png",
				Name = "Restaurant 1",
				Detail = "32 Item",
				ImgWidth = w,
				ImgHeight = h
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/12.png",
				Name = "Restaurant 2",
				Detail = "15 Item",
				ImgWidth = w,
				ImgHeight = h
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/11.png",
				Name = "Restaurant 3",
				Detail = "32 Item",
				ImgWidth = w,
				ImgHeight = h
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/12.png",
				Name = "Restaurant 4",
				Detail = "15 Item",
				ImgWidth = w,
				ImgHeight = h
			});
			BindableLayout.SetItemsSource(layoutEatDrinkAtTheHotel, abcs);
		}

		void BindFitnessSpaInfo()
		{
			int deviceWidth = App.ScreenWidth - 56;
			int w = deviceWidth * 80 / 100;
			int h = w * 68 / 100;

			List<abc> abcs = new List<abc>();
			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/13.png",
				Name = "Gym",
				Detail = "32 Item",
				ImgWidth = w,
				ImgHeight = h
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/14.png",
				Name = "Spa",
				Detail = "15 Item",
				ImgWidth = w,
				ImgHeight = h
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/13.png",
				Name = "Gym",
				Detail = "32 Item",
				ImgWidth = w,
				ImgHeight = h
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/14.png",
				Name = "Spa",
				Detail = "15 Item",
				ImgWidth = w,
				ImgHeight = h
			});
			BindableLayout.SetItemsSource(layoutFitnessSpa, abcs);
		}

		void rr()
		{
			/*List<Images> CardsImages = new List<Images>();
			CardsImages.Add(new Images() { URL = "https://www.gstatic.com/webp/gallery/2.webp" });
			CardsImages.Add(new Images() { URL = "https://www.gstatic.com/webp/gallery/4.webp" });
			CardsImages.Add(new Images() { URL = "https://www.gstatic.com/webp/gallery/5.webp" });
			CardsImages.Add(new Images() { URL = "https://www.gstatic.com/webp/gallery/2.webp" });
			cardCarouselView.ItemsSource = CardsImages;

			List<EatAndDrink> eatAndDrink = new List<EatAndDrink>();
			eatAndDrink.Add(new EatAndDrink() { Name = "Breakfast", URL = "https://www.verywellhealth.com/thmb/gF-I-Kf6MyQfEbp1Q9mpXtcENxM=/2880x1920/filters:fill(87E3EF,1)/best-breakfast-choices-and-diabetes-1087468-primary-recirc-603a39fe3b10439eaa9a0cf80a09eec2.jpg" });
			eatAndDrink.Add(new EatAndDrink() { Name = "Asia Kitchen", URL = "https://b.zmtcdn.com/data/pictures/5/18217475/74f000f5b38ccbc09b920913ad4b71d4.jpg" });
			BindableLayout.SetItemsSource(layoutEatAndDrink, eatAndDrink);

			List<EatAndDrink> listWellness = new List<EatAndDrink>();
			listWellness.Add(new EatAndDrink() { Name = "Fitness ", URL = "https://c4.wallpaperflare.com/wallpaper/630/144/936/girl-model-blonde-sports-wallpaper-preview.jpg" });
			listWellness.Add(new EatAndDrink() { Name = "Spa", URL = "https://m.economictimes.com/thumb/msid-67344533,width-1200,height-900,resizemode-4,imgsize-552643/spa-wellness-massage-gettyimages-875640820.jpg" });
			BindableLayout.SetItemsSource(layoutWellness, listWellness);*/
		}

		private void OnMoreTapped(object sender, System.EventArgs e)
		{
			//lblMoreInfo.IsVisible = false;
			//lblLessInfo.IsVisible = true;
		}
		
		private void OnLessTapped(object sender, System.EventArgs e)
		{
			//lblLessInfo.IsVisible = false;
			//slblMoreInfo.IsVisible = true;
		}

		private void OnEatDrinkClicked(object sender, System.EventArgs e)
		{
			viewModel.RoomAndFoodServiceCommand.Execute(null);
		}

		private async void OnRoomServiceImageClicked(object sender, System.EventArgs e)
		{
			ImageButton imageButton = sender as ImageButton;
			var selectedRoomService = imageButton.BindingContext as Models.SelectedRoomServiceAppServesResponse;
			foreach (var item in viewModel.SelectedRoomServiceAppServesInfo)
			{
				if (item.ServeType.Equals(selectedRoomService.ServeType))
				{
					item.IsSelectedRoomService = true;
					item.SelectedRoomServiceBg = Color.FromHex("#6263ED");
				}
				else
				{
					item.IsSelectedRoomService = false;
					item.SelectedRoomServiceBg = Color.FromHex("#2A2A31");
				}
			}
			await Navigation.PushAsync(new SelectedRoomServiceDetailPage(viewModel.SelectedRoomServiceAppServesInfo));
		}

		private async void OnLaundryServiceImageClicked(object sender, System.EventArgs e)
		{
			ImageButton imageButton = sender as ImageButton;
			var selectedLaundryService = imageButton.BindingContext as Models.SelectedLaundaryCategoriesResponse;
			foreach (var item in viewModel.LaundryServiceInfo)
			{
				if (item.CategoryId.Equals(selectedLaundryService.CategoryId))
				{
					item.IsSelectedRoomService = true;
					item.SelectedRoomServiceBg = Color.FromHex("#6263ED");
				}
				else
				{
					item.IsSelectedRoomService = false;
					item.SelectedRoomServiceBg = Color.FromHex("#2A2A31");
				}
			}
			await Navigation.PushAsync(new Laundry.LaundryServicePage(viewModel.LaundryServiceInfo));
		}

		private void OnFitnessAndSpaImageClicked(object sender, System.EventArgs e)
		{
			ImageButton button = sender as ImageButton;
			InhouseFittnessInfo info = button.BindingContext as InhouseFittnessInfo;
			Helper.Helper.WellnessId = info.Id;
			Helper.Helper.WellnessName = info.CenterName;
			viewModel.GoToFittnessAndSpaDetailsPageCommand.Execute(null);
		}

		private async void OnVenuesImageClicked(object sender, System.EventArgs e)
		{
			ImageButton button = sender as ImageButton;
			await Navigation.PushAsync(new Venues.VenueInfomationDetailPage(System.Convert.ToInt32(button.ClassId)));
		}
	}
}
public class EatAndDrink
{
	public string Name { get; set; }
	public string URL { get; set; }
}