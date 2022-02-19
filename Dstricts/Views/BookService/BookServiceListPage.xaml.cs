using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

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
	}
}