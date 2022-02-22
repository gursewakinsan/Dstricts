using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.BookService
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddBookServiceToCartPage : ContentPage
	{
		AddBookServiceToCartPageViewModel viewModel;
		public AddBookServiceToCartPage(Models.FittnessAndSpaSelectedCategoryResponse fittnessAndSpaInfo)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AddBookServiceToCartPageViewModel(this.Navigation);
			viewModel.SelectedFittnessAndSpaInfo = fittnessAndSpaInfo;
		}
	}
}