using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.SearchHotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DishDetailsPage : ContentPage
	{
		DishDetailsPageViewModel viewModel;
		public DishDetailsPage (Models.Dish dish)
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new DishDetailsPageViewModel(this.Navigation);
			viewModel.DishDetailsInfo = dish;
		}
	}
}