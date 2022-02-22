using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Threading.Tasks;

namespace Dstricts.Views.BookService
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookServiceListPage : ContentPage
	{
		BookServiceListPageViewModel viewModel;
		public BookServiceListPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new BookServiceListPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.WellnessServiceInfoCountCommand.Execute(null);
		}

		private void OnViewAllButtonClicked(object sender, System.EventArgs e)
		{
			Button button = sender as Button;
			Helper.Helper.ServiceCategoryName = button.ClassId;
			viewModel.ViewAllWellnessCategoriesAndMenuCommand.Execute(null);
		}

		private async void OnDishImageButtonClicked(object sender, System.EventArgs e)
		{
			ImageButton imageButton = sender as ImageButton;
			Models.Menu menu = imageButton.BindingContext as Models.Menu;
			await GoToAddBookServiceToCartPage(menu);
		}

		private async void OnMenuInfoLayoutTapped(object sender, System.EventArgs e)
		{
			StackLayout stackLayout = sender as StackLayout;
			Models.Menu menu = stackLayout.BindingContext as Models.Menu;
			await GoToAddBookServiceToCartPage(menu);
		}
		
		private async Task GoToAddBookServiceToCartPage(Models.Menu menu)
		{
			Helper.Helper.SelectedServicesType = viewModel.SelectedServicesType;
			Helper.Helper.ServiceCategoryName = menu.ServiceCategoryName;
			Models.FittnessAndSpaSelectedCategoryResponse fittnessAndSpa = new Models.FittnessAndSpaSelectedCategoryResponse()
			{
				DishDetail = menu.DishDetail,
				DishImage = menu.DishImage,
				DishName = menu.DishName,
				DishPrice = menu.DishPrice,
				Id = menu.Id,
				OneShared = menu.OneShared,
				OneSharedType = menu.OneSharedType,
				RecurringEvent = menu.RecurringEvent,
			};
			await Navigation.PushAsync(new AddBookServiceToCartPage(fittnessAndSpa));
		}
	}
}