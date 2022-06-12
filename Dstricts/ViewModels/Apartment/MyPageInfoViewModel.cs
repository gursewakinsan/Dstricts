using Xamarin.Forms;

namespace Dstricts.ViewModels
{
	public class MyPageInfoViewModel : BaseViewModel
	{
		#region Constructor.
		public MyPageInfoViewModel(INavigation navigation)
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

		private Models.ApartmentDetailInfoResponse apartmentDetailInfo;
		public Models.ApartmentDetailInfoResponse ApartmentDetailInfo
		{
			get => apartmentDetailInfo;
			set
			{
				apartmentDetailInfo = value;
				OnPropertyChanged("ApartmentDetailInfo");
			}
		}

		public string UserName => Helper.Helper.LoggedInUserName;
		#endregion
	}
}
