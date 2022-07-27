using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
    public class TicketSubTitleInfoPageViewModel : BaseViewModel
    {
		#region Constructor.
		public TicketSubTitleInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Ticket Title Info Command.
		private ICommand getTicketTitleInfoCommand;
		public ICommand GetTicketTitleInfoCommand
		{
			get => getTicketTitleInfoCommand ?? (getTicketTitleInfoCommand = new Command(async () => await ExecuteGetTicketTitleInfoCommand()));
		}
		private async Task ExecuteGetTicketTitleInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICommunityService service = new CommunityService();
			TicketSubTitleInfoList = await service.GetTicketSubTitleInfoAsync(new Models.TicketSubTitleInfoRequest()
			{
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.TicketSubTitleInfoResponse> ticketSubTitleInfoList;
		public List<Models.TicketSubTitleInfoResponse> TicketSubTitleInfoList
		{
			get => ticketSubTitleInfoList;
			set
			{
				ticketSubTitleInfoList = value;
				OnPropertyChanged("TicketSubTitleInfoList");
			}
		}
		#endregion
	}
}
