using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class SearchHotelByTypeViewModel : BaseViewModel
	{
		#region Constructor.
		public SearchHotelByTypeViewModel(INavigation navigation)
		{
			Navigation = navigation;
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
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		public string EatAndDrink => $"Eat & Drink";
		public string SearchText { get; set; } = "aa";
		#endregion
	}
}
