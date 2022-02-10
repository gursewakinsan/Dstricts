using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class WellnessBookingTypeViewModel : BaseViewModel
	{
		#region Constructor.
		public WellnessBookingTypeViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region One to One Command.
		private ICommand oneToOneCommand;
		public ICommand OneToOneCommand
		{
			get => oneToOneCommand ?? (oneToOneCommand = new Command(async () => await ExecuteOneToOneCommand()));
		}
		private async Task ExecuteOneToOneCommand()
		{
			await Task.CompletedTask;
		}
		#endregion

		#region Private Booking Command.
		private ICommand privateBookingCommand;
		public ICommand PrivateBookingCommand
		{
			get => privateBookingCommand ?? (privateBookingCommand = new Command(async () => await ExecutePrivateBookingCommand()));
		}
		private async Task ExecutePrivateBookingCommand()
		{
			await Task.CompletedTask;
		}
		#endregion

		#region Public Event Command.
		private ICommand publicEventCommand;
		public ICommand PublicEventCommand
		{
			get => publicEventCommand ?? (publicEventCommand = new Command(async () => await ExecutePublicEventCommand()));
		}
		private async Task ExecutePublicEventCommand()
		{
			await Task.CompletedTask;
		}
		#endregion
	}
}
