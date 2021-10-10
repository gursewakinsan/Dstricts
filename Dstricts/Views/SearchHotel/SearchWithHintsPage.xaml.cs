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

		private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
		{
			var entry = (Controls.CustomEntry)sender;
			if (string.IsNullOrWhiteSpace(entry.Text))
			{
				if (iconClearSearchBar.IsVisible) iconClearSearchBar.IsVisible = false;
				return;
			}
			if (!iconClearSearchBar.IsVisible) iconClearSearchBar.IsVisible = true;
			if (entry.Text.Length == 3)
			{
				viewModel.ExecuteSearchCommand();
			}
			viewModel.IsSearchSuggestion = true;
			listSearchSuggestion.BeginRefresh();
			try
			{
				if (viewModel.SearchSuggestionList== null)
					viewModel.SearchSuggestionList = new ObservableCollection<Models.SearchUserResponse>();

				var dataEmpty = viewModel.SearchSuggestionList.Where(i => i.Name.ToLower().Contains(e.NewTextValue.ToLower()));
				if (string.IsNullOrWhiteSpace(e.NewTextValue))
					viewModel.IsSearchSuggestion = false;
				else if (dataEmpty.Count() == 0)
					viewModel.IsSearchSuggestion = false;
				else
					listSearchSuggestion.ItemsSource = viewModel.SearchSuggestionList.Where(i => i.Name.ToLower().Contains(e.NewTextValue.ToLower()));
			}
			catch (Exception ex)
			{
				viewModel.IsSearchSuggestion = false;
			}
			listSearchSuggestion.EndRefresh();
		}
		private void OnSearchSuggestionItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.SearchUserResponse search = e.Item as Models.SearchUserResponse;
			searchBar.Text = search.FirstName;
			viewModel.IsSearchSuggestion = false;
			((ListView)sender).SelectedItem = null;
			viewModel.GoToSearchResultPageCommand.Execute(null);
		}

		private void OnCloseTapped(object sender, EventArgs e)
		{
			Label clear = sender as Label;
			string clearText = clear.BindingContext as string;
			viewModel.AlreadySearchData.Remove(clearText);
		}

		private void OnAlreadySearchItemTapped(object sender, ItemTappedEventArgs e)
		{
			string text = e.Item as string;
			searchBar.Text = text;
			((ListView)sender).SelectedItem = null;
			viewModel.GoToSearchResultPageCommand.Execute(null);
		}

		private void OnClearSearchBarTapped(object sender, EventArgs e)
		{
			iconClearSearchBar.IsVisible = false;
			searchBar.Text = string.Empty;
			viewModel.IsSearchSuggestion = false;
		}
	}
}