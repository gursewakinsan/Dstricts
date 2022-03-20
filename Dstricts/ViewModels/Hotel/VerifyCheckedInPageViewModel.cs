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

		#region User Details Dstricts Command.
		private ICommand userDetailsDstrictsCommand;
		public ICommand UserDetailsDstrictsCommand
		{
			get => userDetailsDstrictsCommand ?? (userDetailsDstrictsCommand = new Command(async () => await ExecuteUserDetailsDstrictsCommand()));
		}
		private async Task ExecuteUserDetailsDstrictsCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ILoginService service = new LoginService();
			var response = await service.UserDetailsDstrictsAsync(new Models.UserDetailsDstrictsRequest()
			{
				UserId = Helper.Helper.LoggedInUserId
			});
			if (response != null)
				UserEmail = response.Email;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Verify Sms Password Command.
		private ICommand verifySmsPasswordCommand;
		public ICommand VerifySmsPasswordCommand
		{
			get => verifySmsPasswordCommand ?? (verifySmsPasswordCommand = new Command(async () => await ExecuteVerifySmsPasswordCommand()));
		}
		private async Task ExecuteVerifySmsPasswordCommand()
		{
			if (string.IsNullOrWhiteSpace(Password))
				await Helper.Alert.DisplayAlert("Code is required.");
			else
			{
				if (Password.Length < 6) return;
				DependencyService.Get<IProgressBar>().Show();
				IHotelService service = new HotelService();
				Models.VerifyCheckedInCodeResponse response = await service.VerifyCheckedInCodeAsync(new Models.VerifyCheckedInCodeRequest()
				{
					UserId = Helper.Helper.LoggedInUserId,
					Ecode = Password,
					HotelPropertyType = HotelPropertyType,
					VerifyCheckinId = VerifyCheckinId
				});
				ClearPassword();
				if (response.Result == 0)
					await Navigation.PushAsync(new Views.ErrorMessage.BookingNotAvailablePage());
				else if (response.Result == 2)
					await Navigation.PushAsync(new Views.ErrorMessage.BookingWrongDatePage());
				else if (response.Result == 3)
					await Navigation.PushAsync(new Views.ErrorMessage.FrontDeskPage());
				else
				{
					if (response.GuestChildren == 0 && response.GuestAdult == 1)
					{
						if (Device.RuntimePlatform == Device.iOS)
							await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/CheckedInHotelId/{response.Id}");
						else
							await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/CheckedInHotelId/{response.Id}");
					}
					else if (response.GuestChildren == 0 && response.GuestAdult > 1)
						await Navigation.PushAsync(new Views.Hotel.UpdateAdultInfoPage(response));
					else
						await Navigation.PushAsync(new Views.Hotel.UpdateAdultsAndChildrenInfoPage(response));
				}
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Keyboard Numeric Clicked Command.
		private ICommand keyboardNumericClickedCommand;
		public ICommand KeyboardNumericClickedCommand
		{
			get => keyboardNumericClickedCommand ?? (keyboardNumericClickedCommand = new Command<string>((selectedNumeric) => ExecuteKeyboardNumericClickedCommand(selectedNumeric)));
		}
		private void ExecuteKeyboardNumericClickedCommand(string selectedNumeric)
		{
			if (Password.Length <= 5)
			{
				switch (Password.Length)
				{
					case 0:
						Password1 = selectedNumeric;
						ChangePasswordBg(2);
						break;
					case 1:
						Password2 = selectedNumeric;
						ChangePasswordBg(3);
						break;
					case 2:
						Password3 = selectedNumeric;
						ChangePasswordBg(4);
						break;
					case 3:
						Password4 = selectedNumeric;
						ChangePasswordBg(5);
						break;
					case 4:
						Password5 = selectedNumeric;
						ChangePasswordBg(6);
						break;
					case 5:
						Password6 = selectedNumeric;
						Password6Bg = Color.FromHex("#2F3135");
						break;
				}
				Password = Password + selectedNumeric;
			}
		}
		#endregion

		#region Clear Numeric Clicked Command.
		private ICommand clearNumericClickedCommand;
		public ICommand ClearNumericClickedCommand
		{
			get => clearNumericClickedCommand ?? (clearNumericClickedCommand = new Command(() => ExecuteClearNumericClickedCommand()));
		}
		private void ExecuteClearNumericClickedCommand()
		{
			if (Password?.Length > 0)
			{
				switch (Password.Length)
				{
					case 1:
						Password1 = string.Empty;
						ChangePasswordBg(1);
						break;
					case 2:
						Password2 = string.Empty;
						ChangePasswordBg(2);
						break;
					case 3:
						Password3 = string.Empty;
						ChangePasswordBg(3);
						break;
					case 4:
						Password4 = string.Empty;
						ChangePasswordBg(4);
						break;
					case 5:
						Password5 = string.Empty;
						ChangePasswordBg(5);
						break;
					case 6:
						Password6 = string.Empty;
						ChangePasswordBg(6);
						break;
				}
				Password = Password.Remove(Password.Length - 1, 1);
			}
		}
		#endregion

		#region Clear Password.
		void ClearPassword()
		{
			Password = string.Empty;
			Password1 = Password2 = Password3 = string.Empty;
			Password4 = Password5 = Password6 = string.Empty;
			ChangePasswordBg(1);
		}
		#endregion

		#region Change Password Bg.
		void ChangePasswordBg(int index)
		{
			Password1Bg = Password2Bg = Password3Bg = Color.FromHex("#2F3135");
			Password4Bg = Password5Bg = Password6Bg = Color.FromHex("#2F3135");
			switch (index)
			{
				case 1:
					Password1 = "|";
					Password2 = string.Empty;
					Password1Bg = Color.FromHex("#6263ED");
					break;
				case 2:
					Password2 = "|";
					Password3 = string.Empty;
					Password2Bg = Color.FromHex("#6263ED");
					break;
				case 3:
					Password3 = "|";
					Password4 = string.Empty;
					Password3Bg = Color.FromHex("#6263ED");
					break;
				case 4:
					Password4 = "|";
					Password5 = string.Empty;
					Password4Bg = Color.FromHex("#6263ED");
					break;
				case 5:
					Password5 = "|";
					Password6 = string.Empty;
					Password5Bg = Color.FromHex("#6263ED");
					break;
				case 6:
					Password6 = "|";
					Password6Bg = Color.FromHex("#6263ED");
					break;
			}
		}
		#endregion

		#region Properties.
		public string Password { get; set; } = string.Empty;

		public string password1 = "|";
		public string Password1
		{
			get => password1;
			set
			{
				password1 = value;
				OnPropertyChanged("Password1");
			}
		}

		public string password2;
		public string Password2
		{
			get => password2;
			set
			{
				password2 = value;
				OnPropertyChanged("Password2");
			}
		}

		public string password3;
		public string Password3
		{
			get => password3;
			set
			{
				password3 = value;
				OnPropertyChanged("Password3");
			}
		}

		public string password4;
		public string Password4
		{
			get => password4;
			set
			{
				password4 = value;
				OnPropertyChanged("Password4");
			}
		}

		public string password5;
		public string Password5
		{
			get => password5;
			set
			{
				password5 = value;
				OnPropertyChanged("Password5");
			}
		}
		public string password6;
		public string Password6
		{
			get => password6;
			set
			{
				password6 = value;
				OnPropertyChanged("Password6");
			}
		}

		public Color password1Bg = Color.FromHex("#6263ED");
		public Color Password1Bg
		{
			get => password1Bg;
			set
			{
				password1Bg = value;
				OnPropertyChanged("Password1Bg");
			}
		}

		public Color password2Bg = Color.FromHex("#2F3135");
		public Color Password2Bg
		{
			get => password2Bg;
			set
			{
				password2Bg = value;
				OnPropertyChanged("Password2Bg");
			}
		}

		public Color password3Bg = Color.FromHex("#2F3135");
		public Color Password3Bg
		{
			get => password3Bg;
			set
			{
				password3Bg = value;
				OnPropertyChanged("Password3Bg");
			}
		}

		public Color password4Bg = Color.FromHex("#2F3135");
		public Color Password4Bg
		{
			get => password4Bg;
			set
			{
				password4Bg = value;
				OnPropertyChanged("Password4Bg");
			}
		}

		public Color password5Bg = Color.FromHex("#2F3135");
		public Color Password5Bg
		{
			get => password5Bg;
			set
			{
				password5Bg = value;
				OnPropertyChanged("Password5Bg");
			}
		}
		public Color password6Bg = Color.FromHex("#2F3135");
		public Color Password6Bg
		{
			get => password6Bg;
			set
			{
				password6Bg = value;
				OnPropertyChanged("Password6Bg");
			}
		}

		private string userEmail;
		public string UserEmail
		{
			get => userEmail;
			set
			{
				userEmail = value;
				OnPropertyChanged("UserEmail");
			}
		}
		public int HotelPropertyType { get; set; }
		public string VerifyCheckinId { get; set; }
		#endregion
	}
}

