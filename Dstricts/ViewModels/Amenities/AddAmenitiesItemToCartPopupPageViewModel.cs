using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;

namespace Dstricts.ViewModels
{
	public class AddAmenitiesItemToCartPopupPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AddAmenitiesItemToCartPopupPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Decrease Amenities Item Count Command.
		private ICommand decreaseAmenitiesItemCountCommand;
		public ICommand DecreaseAmenitiesItemCountCommand
		{
			get => decreaseAmenitiesItemCountCommand ?? (decreaseAmenitiesItemCountCommand = new Command(() => ExecuteDecreaseAmenitiesItemCountCommand()));
		}
		private void ExecuteDecreaseAmenitiesItemCountCommand()
		{
			if (Quantity == 0) return;
			Quantity = Quantity - 1;
		}
		#endregion

		#region Increase Amenities Item Count Command.
		private ICommand increaseAmenitiesItemCountCommand;
		public ICommand IncreaseAmenitiesItemCountCommand
		{
			get => increaseAmenitiesItemCountCommand ?? (increaseAmenitiesItemCountCommand = new Command(() => ExecuteIncreaseAmenitiesItemCountCommand()));
		}
		private void ExecuteIncreaseAmenitiesItemCountCommand()
		{
			Quantity = Quantity + 1;
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
			/*if (SelectedDryCleaningService.DishQuantity != DishQuantity)
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
				SelectedDryCleaningService.CallBack.Invoke();
				DependencyService.Get<IProgressBar>().Hide();
			}
			await Navigation.PopPopupAsync();*/
		}
		#endregion

		#region Properties.
		private Models.AmenitiesResponse selectedAmenitiesService;
		public Models.AmenitiesResponse SelectedAmenitiesService
		{
			get => selectedAmenitiesService;
			set
			{
				selectedAmenitiesService = value;
				OnPropertyChanged("SelectedAmenitiesService");
			}
		}

		public int quantity;
		public int Quantity
		{
			get => quantity;
			set
			{
				quantity = value;
				OnPropertyChanged("Quantity");
			}
		}
		#endregion
	}
}
