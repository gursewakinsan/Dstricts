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

		#region Add Amenities Item To Cart Command.
		private ICommand addAmenitiesItemToCartCommand;
		public ICommand AddAmenitiesItemToCartCommand
		{
			get => addAmenitiesItemToCartCommand ?? (addAmenitiesItemToCartCommand = new Command(async () => await ExecuteAddAmenitiesItemToCartCommand()));
		}
		private async Task ExecuteAddAmenitiesItemToCartCommand()
		{
			if (SelectedAmenitiesService.Quantity != Quantity)
			{
				SelectedAmenitiesService.Quantity = Quantity;
				DependencyService.Get<IProgressBar>().Show();
				IAmenitiesService service = new AmenitiesService();
				Models.OrderHotelAppAmenityRequest addAmenities = new Models.OrderHotelAppAmenityRequest()
				{
					AId = SelectedAmenitiesService.Enc,
					AName = SelectedAmenitiesService.AmenityName,
					Quantity = SelectedAmenitiesService.Quantity,
					UserId = Helper.Helper.LoggedInUserId,
					CheckId = Helper.Helper.HotelCheckedIn,
				};
				await service.OrderHotelAppAmenityAsync(addAmenities);

				if (SelectedAmenitiesService.Quantity > 0)
				{
					SelectedAmenitiesService.QuantityBg = Color.FromHex("#223426");
					SelectedAmenitiesService.QuantityText = Color.FromHex("#4FD471");
					SelectedAmenitiesService.CardBoarder = Color.FromHex("#6F70FB");
					SelectedAmenitiesService.CardBoarderOpacity = 10;
				}
				else
				{
					SelectedAmenitiesService.QuantityBg = Color.FromHex("#242A37");
					SelectedAmenitiesService.QuantityText = Color.FromHex("#6F70FB");
					SelectedAmenitiesService.CardBoarder = Color.FromHex("#E4E4E4");
					SelectedAmenitiesService.CardBoarderOpacity = 0.2;
				}
				SelectedAmenitiesService.CallBack.Invoke();
				DependencyService.Get<IProgressBar>().Hide();
			}
			await Navigation.PopPopupAsync();
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
