using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class VerifyCheckedInPageViewModel : BaseViewModel
	{
		#region Constructor.
		public VerifyCheckedInPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Verify Checked In Code Command.
		private ICommand verifyCheckedInCodeCommand;
		public ICommand VerifyCheckedInCodeCommand
		{
			get => verifyCheckedInCodeCommand ?? (verifyCheckedInCodeCommand = new Command(async () => await ExecuteVerifyCheckedInCodeCommand()));
		}
		private async Task ExecuteVerifyCheckedInCodeCommand()
		{
			if (string.IsNullOrWhiteSpace(CheckedInCodeInEmail))
				await Helper.Alert.DisplayAlert("Code is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IHotelService service = new HotelService();
				Models.VerifyCheckedInCodeResponse response = await service.VerifyCheckedInCodeAsync(new Models.VerifyCheckedInCodeRequest()
				{
					UserId = Helper.Helper.LoggedInUserId,
					Ecode = CheckedInCodeInEmail
				});
				if (response.Result == 0)
					await Helper.Alert.DisplayAlert("Booking not available with given code!");
				else
				{
					if (Device.RuntimePlatform == Device.iOS)
						await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/CheckedInHotelId/{response.Id}");
					else
						await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/CheckedInHotelId/{response.Id}");
				}
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		private string checkedInCodeInEmail;
		public string CheckedInCodeInEmail
		{
			get => checkedInCodeInEmail;
			set
			{
				checkedInCodeInEmail = value;
				OnPropertyChanged("CheckedInCodeInEmail");
			}
		}
		#endregion
	}
}
