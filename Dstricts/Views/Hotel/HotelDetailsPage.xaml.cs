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
			rr();
		}

		void rr()
		{
			List<Images> CardsImages = new List<Images>();
			CardsImages.Add(new Images() { URL = "https://www.gstatic.com/webp/gallery/2.webp" });
			CardsImages.Add(new Images() { URL = "https://www.gstatic.com/webp/gallery/4.webp" });
			CardsImages.Add(new Images() { URL = "https://www.gstatic.com/webp/gallery/5.webp" });
			CardsImages.Add(new Images() { URL = "https://www.gstatic.com/webp/gallery/2.webp" });
			cardCarouselView.ItemsSource = CardsImages;
		}
	}
}