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
				Id = Helper.Helper.HotelCheckedIn
			});

			//Resturants
			InhouseInfo inhouseResturantsInfo = new InhouseInfo()
			{
				CenterType= "Room Service",
				ImageUrl= "https://media.istockphoto.com/photos/beautiful-woman-laying-and-enjoying-breakfast-in-bed-picture-id1151357999?k=20&m=1151357999&s=612x612&w=0&h=SegUpGW4gDuhfuYyp_P5oIzz4Za4w9bk_uEIwwyrz5k="
			};
			if (response.InhouseResturants?.Count > 0)
			{
				foreach (var resturants in response.InhouseResturants)
					if (!string.IsNullOrWhiteSpace(resturants.CenterType))
						resturants.ImageUrl = "https://www.elitetraveler.com/wp-content/uploads/2007/02/Alain-Ducasse-scaled.jpg";
				response.InhouseResturants.Insert(0, inhouseResturantsInfo);
			}
			else
			{
				response.InhouseResturants = new List<InhouseInfo>();
				response.InhouseResturants.Add(inhouseResturantsInfo);
			}

			//Fittness
			InhouseInfo inhouseFittnessInfo = new InhouseInfo()
			{
				CenterType = "Fittness",
				ImageUrl = "https://ychef.files.bbci.co.uk/1376x774/p07ztf1q.jpg"
			};
			if (response.InhouseFittness?.Count > 0)
			{
				foreach (var fittness in response.InhouseFittness)
					if (!string.IsNullOrWhiteSpace(fittness.CenterType))
						fittness.ImageUrl = "https://d1heoihvzm7u4h.cloudfront.net/40d13e2df255a7bff04453dc1531cc416c8c443f_APRIL_banner_18.jpg";
				response.InhouseFittness.Insert(0, inhouseFittnessInfo);
			}
			else
			{
				response.InhouseFittness = new List<InhouseInfo>();
				response.InhouseFittness.Add(inhouseFittnessInfo);
			}

			HotelDetails = response;
			DependencyService.Get<IProgressBar>().Hide();
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
		public string EatAndDrinkText => $"Eat & Drink";
		#endregion
	}
}
