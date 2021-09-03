using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class HotelDetailsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public HotelDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Hotel Complete Info Command.
		private ICommand hotelCompleteInfoCommand;
		public ICommand HotelCompleteInfoCommand
		{
			get => hotelCompleteInfoCommand ?? (hotelCompleteInfoCommand = new Command(async () => await ExecuteHotelCompleteInfoCommand()));
		}
		private async Task ExecuteHotelCompleteInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			Models.HotelCompleteInfoResponse response = await service.HotelCompleteInfoAsync(new Models.HotelCompleteInfoRequest()
			{
				Id =Helper.Helper.HotelCheckedIn
			});

			//Resturants
			if (response.InhouseResturants?.Count > 0)
			{
				IsInhouseResturantsList = true;
				InhouseResturantsInfo inhouseResturantsInfo = new InhouseResturantsInfo()
				{
					ResturantType = "Room Service",
					ImageUrl = "https://media.istockphoto.com/photos/beautiful-woman-laying-and-enjoying-breakfast-in-bed-picture-id1151357999?k=20&m=1151357999&s=612x612&w=0&h=SegUpGW4gDuhfuYyp_P5oIzz4Za4w9bk_uEIwwyrz5k="
				};
				foreach (var resturants in response.InhouseResturants)
					if (!string.IsNullOrWhiteSpace(resturants.ResturantType))
						resturants.ImageUrl = "https://www.elitetraveler.com/wp-content/uploads/2007/02/Alain-Ducasse-scaled.jpg";
				response.InhouseResturants.Insert(0, inhouseResturantsInfo);
			}
			else
				IsInhouseResturantsList = false;

			//Fittness
			if (response.InhouseFittness?.Count > 0)
			{
				IsInhouseFittnessList = true;
				InhouseFittnessInfo inhouseFittnessInfo = new InhouseFittnessInfo()
				{
					CenterType = "Fittness",
					ImageUrl = "https://ychef.files.bbci.co.uk/1376x774/p07ztf1q.jpg"
				};
				foreach (var fittness in response.InhouseFittness)
					if (!string.IsNullOrWhiteSpace(fittness.CenterType))
						fittness.ImageUrl = "https://d1heoihvzm7u4h.cloudfront.net/40d13e2df255a7bff04453dc1531cc416c8c443f_APRIL_banner_18.jpg";
				response.InhouseFittness.Insert(0, inhouseFittnessInfo);
			}
			else
				IsInhouseFittnessList = false;
			HotelDetails = response;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Room And Food Service Command.
		private ICommand roomAndFoodServiceCommand;
		public ICommand RoomAndFoodServiceCommand
		{
			get => roomAndFoodServiceCommand ?? (roomAndFoodServiceCommand = new Command(async () => await ExecuteRoomAndFoodServiceCommand()));
		}
		private async Task ExecuteRoomAndFoodServiceCommand()
		{
			if (Helper.Helper.IsRoomService)
			{
				DependencyService.Get<IProgressBar>().Show();
				Helper.Helper.HotelDetails = HotelDetails;
				await Navigation.PushAsync(new Views.Hotel.RoomServiceMenuPage());
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		private Models.HotelCompleteInfoResponse hotelDetails;
		public Models.HotelCompleteInfoResponse HotelDetails
		{
			get => hotelDetails;
			set
			{
				hotelDetails = value;
				OnPropertyChanged("HotelDetails");
			}
		}

		private bool isInhouseResturantsList = false;
		public bool IsInhouseResturantsList
		{
			get => isInhouseResturantsList;
			set
			{
				isInhouseResturantsList = value;
				OnPropertyChanged("IsInhouseResturantsList");
			}
		}

		private bool isInhouseFittnessList = false;
		public bool IsInhouseFittnessList
		{
			get => isInhouseFittnessList;
			set
			{
				isInhouseFittnessList = value;
				OnPropertyChanged("IsInhouseFittnessList");
			}
		}
		public string EatAndDrinkText => $"Eat & Drink";
		#endregion
	}
}

