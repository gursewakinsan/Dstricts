using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class InviteAdultsByEmailPageViewModel : BaseViewModel
	{
		#region Constructor.
		public InviteAdultsByEmailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Submit Email Address Command.
		private ICommand submitEmailAddressCommand;
		public ICommand SubmitEmailAddressCommand
		{
			get => submitEmailAddressCommand ?? (submitEmailAddressCommand = new Command(async () => await ExecuteSubmitEmailAddressCommand()));
		}
		private async Task ExecuteSubmitEmailAddressCommand()
		{
			if (string.IsNullOrWhiteSpace(EmailAddress))
				await Helper.Alert.DisplayAlert("Email is required.");
			else if (!Helper.Helper.IsValid(EmailAddress))
				await Helper.Alert.DisplayAlert("Please enter valid email address.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IHotelService service = new HotelService();
				int response = await service.EmailIinviteAdultForCheckinAsync(new Models.EmailIinviteAdultForCheckinRequest()
				{
					Email = EmailAddress,
					CheckId = Helper.Helper.HotelCheckedIn,
					UserId = Helper.Helper.LoggedInUserId
				});
				if (response == 0)
					await Helper.Alert.DisplayAlert("You can't invite your self.");
				else
				{
					
				}
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		public string EmailAddress { get; set; } //= "deservingchandan@gmail.com";
		#endregion
	}
}
