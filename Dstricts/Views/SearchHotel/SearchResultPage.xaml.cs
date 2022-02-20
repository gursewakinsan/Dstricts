using System;
using System.Linq;
using Xamarin.Forms;
using Newtonsoft.Json;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Dstricts.Views.SearchHotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchResultPage : ContentPage
	{
		SearchResultPageViewModel viewModel;
		bool isLoadPage = false;
		public SearchResultPage()
		{
			isLoadPage = true;
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SearchResultPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.SearchCommand.Execute(null);
		}

		private async void OnSearchResultItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.SearchUserResponse response = e.Item as Models.SearchUserResponse;
			Helper.Helper.SelectResturantId = response.Id;
			listSearchResult.SelectedItem = null;
			if (Helper.Helper.SelectSearchType == 3)
				await Navigation.PushAsync(new SearchRestaurantDetailsPage());
			else if (Helper.Helper.SelectSearchType == 4)
			{
				Helper.Helper.WellnessName = response.Name;
				await Navigation.PushAsync(new FittnessAndSpa.SearchWellnessDetailsPage(response));
			}
		}

		private async void OnSearchSuggestionItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.SearchUserResponse search = e.Item as Models.SearchUserResponse;
			searchBar.Text = search.FirstName;
			viewModel.IsSearchSuggestion = false;
			((ListView)sender).SelectedItem = null;
			viewModel.SearchCommand.Execute(null);
			await NewMethod(search.FirstName);
		}

		private static async Task NewMethod(string firstName)
		{
			if (Application.Current.Properties.ContainsKey("AlreadySearchInfo"))
			{
				string searchDataJson = Application.Current.Properties["AlreadySearchInfo"].ToString();
				ObservableCollection<string> AlreadySearchData = JsonConvert.DeserializeObject<ObservableCollection<string>>(searchDataJson);

				if (!AlreadySearchData.Contains(firstName))
				{
					AlreadySearchData.Add(firstName);
					Application.Current.Properties.Remove("AlreadySearchInfo");
					string saveJson = JsonConvert.SerializeObject(AlreadySearchData);
					Application.Current.Properties.Add("AlreadySearchInfo", saveJson);
					await Application.Current.SavePropertiesAsync();
				}
			}
		}

		private async void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
		{
			var entry = (Controls.CustomEntry)sender;
			if (string.IsNullOrWhiteSpace(entry.Text))
			{
				if (iconClearSearchBar.IsVisible) iconClearSearchBar.IsVisible = false;
				return;
			}
			if (!iconClearSearchBar.IsVisible) iconClearSearchBar.IsVisible = true;
			
			if (isLoadPage)
			{
				isLoadPage = false;
				return;
			}

			viewModel.IsSearchSuggestion = true;
			if (entry.Text.Length == 3 || viewModel.SearchSuggestionList == null)
			{
				await viewModel.ExecuteSearchCommand();
			}
			listSearchSuggestion.BeginRefresh();
			try
			{
				if (viewModel.SearchSuggestionList == null)
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

		private void OnClearSearchBarTapped(object sender, EventArgs e)
		{
			iconClearSearchBar.IsVisible = false;
			searchBar.Text = string.Empty;
			viewModel.IsSearchSuggestion = false;
		}
	}
}