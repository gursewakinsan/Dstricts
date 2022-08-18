using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
    public class RulesSubRulesPageViewModel : BaseViewModel
    {
		#region Constructor.
		public RulesSubRulesPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Society Rules List Command.
		private ICommand societyRulesListCommand;
		public ICommand SocietyRulesListCommand
		{
			get => societyRulesListCommand ?? (societyRulesListCommand = new Command(async () => await ExecuteSocietyRulesListCommand()));
		}
		private async Task ExecuteSocietyRulesListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICommunityService service = new CommunityService();
			SocietyRulesList = await service.SocietyRulesListAsync(new Models.SocietyRulesListRequest() 
			{ 
				CommunityId = Helper.Helper.CommunityId
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.SocietyRulesListResponse> societyRulesList;
		public List<Models.SocietyRulesListResponse> SocietyRulesList
		{
			get => societyRulesList;
			set
			{
				societyRulesList = value;
				OnPropertyChanged("SocietyRulesList");
			}
		}
		#endregion
	}
}
