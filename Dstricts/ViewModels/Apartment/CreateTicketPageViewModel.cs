using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
    public class CreateTicketPageViewModel : BaseViewModel
    {
        #region Constructor.
		public CreateTicketPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
		
		#region Create Ticket Command. 
		private ICommand createTicketCommand;
		public ICommand CreateTicketCommand
		{
			get => createTicketCommand ?? (createTicketCommand = new Command(async () => await ExecuteCreateTicketCommand()));
		}
		private async Task ExecuteCreateTicketCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICommunityService service = new CommunityService();
			Helper.Helper.CommunityId = await service.GetCommunityInfoAsync(new Models.CommunityInfoRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn
			});
			IsCommunityVisible = Helper.Helper.CommunityId > 0 ? true : false;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Ticket Title Info Command. 
		private ICommand ticketTitleInfoCommand;
		public ICommand TicketTitleInfoCommand
		{
			get => ticketTitleInfoCommand ?? (ticketTitleInfoCommand = new Command<string>(async (ticketType) => await ExecuteTicketTitleInfoCommand(ticketType)));
		}
		private async Task ExecuteTicketTitleInfoCommand(string ticketType)
		{
			await Navigation.PushAsync(new Views.Community.TicketTitleInfoPage(ticketType));
		}
		#endregion

		#region Properties.
		private bool isCommunityVisible = false;
		public bool IsCommunityVisible
		{
			get => isCommunityVisible;
			set
			{
				isCommunityVisible = value;
				OnPropertyChanged("IsCommunityVisible");
			}
		}
		
		public string DisplayPropertyNickName => Helper.Helper.PropertyNickName;
		#endregion
    }
}
