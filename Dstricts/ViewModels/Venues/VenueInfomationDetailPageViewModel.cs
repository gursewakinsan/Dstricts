using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class VenueInfomationDetailPageViewModel : BaseViewModel
	{
		#region Constructor.
		public VenueInfomationDetailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Venue Infomation Detail Command.
		private ICommand venueInfomationDetailCommand;
		public ICommand VenueInfomationDetailCommand
		{
			get => venueInfomationDetailCommand ?? (venueInfomationDetailCommand = new Command(async () => await ExecuteVenueInfomationDetailCommand()));
		}
		private async Task ExecuteVenueInfomationDetailCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IVenueService service = new VenueService();
			VenueInfomationDetail = await service.VenueInfomationDetailAsync(new Models.VenueInfomationDetailRequest()
			{
				VenueId = VenueId
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		public int VenueId { get; set; }

		private Models.VenueInfomationDetailResponse venueInfomationDetail;
		public Models.VenueInfomationDetailResponse VenueInfomationDetail
		{
			get => venueInfomationDetail;
			set
			{
				venueInfomationDetail = value;
				OnPropertyChanged("VenueInfomationDetail");
			}
		}
		#endregion
	}
}
