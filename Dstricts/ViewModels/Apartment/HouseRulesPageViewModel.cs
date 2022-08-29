using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
    public class HouseRulesPageViewModel : BaseViewModel
    {
		#region Constructor.
		public HouseRulesPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Properties.
		private Models.ApartmentDetailInfoResponse apartmentDetailInfo = Helper.Helper.ApartmentDetailInfo;
		public Models.ApartmentDetailInfoResponse ApartmentDetailInfo
		{
			get => apartmentDetailInfo;
			set
			{
				apartmentDetailInfo = value;
				OnPropertyChanged("ApartmentDetailInfo");
			}
		}
		#endregion
	}
}
