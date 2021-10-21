using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.SearchHotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResturantServeBasedMenuPage : ContentPage
	{
		ResturantServeBasedMenuPageViewModel viewModel;
		public ResturantServeBasedMenuPage (Models.ResturantServeInfoResponse resturant)
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new ResturantServeBasedMenuPageViewModel(this.Navigation);
			viewModel.ResturantServeInfo = resturant;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.ResturantServeBasedMenuCommand.Execute(null);
		}

		private async void OnDishImageClicked(object sender, System.EventArgs e)
		{
			ImageButton image = sender as ImageButton;
			Models.Dish dish = image.BindingContext as Models.Dish;
			await Navigation.PushAsync(new DishDetailsPage(dish));
		}
	}
}