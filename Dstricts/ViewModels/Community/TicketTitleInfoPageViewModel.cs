using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
    public class TicketTitleInfoPageViewModel : BaseViewModel
    {
		#region Constructor.
		public TicketTitleInfoPageViewModel(INavigation navigation)
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
			TicketTitleInfoList = await service.GetTicketTitleInfoAsync(new Models.TicketTitleInfoRequest()
			{
				TicketType = TicketType
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.TicketTitleInfoResponse> ticketTitleInfoList;
		public List<Models.TicketTitleInfoResponse> TicketTitleInfoList
		{
			get => ticketTitleInfoList;
			set
			{
				ticketTitleInfoList = value;
				OnPropertyChanged("TicketTitleInfoList");
			}
		}

        public string TicketType { get; set; }

		public string DisplayPropertyNickName => Helper.Helper.PropertyNickName;
		#endregion
	}
}
