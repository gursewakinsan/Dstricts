using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;

namespace Dstricts.ViewModels
{
	public class AddLaundryItemToCartPopupPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AddLaundryItemToCartPopupPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Decrease Laundry Item Count Command.
		private ICommand decreaseLaundryItemCountCommand;
		public ICommand DecreaseLaundryItemCountCommand
		{
			get => decreaseLaundryItemCountCommand ?? (decreaseLaundryItemCountCommand = new Command(() => ExecuteDecreaseLaundryItemCountCommand()));
		}
		private void ExecuteDecreaseLaundryItemCountCommand()
		{
			if (DishQuantity == 0) return;
			DishQuantity = DishQuantity - 1;
		}
		#endregion

		#region Increase Laundry Item Count Command.
		private ICommand increaseLaundryItemCountCommand;
		public ICommand IncreaseLaundryItemCountCommand
		{
			get => increaseLaundryItemCountCommand ?? (increaseLaundryItemCountCommand = new Command(() => ExecuteIncreaseLaundryItemCountCommand()));
		}
		private void ExecuteIncreaseLaundryItemCountCommand()
		{
			DishQuantity = DishQuantity + 1;
		}
		#endregion

		#region Add Dry Cleaning Item To Cart Command.
		private ICommand addDryCleaningItemToCartCommand;
		public ICommand AddDryCleaningItemToCartCommand
		{
			get => addDryCleaningItemToCartCommand ?? (addDryCleaningItemToCartCommand = new Command(async () => await ExecuteAddDryCleaningItemToCartCommand()));
		}
		private async Task ExecuteAddDryCleaningItemToCartCommand()
		{
			if (SelectedDryCleaningService.DishQuantity != DishQuantity)
			{
				SelectedDryCleaningService.DishQuantity = DishQuantity;
				DependencyService.Get<IProgressBar>().Show();
				ILaundryService service = new LaundryService();
				Models.AddDryCleaningItemToCartRequest dryCleaningItem = new Models.AddDryCleaningItemToCartRequest()
				{
					CheckId = Helper.Helper.HotelCheckedIn,
					ItemId = SelectedDryCleaningService.Id,
					DishName = SelectedDryCleaningService.DishName,
					DishDetail = SelectedDryCleaningService.DishDetail,
					DishImage = string.Empty,
					DishPrice = SelectedDryCleaningService.DishPrice,
					Quantity = SelectedDryCleaningService.DishQuantity,
					ServiceType = SelectedDryCleaningService.ServeType
				};
				await service.AddDryCleaningItemToCartAsync(dryCleaningItem);

				if (SelectedDryCleaningService.DishQuantity > 0)
				{
					SelectedDryCleaningService.DishQuantityBg = Color.FromHex("#223426");
					SelectedDryCleaningService.DishQuantityText = Color.FromHex("#4FD471");
					SelectedDryCleaningService.CardBoarder = Color.FromHex("#6F70FB");
					SelectedDryCleaningService.CardBoarderOpacity = 10;
				}
				else
				{
					SelectedDryCleaningService.DishQuantityBg = Color.FromHex("#242A37");
					SelectedDryCleaningService.DishQuantityText = Color.FromHex("#6F70FB");
					SelectedDryCleaningService.CardBoarder = Color.FromHex("#E4E4E4");
					SelectedDryCleaningService.CardBoarderOpacity = 0.2;
				}
				DependencyService.Get<IProgressBar>().Hide();
			}
			await Navigation.PopPopupAsync();
		}
		#endregion

		#region Properties.
		private Models.SelectedDryCleaningServeBasedAppMenuResponse selectedDryCleaningService;
		public Models.SelectedDryCleaningServeBasedAppMenuResponse SelectedDryCleaningService
		{
			get => selectedDryCleaningService;
			set
			{
				selectedDryCleaningService = value;
				OnPropertyChanged("SelectedDryCleaningService");
			}
		}

		public int dishQuantity;
		public int DishQuantity
		{
			get => dishQuantity;
			set
			{
				dishQuantity = value;
				OnPropertyChanged("DishQuantity");
			}
		}
		#endregion
	}
}
