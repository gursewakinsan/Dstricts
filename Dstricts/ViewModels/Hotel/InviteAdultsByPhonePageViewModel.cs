using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class InviteAdultsByPhonePageViewModel : BaseViewModel
	{
		#region Constructor.
		public InviteAdultsByPhonePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Save Mobile Number Command.
		private ICommand saveMobileNumberCommand;
		public ICommand SaveMobileNumberCommand
		{
			get => saveMobileNumberCommand ?? (saveMobileNumberCommand = new Command(async () => await ExecuteSaveMobileNumberCommand()));
		}
		private async Task ExecuteSaveMobileNumberCommand()
		{
			if (string.IsNullOrWhiteSpace(MobileNumber))
				await Helper.Alert.DisplayAlert("Mobile number is required.");
			else if (MobileNumber.StartsWith("0"))
				await Helper.Alert.DisplayAlert("First digit cannot be zero.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IHotelService service = new HotelService();
				int response = await service.PhoneIinviteAdultForCheckinAsync(new Models.PhoneIinviteAdultForCheckinRequest()
				{
					CheckId = Helper.Helper.HotelCheckedIn,
					UserId = Helper.Helper.LoggedInUserId,
					PhoneNumber = MobileNumber,
					//CountryId =11 TODO
				});
				if (response == 0)
					await Helper.Alert.DisplayAlert("You can't invite your self.");
				else
				{

				}
				DependencyService.Get<IProgressBar>().Hide();
			}
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		public string MobileNumber { get; set; }
		#endregion
	}
}
