using Xamarin.Forms;
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
			Helper.Helper.SelectSearchType = 1;
			await Navigation.PushAsync(new Views.SearchHotel.SearchWithHintsPage());
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
			Helper.Helper.SelectSearchType = 2;
			await Navigation.PushAsync(new Views.SearchHotel.SearchWithHintsPage());
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
			Helper.Helper.SelectSearchType = 3;
			await Navigation.PushAsync(new Views.SearchHotel.SearchWithHintsPage());
		}
		#endregion

		#region Properties.
		public string EatAndDrink => $"Eat & Drink";
		#endregion
	}
}
