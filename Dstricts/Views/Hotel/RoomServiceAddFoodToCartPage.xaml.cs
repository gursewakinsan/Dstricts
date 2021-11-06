using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoomServiceAddFoodToCartPage : ContentPage
	{
		RoomServiceAddFoodToCartViewModel viewModel;
		public RoomServiceAddFoodToCartPage (Models.Category category)
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new RoomServiceAddFoodToCartViewModel(this.Navigation);
			viewModel.SelectedFoodCategory = category;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			imgRecommendation.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/1.png";
		}
	}
}