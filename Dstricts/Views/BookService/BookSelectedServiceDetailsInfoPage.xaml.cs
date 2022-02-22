using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.BookService
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookSelectedServiceDetailsInfoPage : ContentPage
	{
		BookSelectedServiceDetailsInfoViewModels viewModel;
		public BookSelectedServiceDetailsInfoPage(int dishId)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new BookSelectedServiceDetailsInfoViewModels(this.Navigation);
			viewModel.DishId = dishId;
			viewModel.WellnessSelectedServiceInfoCommand.Execute(null);
		}
	}
}