using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.ObjectModel;

namespace Dstricts.Views.SearchHotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchWithHintsPage : ContentPage
	{
		SearchWithHintsPageViewModel viewModel;
		public SearchWithHintsPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SearchWithHintsPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GetAlreadySearchDataCommand.Execute(null);
		}

		private async void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
		{
			var entry = (Controls.CustomEntry)sender;
			if (entry.Text.Length == 3)
			{
				viewModel.ExecuteSearchCommand();
			}
			viewModel.IsSearchResult = true;
			countryListView.BeginRefresh();
			try
			{
				if (viewModel.SearchResult == null)
					viewModel.SearchResult = new ObservableCollection<Models.SearchUserResponse>();

				var dataEmpty = viewModel.SearchResult.Where(i => i.Name.ToLower().Contains(e.NewTextValue.ToLower()));
				if (string.IsNullOrWhiteSpace(e.NewTextValue))
					viewModel.IsSearchResult = false;
				else if (dataEmpty.Count() == 0)
					viewModel.IsSearchResult = false;
				else
					countryListView.ItemsSource = viewModel.SearchResult.Where(i => i.Name.ToLower().Contains(e.NewTextValue.ToLower()));
			}
			catch (Exception ex)
			{
				viewModel.IsSearchResult = false;
			}
			countryListView.EndRefresh();
		}
		private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.SearchUserResponse search = e.Item as Models.SearchUserResponse;
			searchBar.Text = search.Name;
			viewModel.IsSearchResult = false;
			((ListView)sender).SelectedItem = null;
			viewModel.GoToSearchResultPageCommand.Execute(null);
		}

		private void OnCloseTapped(object sender, EventArgs e)
		{
			Label clear = sender as Label;
			string clearText = clear.BindingContext as string;
			viewModel.AlreadySearchData.Remove(clearText);
		}
	}
}