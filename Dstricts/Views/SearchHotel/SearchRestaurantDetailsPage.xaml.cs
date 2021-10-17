using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.SearchHotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchRestaurantDetailsPage : ContentPage
	{
		SearchRestaurantDetailsPageViewModel viewModel;
		public SearchRestaurantDetailsPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SearchRestaurantDetailsPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GetResturantInfobyIdCommand.Execute(null);
		}
	}
}