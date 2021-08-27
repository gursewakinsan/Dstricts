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

		#region Properties.
		private Models.CheckedInResponse hotelDetails = Helper.Helper.HotelDetails;
		public Models.CheckedInResponse HotelDetails
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
