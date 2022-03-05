using System.Linq;
using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Dstricts.ViewModels
{
	public class DependentsListForCheckinPageViewModel : BaseViewModel
	{
		#region Constructor.
		public DependentsListForCheckinPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Dependents List For Checkin Dstrict Command.
		private ICommand dependentsListForCheckinDstrictCommand;
		public ICommand DependentsListForCheckinDstrictCommand
		{
			get => dependentsListForCheckinDstrictCommand ?? (dependentsListForCheckinDstrictCommand = new Command(async () => await ExecuteDependentsListForCheckinDstrictCommand()));
		}
		private async Task ExecuteDependentsListForCheckinDstrictCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			var responses = await service.DependentsListForCheckinDstrictAsync(new Models.DependentsListForCheckinDstrictRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn,
				UserId = Helper.Helper.LoggedInUserId
			});
			DependentsListForCheckinInfo = new ObservableCollection<Models.DependentsListForCheckinDstrictResponse>(responses);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Add Dependent Chekin Command.
		private ICommand addDependentChekinCommand;
		public ICommand AddDependentChekinCommand
		{
			get => addDependentChekinCommand ?? (addDependentChekinCommand = new Command(async () => await ExecuteAddDependentChekinCommand()));
		}
		private async Task ExecuteAddDependentChekinCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			int childId = DependentsListForCheckinInfo.FirstOrDefault(x => x.IsSelect).Id;
			var responses = await service.AddDependentChekinAsync(new Models.AddDependentChekinRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn,
				ChildId = childId
			});
			await Helper.Alert.DisplayAlert($"Thanks, your id is {responses}");
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.DependentsListForCheckinDstrictResponse> dependentsListForCheckinInfo;
		public ObservableCollection<Models.DependentsListForCheckinDstrictResponse> DependentsListForCheckinInfo
		{
			get => dependentsListForCheckinInfo;
			set
			{
				dependentsListForCheckinInfo = value;
				OnPropertyChanged("DependentsListForCheckinInfo");
			}
		}
		public Models.HotelCompleteInfoResponse HotelDetailsInfo => Helper.Helper.HotelDetails;
		#endregion
	}
}
