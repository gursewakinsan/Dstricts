using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
    public class TravelAppCompanyPageViewModel : BaseViewModel
    {
		#region Constructor.
		public TravelAppCompanyPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Travel App Company Command.
		private ICommand travelAppCompanyCommand;
		public ICommand TravelAppCompanyCommand
		{
			get => travelAppCompanyCommand ?? (travelAppCompanyCommand = new Command(async () => await ExecuteTravelAppCompanyCommand()));
		}
		private async Task ExecuteTravelAppCompanyCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ISosService service = new SosService();
			TravelAppCompanyList = await service.TravelAppCompanyAsync(new Models.TravelAppCompanyRequest()
			{
				UserId = Helper.Helper.LoggedInUserId,
				EmergencyId = SelectedTravelAppAvailable.Id,
				TabType = SelectedTravelAppAvailable.TabType
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.TravelAppCompanyResponse> travelAppCompanyList;
		public List<Models.TravelAppCompanyResponse> TravelAppCompanyList
		{
			get => travelAppCompanyList;
			set
			{
				travelAppCompanyList = value;
				OnPropertyChanged("TravelAppCompanyList");
			}
		}

		private Models.TravelAppAvailableSosResponse selectedTravelAppAvailable;
		public Models.TravelAppAvailableSosResponse SelectedTravelAppAvailable
		{
			get => selectedTravelAppAvailable;
			set
			{
				selectedTravelAppAvailable = value;
				OnPropertyChanged("SelectedTravelAppAvailable");
			}
		}
        #endregion
    }
}
