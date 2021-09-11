using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class UserQueueWaitingDetailPageViewModel : BaseViewModel
	{
		#region Constructor.
		public UserQueueWaitingDetailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region User Queue Waiting Detail Command.
		private ICommand userQueueWaitingDetailCommand;
		public ICommand UserQueueWaitingDetailCommand
		{
			get => userQueueWaitingDetailCommand ?? (userQueueWaitingDetailCommand = new Command(async () => await ExecuteUserQueueWaitingDetailCommand()));
		}
		private async Task ExecuteUserQueueWaitingDetailCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IQueueService service = new QueueService();
			UserQueueWaitingDetail = await service.UserQueueWaitingDetailAsync(new Models.UserQueueWaitingDetailRequest()
			{
				Id = SelectedUserQueueId
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region User Remove From Queue Waiting Command.
		private ICommand userRemoveFromQueueWaitingCommand;
		public ICommand UserRemoveFromQueueWaitingCommand
		{
			get => userRemoveFromQueueWaitingCommand ?? (userRemoveFromQueueWaitingCommand = new Command(async () => await ExecuteUserRemoveFromQueueWaitingCommand()));
		}
		private async Task ExecuteUserRemoveFromQueueWaitingCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IQueueService service = new QueueService();
			await service.UserRemoveFromQueueWaitingListAsync(new Models.UserRemoveFromQueueWaitingListRequest()
			{
				Id = SelectedUserQueueId
			});
			await Navigation.PopAsync();
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private Models.UserQueueWaitingDetailResponse userQueueWaitingDetail;
		public Models.UserQueueWaitingDetailResponse UserQueueWaitingDetail
		{
			get => userQueueWaitingDetail;
			set
			{
				userQueueWaitingDetail = value;
				OnPropertyChanged("UserQueueWaitingDetail");
			}
		}

		public int SelectedUserQueueId { get; set; }
		#endregion
	}
}
