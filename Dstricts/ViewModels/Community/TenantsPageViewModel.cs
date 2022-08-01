using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Dstricts.ViewModels
{
    public class TenantsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public TenantsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Community Available Tenants Info Command.
		private ICommand communityAvailableTenantsInfoCommand;
		public ICommand CommunityAvailableTenantsInfoCommand
		{
			get => communityAvailableTenantsInfoCommand ?? (communityAvailableTenantsInfoCommand = new Command(async () => await ExecuteCommunityAvailableTenantsInfoCommand()));
		}
		private async Task ExecuteCommunityAvailableTenantsInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICommunityService service = new CommunityService();
			var response = await service.CommunityAvailableTenantsInfoAsync(new Models.CommunityAvailableTenantsInfoRequest()
			{
				CommunityId = Helper.Helper.CommunityId
			});
			if (response?.Count > 0)
			{
                foreach (var tenant in response)
                {
					tenant.IsSelected = false;
					tenant.PortNumberTextColor = Color.White;
					tenant.PortNumberBg = Color.Transparent;
					tenant.PortNumberBorder = Color.FromHex("#737B8C");
				}
				response[0].IsSelected = true;
				response[0].PortNumberTextColor = Color.Black;
				response[0].PortNumberBg = Color.White;
				response[0].PortNumberBorder = Color.White;
				SelectedTenantInfo = new ObservableCollection<Models.Tenant>(response[0].TenantsList);
				TenantInfo = new ObservableCollection<Models.CommunityAvailableTenantsInfoResponse>(response);
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.CommunityAvailableTenantsInfoResponse> tenantInfo;
		public ObservableCollection<Models.CommunityAvailableTenantsInfoResponse> TenantInfo
		{
			get => tenantInfo;
			set
			{
				tenantInfo = value;
				OnPropertyChanged("TenantInfo");
			}
		}

		private ObservableCollection<Models.Tenant> selectedTenantInfo;
		public ObservableCollection<Models.Tenant> SelectedTenantInfo
		{
			get => selectedTenantInfo;
			set
			{
				selectedTenantInfo = value;
				OnPropertyChanged("SelectedTenantInfo");
			}
		}
		#endregion
	}
}
