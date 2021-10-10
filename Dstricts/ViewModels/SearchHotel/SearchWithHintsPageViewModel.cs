using Xamarin.Forms;
using Newtonsoft.Json;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Dstricts.ViewModels
{
	public class SearchWithHintsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public SearchWithHintsPageViewModel(INavigation navigation)
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
			if (Application.Current.Properties.ContainsKey("AlreadySearchInfo"))
				Application.Current.Properties.Remove("AlreadySearchInfo");
			string searchDataJson = JsonConvert.SerializeObject(AlreadySearchData);
			Application.Current.Properties.Add("AlreadySearchInfo", searchDataJson);
			await Application.Current.SavePropertiesAsync();
			await Navigation.PopAsync();
		}
		#endregion

		#region Search Command.
		private ICommand searchCommand;
		public ICommand SearchCommand
		{
			get => searchCommand ?? (searchCommand = new Command(() => ExecuteSearchCommand()));
		}
		public void ExecuteSearchCommand()
		{
			if (string.IsNullOrWhiteSpace(SearchText)) return;
			else if (SearchText.Length == 3)
			{
				switch (Helper.Helper.SelectSearchType)
				{
					case 1:
						SearchHotelByUserCommand.Execute(null);
						break;
					case 2:
						SearchHotelByCompanyCommand.Execute(null);
						break;
					case 3:
						SearchHotelByEatAndDrinkCommand.Execute(null);
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
				SearchSuggestionList = new ObservableCollection<Models.SearchUserResponse>(response);
			IsSearchSuggestion = SearchSuggestionList.Count > 0 ? true : false;
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
				foreach (var item in response)
				{
					SearchSuggestionList.Add(new Models.SearchUserResponse()
					{
						Id = item.Id,
						FirstName = item.FirstName,
						Name = item.Name,
						PassportImage = item.PassportImage,
						UserImage = item.UserImage
					}); ;
				}
			}
			IsSearchSuggestion = SearchSuggestionList.Count > 0 ? true : false;
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
			}
			IsSearchSuggestion = SearchSuggestionList.Count > 0 ? true : false;
			//DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Go To Search Result Page Command.
		private ICommand goToSearchResultPageCommand;
		public ICommand GoToSearchResultPageCommand
		{
			get => goToSearchResultPageCommand ?? (goToSearchResultPageCommand = new Command(async () => await ExecuteGoToSearchResultPageCommand()));
		}
		private async Task ExecuteGoToSearchResultPageCommand()
		{
			if (string.IsNullOrWhiteSpace(SearchText) || SearchText.Length < 3) return;
			IsSearchSuggestion = false;
			DependencyService.Get<IProgressBar>().Show();
			if (AlreadySearchData == null) AlreadySearchData = new ObservableCollection<string>();
			if (!AlreadySearchData.Contains(SearchText))
			{
				AlreadySearchData.Add(SearchText);
				if (Application.Current.Properties.ContainsKey("AlreadySearchInfo"))
					Application.Current.Properties.Remove("AlreadySearchInfo");
				string searchDataJson = JsonConvert.SerializeObject(AlreadySearchData);
				Application.Current.Properties.Add("AlreadySearchInfo", searchDataJson);
				await Application.Current.SavePropertiesAsync();
			}
			Helper.Helper.SelectSearchText = SearchText;
			SearchText = string.Empty;
			await Navigation.PushAsync(new Views.SearchHotel.SearchResultPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Get Already Search Data Command.
		private ICommand getAlreadySearchDataCommand;
		public ICommand GetAlreadySearchDataCommand
		{
			get => getAlreadySearchDataCommand ?? (getAlreadySearchDataCommand = new Command(() => ExecuteGetAlreadySearchDataCommand()));
		}
		private void ExecuteGetAlreadySearchDataCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			if (Application.Current.Properties.ContainsKey("AlreadySearchInfo"))
			{
				string searchDataJson = Application.Current.Properties["AlreadySearchInfo"].ToString();
				AlreadySearchData = JsonConvert.DeserializeObject<ObservableCollection<string>>(searchDataJson);
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private string searchText;
		public string SearchText
		{
			get => searchText;
			set
			{
				searchText = value;
				OnPropertyChanged("SearchText");
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

		private ObservableCollection<string> alreadySearchData;
		public ObservableCollection<string> AlreadySearchData
		{
			get => alreadySearchData;
			set
			{
				alreadySearchData = value;
				OnPropertyChanged("AlreadySearchData");
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
