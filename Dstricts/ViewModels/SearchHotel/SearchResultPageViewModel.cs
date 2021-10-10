using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Dstricts.ViewModels
{
	public class SearchResultPageViewModel : BaseViewModel
	{
		#region Constructor.
		public SearchResultPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(async () => await ExecuteBackCommand()));
		}
		private async Task ExecuteBackCommand()
		{
			/*if (Application.Current.Properties.ContainsKey("AlreadySearchInfo"))
				Application.Current.Properties.Remove("AlreadySearchInfo");
			string searchDataJson = JsonConvert.SerializeObject(AlreadySearchData);
			Application.Current.Properties.Add("AlreadySearchInfo", searchDataJson);
			await Application.Current.SavePropertiesAsync();*/
			await Navigation.PopAsync();
		}
		#endregion

		#region Search Command.
		private ICommand searchCommand;
		public ICommand SearchCommand
		{
			get => searchCommand ?? (searchCommand = new Command(async() => await ExecuteSearchCommand()));
		}
		public async Task ExecuteSearchCommand()
		{
			if (string.IsNullOrWhiteSpace(SearchText)) return;
			else if (SearchText.Length > 2)
			{
				switch (Helper.Helper.SelectSearchType)
				{
					case 1:
						await ExecuteSearchHotelByUserCommand();
						break;
					case 2:
						await ExecuteSearchHotelByCompanyCommand();
						break;
					case 3:
						await ExecuteSearchHotelByEatAndDrinkCommand();
						break;
				}
			}
		}
		#endregion

		#region Search Hotel By User Command.
		private ICommand searchHotelByUserCommand;
		public ICommand SearchHotelByUserCommand
		{
			get => searchHotelByUserCommand ?? (searchHotelByUserCommand = new Command(async () => await ExecuteSearchHotelByUserCommand()));
		}
		private async Task ExecuteSearchHotelByUserCommand()
		{
			//DependencyService.Get<IProgressBar>().Show();
			ISearchService service = new SearchService();
			var response = await service.SearchUserAsync(new Models.SearchRequest()
			{
				Name = SearchText
			});

			if (response?.Count > 0)
			{
				if (IsSearchSuggestion)
				{
					if (SearchSuggestionList == null) SearchSuggestionList = new ObservableCollection<Models.SearchUserResponse>();
					SearchSuggestionList.Clear();
					SearchSuggestionList = new ObservableCollection<Models.SearchUserResponse>(response);
					IsSearchSuggestion = SearchSuggestionList.Count > 0 ? true : false;
				}
				else
				{
					if (SearchResult == null) SearchResult = new ObservableCollection<Models.SearchUserResponse>();
					SearchResult.Clear();
					SearchResult = new ObservableCollection<Models.SearchUserResponse>(response);
				}
			}
			//DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Search Hotel By Company Command.
		private ICommand searchHotelByCompanyCommand;
		public ICommand SearchHotelByCompanyCommand
		{
			get => searchHotelByCompanyCommand ?? (searchHotelByCompanyCommand = new Command(async () => await ExecuteSearchHotelByCompanyCommand()));
		}
		private async Task ExecuteSearchHotelByCompanyCommand()
		{
			//DependencyService.Get<IProgressBar>().Show();
			ISearchService service = new SearchService();
			var response = await service.SearchCompanyAsync(new Models.SearchRequest()
			{
				Name = SearchText
			});
			if (response?.Count > 0)
			{
				if (IsSearchSuggestion)
				{
					if (SearchSuggestionList == null) SearchSuggestionList = new ObservableCollection<Models.SearchUserResponse>();
					SearchSuggestionList.Clear();
					foreach (var item in response)
					{
						SearchSuggestionList.Add(new Models.SearchUserResponse()
						{
							Id = item.Id,
							FirstName = item.FirstName,
							Name = item.Name,
							PassportImage = item.PassportImage,
							UserImage = item.UserImage
						});
					}
					IsSearchSuggestion = SearchSuggestionList.Count > 0 ? true : false;
				}
				else
				{
					if (SearchResult == null) SearchResult = new ObservableCollection<Models.SearchUserResponse>();
					SearchResult.Clear();
					foreach (var item in response)
					{
						SearchResult.Add(new Models.SearchUserResponse()
						{
							Id = item.Id,
							FirstName = item.FirstName,
							Name = item.Name,
							PassportImage = item.PassportImage,
							UserImage = item.UserImage
						});
					}
				}
			}
			//DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Search Hotel By Eat & Drink Command.
		private ICommand searchHotelByEatAndDrinkCommand;
		public ICommand SearchHotelByEatAndDrinkCommand
		{
			get => searchHotelByEatAndDrinkCommand ?? (searchHotelByEatAndDrinkCommand = new Command(async () => await ExecuteSearchHotelByEatAndDrinkCommand()));
		}
		private async Task ExecuteSearchHotelByEatAndDrinkCommand()
		{
			//DependencyService.Get<IProgressBar>().Show();
			ISearchService service = new SearchService();
			var response = await service.SearchResturantAsync(new Models.SearchRequest()
			{
				Name = SearchText
			});
			if (response?.Count > 0)
			{
				if (IsSearchSuggestion)
				{
					if (SearchSuggestionList == null) SearchSuggestionList = new ObservableCollection<Models.SearchUserResponse>();
					SearchSuggestionList.Clear();
					foreach (var item in response)
					{
						SearchSuggestionList.Add(new Models.SearchUserResponse()
						{
							Id = item.Id,
							FirstName = item.FirstName,
							Name = item.Name,
							PassportImage = item.PassportImage,
							UserImage = item.UserImage
						});
					}
					IsSearchSuggestion = SearchSuggestionList.Count > 0 ? true : false;
				}
				else
				{
					if (SearchResult == null) SearchResult = new ObservableCollection<Models.SearchUserResponse>();
					SearchResult.Clear();
					foreach (var item in response)
					{
						SearchResult.Add(new Models.SearchUserResponse()
						{
							Id = item.Id,
							FirstName = item.FirstName,
							Name = item.Name,
							PassportImage = item.PassportImage,
							UserImage = item.UserImage
						});
					}
				}
			}
			//DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private string searchText = Helper.Helper.SelectSearchText;
		public string SearchText
		{
			get => searchText;
			set
			{
				searchText = value;
				OnPropertyChanged("SearchText");
			}
		}

		private ObservableCollection<Models.SearchUserResponse> searchResult;
		public ObservableCollection<Models.SearchUserResponse> SearchResult
		{
			get => searchResult;
			set
			{
				searchResult = value;
				OnPropertyChanged("SearchResult");
			}
		}

		private ObservableCollection<Models.SearchUserResponse> searchSuggestionList;
		public ObservableCollection<Models.SearchUserResponse> SearchSuggestionList
		{
			get => searchSuggestionList;
			set
			{
				searchSuggestionList = value;
				OnPropertyChanged("SearchSuggestionList");
			}
		}

		private bool isSearchSuggestion;
		public bool IsSearchSuggestion
		{
			get => isSearchSuggestion;
			set
			{
				isSearchSuggestion = value;
				OnPropertyChanged("IsSearchSuggestion");
			}
		}
		#endregion
	}
}