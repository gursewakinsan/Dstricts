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

		#region Get Ticket Sub Title Info Command.
		private ICommand getTicketSubTitleInfoCommand;
		public ICommand GetTicketSubTitleInfoCommand
		{
			get => getTicketSubTitleInfoCommand ?? (getTicketSubTitleInfoCommand = new Command(async () => await ExecuteGetTicketSubTitleInfoCommand()));
		}
		private async Task ExecuteGetTicketSubTitleInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICommunityService service = new CommunityService();
			TicketSubTitleInfoList = await service.GetTicketSubTitleInfoAsync(new Models.TicketSubTitleInfoRequest()
			{
				TicketId = Helper.Helper.TicketId
			});
			if (TicketSubTitleInfoList?.Count > 0)
				SelectedTicketSubTitleInfo = TicketSubTitleInfoList[0];
			DependencyService.Get<IProgressBar>().Hide();
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
			if (string.IsNullOrWhiteSpace(ProblemDescription))
				await Helper.Alert.DisplayAlert("Description is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				ICommunityService service = new CommunityService();
				int response = await service.CreateCommunityTicketAsync(new Models.CreateCommunityTicketRequest()
				{
					ProblemDescription = ProblemDescription,
					CheckId = Helper.Helper.HotelCheckedIn,
					TicketType = Helper.Helper.TicketType,
					TicketId = Helper.Helper.TicketId,
					SubTicketId = SelectedTicketSubTitleInfo.Id,
					CommunityId = Helper.Helper.CommunityId
				});
				DependencyService.Get<IProgressBar>().Hide();
				Application.Current.MainPage = new NavigationPage(new Views.Apartment.SupportPage());
			}
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

		private Models.TicketSubTitleInfoResponse selectedTicketSubTitleInfo;
		public Models.TicketSubTitleInfoResponse SelectedTicketSubTitleInfo
		{
			get => selectedTicketSubTitleInfo;
			set
			{
				selectedTicketSubTitleInfo = value;
				OnPropertyChanged("SelectedTicketSubTitleInfo");
			}
		}


		private string problemDescription;
		public string ProblemDescription
		{
			get => problemDescription;
			set
			{
				problemDescription = value;
				OnPropertyChanged("ProblemDescription");
			}
		}
		#endregion
	}
}

