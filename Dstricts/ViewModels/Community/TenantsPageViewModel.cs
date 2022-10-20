using System.Linq;
using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
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
					tenant.PortNumberBorder = Color.FromHex("#F4B400");
				}
				response[0].IsSelected = true;
				response[0].PortNumberTextColor = Color.Black;
				response[0].PortNumberBg = Color.FromHex("#F4B400");
				response[0].PortNumberBorder = Color.FromHex("#F4B400");
				CopySelectedTenantInfo = response[0].TenantsList;
				SelectedTenantInfo = new ObservableCollection<Models.Tenant>(response[0].TenantsList);
				TenantInfo = new ObservableCollection<Models.CommunityAvailableTenantsInfoResponse>(response);
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Search Command.
		private ICommand searchCommand;
		public ICommand SearchCommand
		{
			get => searchCommand ?? (searchCommand = new Command( () => ExecuteSearchCommand()));
		}
		private void ExecuteSearchCommand()
		{
			if (string.IsNullOrWhiteSpace(SearchText)) return;
			else
			{
				if (CopySelectedTenantInfo?.Count > 0)
				{
					var result = CopySelectedTenantInfo.Where(x => x.SearchTextFrom.ToLower().Contains(SearchText)).ToList();
					SelectedTenantInfo = new ObservableCollection<Models.Tenant>(result);
				}
			}
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

		public List<Models.Tenant> CopySelectedTenantInfo { get; set; }

		private string searchText;
		public string SearchText
		{
			get => searchText;
			set
			{
				searchText = value;
				OnPropertyChanged("SearchText");
			}
		}
		#endregion
	}
}
