using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
    public class TravelAppCompanyDetailsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public TravelAppCompanyDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Properties.
		private string selectedCompanyName;
		public string SelectedCompanyName
		{
			get => selectedCompanyName;
			set
			{
				selectedCompanyName = value;
				OnPropertyChanged("SelectedCompanyName");
			}
		}

		private Models.TravelAppCompanyLocationsResponse selectedTravelAppCompanyLocations;
		public Models.TravelAppCompanyLocationsResponse SelectedTravelAppCompanyLocations
		{
			get => selectedTravelAppCompanyLocations;
			set
			{
				selectedTravelAppCompanyLocations = value;
				OnPropertyChanged("SelectedTravelAppCompanyLocations");
			}
		}
        #endregion
    }
}
