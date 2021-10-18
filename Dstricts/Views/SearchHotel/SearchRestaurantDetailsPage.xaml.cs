using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.SearchHotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchRestaurantDetailsPage : ContentPage
	{
		#region Variables.
		SearchRestaurantDetailsPageViewModel viewModel;
		#endregion

		#region Constructor.
		public SearchRestaurantDetailsPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SearchRestaurantDetailsPageViewModel(this.Navigation);
		}
		#endregion

		#region On Appearing.
		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GetResturantInfobyIdCommand.Execute(null);
		}
		#endregion

		#region On Menu Item Tapped.
		private async void OnMenuItemTapped(object sender, System.EventArgs e)
		{
			StackLayout layout = sender as StackLayout;
			Models.ResturantServeInfoResponse resturant = layout.BindingContext as Models.ResturantServeInfoResponse;
			await Navigation.PushAsync(new ResturantServeBasedMenuPage(resturant));
		}
		#endregion

		#region On Serve Image Clicked.
		private async void OnServeImageClicked(object sender, System.EventArgs e)
		{
			ImageButton image = sender as ImageButton;
			Models.ResturantServeInfoResponse resturant = image.BindingContext as Models.ResturantServeInfoResponse;
			await Navigation.PushAsync(new ResturantServeBasedMenuPage(resturant));
		}
		#endregion
	}
}