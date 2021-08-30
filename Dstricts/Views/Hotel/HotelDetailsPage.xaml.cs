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
			//rr();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.HotelCompleteInfoCommand.Execute(null);
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
	}
}
public class EatAndDrink
{
	public string Name { get; set; }
	public string URL { get; set; }
}