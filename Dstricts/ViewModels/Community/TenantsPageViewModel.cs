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
			TenantInfo = new ObservableCollection<Models.CommunityAvailableTenantsInfoResponse>(response);
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
		#endregion
	}
}
