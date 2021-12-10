using Xamarin.Forms;

namespace Dstricts.ViewModels
{
	public class QloudIdApartmentDetailsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public QloudIdApartmentDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Properties.
		private Models.CheckedInResponse apartmentDetails;
		public Models.CheckedInResponse ApartmentDetails
		{
			get => apartmentDetails;
			set
			{
				apartmentDetails = value;
				OnPropertyChanged("ApartmentDetails");
			}
		}
		#endregion
	}
}
