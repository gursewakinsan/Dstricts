using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.SearchHotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchResultPage : ContentPage
	{
		SearchResultPageViewModel viewModel;
		public SearchResultPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SearchResultPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.SearchCommand.Execute(null);
		}

		private void OnSearchResultItemTapped(object sender, ItemTappedEventArgs e)
		{
			listSearchResult.SelectedItem = null;
		}
	}
}