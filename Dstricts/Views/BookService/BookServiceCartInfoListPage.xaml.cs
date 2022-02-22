using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;

namespace Dstricts.Views.BookService
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookServiceCartInfoListPage : ContentPage
	{
		BookServiceCartInfoListPageViewModel viewModel;
		public BookServiceCartInfoListPage(List<Models.AddServiceToCartAppResponse> addServices)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new BookServiceCartInfoListPageViewModel(this.Navigation);
			viewModel.AddedServiceToCartList = new System.Collections.ObjectModel.ObservableCollection<Models.AddServiceToCartAppResponse>(addServices);
		}

		private void OnMinusBoxTapped(object sender, System.EventArgs e)
		{
			Label label = sender as Label;
			Models.AddServiceToCartAppResponse remove = label.BindingContext as Models.AddServiceToCartAppResponse;
			viewModel.UpdateWellnessCartItemCommand.Execute(remove);
		}
	}
}