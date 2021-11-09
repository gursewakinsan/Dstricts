using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class LaundryServiceCheckOutToPayViewModel : BaseViewModel
	{
		#region Constructor.
		public LaundryServiceCheckOutToPayViewModel(INavigation navigation)
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
			ICartService service = new CartService();
			LaundryCartInfoList = await service.CartInfoListAsync(new Models.CartInfoListRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn,
				ServiceType = 4
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.CartInfoListResponse> laundryCartInfoList;
		public List<Models.CartInfoListResponse> LaundryCartInfoList
		{
			get => laundryCartInfoList;
			set
			{
				laundryCartInfoList = value;
				OnPropertyChanged("LaundryCartInfoList");
			}
		}
		#endregion
	}
}
