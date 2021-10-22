using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.BookTable
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookTablePage : ContentPage
	{
		BookTablePageViewModel viewModel;
		public BookTablePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new BookTablePageViewModel(this.Navigation);
		}
	}
}