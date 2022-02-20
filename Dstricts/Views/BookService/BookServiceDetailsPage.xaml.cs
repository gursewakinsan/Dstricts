using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.BookService
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookServiceDetailsPage : ContentPage
	{
		BookServiceDetailsPageViewModel viewModel;
		public BookServiceDetailsPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new BookServiceDetailsPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.SelectedWellnessCategoriesCommand.Execute(null);
		}

		private void OnFittnessAndSpaCategoryClicked(object sender, System.EventArgs e)
		{
			Button button = sender as Button;
			viewModel.BookableServiceId = System.Convert.ToInt32(button.ClassId);
			foreach (var item in viewModel.FittnessAndSpaCategoryList)
			{
				if (item.Id.Equals(viewModel.BookableServiceId))
					item.ButtonBg = Color.FromHex("#6263ED");
				else
					item.ButtonBg = Color.FromHex("#2A2A31");
			}
			viewModel.SelectedWellnessBookingAppMenuCommand.Execute(null);
		}

		private async void OnDishImageClicked(object sender, System.EventArgs e)
		{
			/*ImageButton image = sender as ImageButton;
			Models.FittnessAndSpaSelectedCategoryResponse fittnessAndSpa = image.BindingContext as Models.FittnessAndSpaSelectedCategoryResponse;
			if (fittnessAndSpa.OneShared == 2 && fittnessAndSpa.OneSharedType == 1)
				await Navigation.PushAsync(new WellnessSelectedServiceInfoPage(fittnessAndSpa.Id));
			else
				await Navigation.PushAsync(new AddServiceToCartAppPage(fittnessAndSpa));*/
		}

		private async void OnDishNameTapped(object sender, System.EventArgs e)
		{
			/*StackLayout layout = sender as StackLayout;
			Models.FittnessAndSpaSelectedCategoryResponse fittnessAndSpa = layout.BindingContext as Models.FittnessAndSpaSelectedCategoryResponse;
			if (fittnessAndSpa.OneShared == 2 && fittnessAndSpa.OneSharedType == 1)
				await Navigation.PushAsync(new WellnessSelectedServiceInfoPage(fittnessAndSpa.Id));
			else
				await Navigation.PushAsync(new AddServiceToCartAppPage(fittnessAndSpa));*/
		}

		private async void OnFittnessAndSpaTapped(object sender, System.EventArgs e)
		{
			/*Grid grid = sender as Grid;
			Models.FittnessAndSpaSelectedCategoryResponse fittnessAndSpa = grid.BindingContext as Models.FittnessAndSpaSelectedCategoryResponse;
			if (fittnessAndSpa.OneShared == 2 && fittnessAndSpa.OneSharedType == 1)
				await Navigation.PushAsync(new WellnessSelectedServiceInfoPage(fittnessAndSpa.Id));
			else
				await Navigation.PushAsync(new AddServiceToCartAppPage(fittnessAndSpa));*/
		}
	}
}