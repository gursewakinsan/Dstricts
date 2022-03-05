using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class AdultsAndChildrenInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AdultsAndChildrenInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Dependents Checked In List Command.
		private ICommand dependentsCheckedInListCommand;
		public ICommand DependentsCheckedInListCommand
		{
			get => dependentsCheckedInListCommand ?? (dependentsCheckedInListCommand = new Command(async () => await ExecuteDependentsCheckedInListCommand()));
		}
		private async Task ExecuteDependentsCheckedInListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			DependentsCheckedInList = await service.DependentsCheckedInListAsync(new Models.DependentsCheckedInListRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private int totalCount;
		public int TotalCount
		{
			get => totalCount;
			set
			{
				totalCount = value;
				OnPropertyChanged("TotalCount");
			}
		}

		private List<Models.DependentsCheckedInListResponse> dependentsCheckedInList;
		public List<Models.DependentsCheckedInListResponse> DependentsCheckedInList
		{
			get => dependentsCheckedInList;
			set
			{
				dependentsCheckedInList = value;
				OnPropertyChanged("DependentsCheckedInList");
			}
		}
		public string UserName => Helper.Helper.LoggedInUserName;
		#endregion
	}
}
