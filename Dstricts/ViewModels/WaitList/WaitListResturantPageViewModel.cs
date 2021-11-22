using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class WaitListResturantPageViewModel : BaseViewModel
	{
		#region Constructor.
		public WaitListResturantPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Laundry Cart Info List Command.
		private ICommand laundryCartInfoListCommand;
		public ICommand LaundryCartInfoListCommand
		{
			get => laundryCartInfoListCommand ?? (laundryCartInfoListCommand = new Command(async () => await ExecuteLaundryCartInfoListCommand()));
		}
		private async Task ExecuteLaundryCartInfoListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IWaitService service = new WaitService();
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.WaitListResturantResponse> waitListResturantInfo;
		public List<Models.WaitListResturantResponse> WaitListResturantInfo
		{
			get => waitListResturantInfo;
			set
			{
				waitListResturantInfo = value;
				OnPropertyChanged("WaitListResturantInfo");
			}
		}
		#endregion
	}
}
