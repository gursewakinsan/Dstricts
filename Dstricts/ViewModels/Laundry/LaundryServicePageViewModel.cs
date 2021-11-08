using System.Linq;
using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dstricts.ViewModels
{
	public class LaundryServicePageViewModel : BaseViewModel
	{
		#region Constructor.
		public LaundryServicePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Selected Dry Cleaning Serve Based App Menu Command.
		private ICommand selectedDryCleaningServeBasedAppMenuCommand;
		public ICommand SelectedDryCleaningServeBasedAppMenuCommand
		{
			get => selectedDryCleaningServeBasedAppMenuCommand ?? (selectedDryCleaningServeBasedAppMenuCommand = new Command(async () => await ExecuteSelectedDryCleaningServeBasedAppMenuCommand()));
		}
		private async Task ExecuteSelectedDryCleaningServeBasedAppMenuCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ILaundryService service = new LaundryService();
			var selectedLaundryService = LaundryServiceList.FirstOrDefault(x => x.IsSelectedRoomService);
			var response = await service.SelectedDryCleaningServeBasedAppMenuAsync(new Models.SelectedDryCleaningServeBasedAppMenuRequest()
			{
				Id = Helper.Helper.HotelCheckedIn,
				CategoryId = selectedLaundryService.CategoryId
			});

			List<Models.SelectedDryCleaningServeBasedAppMenuResponse> ss = new List<Models.SelectedDryCleaningServeBasedAppMenuResponse>(); 
			for (int i = 0; i < 10; i++)
			{
				ss.Add(response[0]);
			}
			foreach (var item in ss)
			{
				if (item.DishQuantity > 0)
				{
					item.DishQuantityBg = Color.FromHex("#223426");
					item.DishQuantityText = Color.FromHex("#4FD471");
					item.CardBoarder = Color.FromHex("#6F70FB");
					item.CardBoarderOpacity = 10;
				}
				else
				{
					item.DishQuantityBg = Color.FromHex("#242A37");
					item.DishQuantityText = Color.FromHex("#6F70FB");
					item.CardBoarder = Color.FromHex("#E4E4E4");
					item.CardBoarderOpacity = 0.2;
				}
			}
			SelectedDryCleaningServeList = new ObservableCollection<Models.SelectedDryCleaningServeBasedAppMenuResponse>(ss);

			/*ICartService cartService = new CartService();
			int cartServiceResponse = await cartService.CartItemCountAsync(new Models.CartItemCountRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn
			});
			IsProceedToCheckOut = cartServiceResponse > 0 ? true : false;*/
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.SelectedDryCleaningServeBasedAppMenuResponse> selectedDryCleaningServeList;
		public ObservableCollection<Models.SelectedDryCleaningServeBasedAppMenuResponse> SelectedDryCleaningServeList
		{
			get => selectedDryCleaningServeList;
			set
			{
				selectedDryCleaningServeList = value;
				OnPropertyChanged("SelectedDryCleaningServeList");
			}
		}

		private List<Models.SelectedLaundaryCategoriesResponse> laundryServiceList;
		public List<Models.SelectedLaundaryCategoriesResponse> LaundryServiceList
		{
			get => laundryServiceList;
			set
			{
				laundryServiceList = value;
				OnPropertyChanged("LaundryServiceList");
			}
		}

		private Models.HotelCompleteInfoResponse hotelDetails = Helper.Helper.HotelDetails;
		public Models.HotelCompleteInfoResponse HotelDetails
		{
			get => hotelDetails;
			set
			{
				hotelDetails = value;
				OnPropertyChanged("HotelDetails");
			}
		}
		#endregion
	}
}
