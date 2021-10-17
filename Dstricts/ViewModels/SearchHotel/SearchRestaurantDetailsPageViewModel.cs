using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class SearchRestaurantDetailsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public SearchRestaurantDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			HotelImagesInfo = new List<HotelImages>();
			HotelImagesInfo.Add(new HotelImages() { ImageUrl = "https://img.etimg.com/thumb/width-1200,height-900,imgsize-179297,resizemode-1,msid-77220757/industry/services/hotels-/-restaurants/indian-hotel-sector-will-collapse-if-not-supported-by-the-govt-and-rbi-hai.jpg" });
			HotelImagesInfo.Add(new HotelImages() { ImageUrl = "https://www.mayfairhotels.com/img/home_banner/Mayfair_Waves.jpg" });
			HotelImagesInfo.Add(new HotelImages() { ImageUrl = "https://images.financialexpress.com/2020/09/hotel-660x440-620x413.jpg" });
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
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		private List<HotelImages> hotelImagesInfo;
		public List<HotelImages> HotelImagesInfo
		{
			get => hotelImagesInfo;
			set
			{
				hotelImagesInfo = value;
				OnPropertyChanged("HotelImagesInfo");
			}
		}
		#endregion
	}
}
