using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class AllWaitListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AllWaitListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Properties.
		private List<Models.UserQueueListResponse> allWaitListInfo;
		public List<Models.UserQueueListResponse> AllWaitListInfo
		{
			get => allWaitListInfo;
			set
			{
				allWaitListInfo = value;
				OnPropertyChanged("AllWaitListInfo");
			}
		}

		private bool isListOneRecord;
		public bool IsListOneRecord
		{
			get => isListOneRecord;
			set
			{
				isListOneRecord = value;
				OnPropertyChanged("IsListOneRecord");
			}
		}
		#endregion

		#region Socail Click Command .
		private ICommand socailClickCommand;
		public ICommand SocailClickCommand
		{
			get => socailClickCommand ?? (socailClickCommand = new Command(() => ExecuteSocailClickCommand()));
		}
		private void ExecuteSocailClickCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Hotel.CheckedInListPage());
		}
		#endregion

		#region Go To Check In Command.
		private ICommand goToCheckInCommand;
		public ICommand GoToCheckInCommand
		{
			get => goToCheckInCommand ?? (goToCheckInCommand = new Command( () =>  ExecuteGoToCheckInCommand()));
		}
		private void ExecuteGoToCheckInCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Hotel.CheckInPage());
		}
		#endregion
	}
}
