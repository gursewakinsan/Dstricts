using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class AvalibleQueueOnTheLocationPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AvalibleQueueOnTheLocationPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Avalible Queue On The Location Command.
		private ICommand getAvalibleQueueOnTheLocationCommand;
		public ICommand GetAvalibleQueueOnTheLocationCommand
		{
			get => getAvalibleQueueOnTheLocationCommand ?? (getAvalibleQueueOnTheLocationCommand = new Command(async () => await ExecuteGetAvalibleQueueOnTheLocationCommand()));
		}
		private async Task ExecuteGetAvalibleQueueOnTheLocationCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IQueueService service = new QueueService();
			AvalibleQueueOnTheLocationList = await service.GetAvalibleQueueOnTheLocationAsync(new Models.AvalibleQueueOnTheLocationRequest()
			{
				Id = Helper.Helper.AvalibleQueueId
			});
			IsListEmpty = AvalibleQueueOnTheLocationList?.Count > 0 ? true : false;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Add Person To Desired Queue Command.
		private ICommand addPersonToDesiredQueueCommand;
		public ICommand AddPersonToDesiredQueueCommand
		{
			get => addPersonToDesiredQueueCommand ?? (addPersonToDesiredQueueCommand = new Command<int>(async (id) => await ExecuteAddPersonToDesiredQueueCommand(id)));
		}
		private async Task ExecuteAddPersonToDesiredQueueCommand(int id)
		{
			if (Device.RuntimePlatform == Device.iOS)
				await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/AddPersonToDesiredQueue/{id}");
			else
				await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/AddPersonToDesiredQueue/{id}");
		}
		#endregion

		#region Properties.
		private List<Models.AvalibleQueueOnTheLocationResponse> avalibleQueueOnTheLocationList;
		public List<Models.AvalibleQueueOnTheLocationResponse> AvalibleQueueOnTheLocationList
		{
			get => avalibleQueueOnTheLocationList;
			set
			{
				avalibleQueueOnTheLocationList = value;
				OnPropertyChanged("AvalibleQueueOnTheLocationList");
			}
		}

		private bool isListEmpty = true;
		public bool IsListEmpty
		{
			get => isListEmpty;
			set
			{
				isListEmpty = value;
				OnPropertyChanged("IsListEmpty");
			}
		}
		#endregion
	}
}
