using Xamarin.Forms;
using Newtonsoft.Json;
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
			get => searchCommand ?? (searchCommand = new Command(() => ExecuteSearchCommand()));
		}
		public void ExecuteSearchCommand()
		{
			if (string.IsNullOrWhiteSpace(SearchText)) return;
			else if (SearchText.Length > 2)
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
			DependencyService.Get<IProgressBar>().Show();
			ISearchService service = new SearchService();
			var response = await service.SearchUserAsync(new Models.SearchRequest()
			{
				Name = SearchText
			});

			if (response?.Count > 0)
			{
				if (SearchResult == null) SearchResult = new ObservableCollection<Models.SearchUserResponse>();
				SearchResult.Clear();
				SearchResult = new ObservableCollection<Models.SearchUserResponse>(response);
			}
			IsSearchResult = SearchResult?.Count > 0 ? true : false;
			DependencyService.Get<IProgressBar>().Hide();
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
			DependencyService.Get<IProgressBar>().Show();
			ISearchService service = new SearchService();
			var response = await service.SearchCompanyAsync(new Models.SearchRequest()
			{
				Name = SearchText
			});
			if (response?.Count > 0)
			{
				if (SearchResult == null) SearchResult = new ObservableCollection<Models.SearchUserResponse>();
				SearchResult.Clear();
				foreach (var item in response)
				{
					SearchResult.Add(new Models.SearchUserResponse()
					{
						Id = item.Id,
						Name = item.Name,
						PassportImage = item.PassportImage,
						UserImage = item.UserImage
					});
				}
			}
			IsSearchResult = SearchResult?.Count > 0 ? true : false;
			DependencyService.Get<IProgressBar>().Hide();
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
			DependencyService.Get<IProgressBar>().Show();
			ISearchService service = new SearchService();
			var response = await service.SearchResturantAsync(new Models.SearchRequest()
			{
				Name = SearchText
			});
			if (response?.Count > 0)
			{
				if (SearchResult == null) SearchResult = new ObservableCollection<Models.SearchUserResponse>();
				SearchResult.Clear();
				foreach (var item in response)
				{
					SearchResult.Add(new Models.SearchUserResponse()
					{
						Id = item.Id,
						Name = item.Name,
						PassportImage = item.PassportImage,
						UserImage = item.UserImage
					});
				}
			}
			IsSearchResult = SearchResult?.Count > 0 ? true : false;
			DependencyService.Get<IProgressBar>().Hide();
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

		private bool isSearchResult;
		public bool IsSearchResult
		{
			get => isSearchResult;
			set
			{
				isSearchResult = value;
				OnPropertyChanged("IsSearchResult");
			}
		}
		#endregion
	}
}