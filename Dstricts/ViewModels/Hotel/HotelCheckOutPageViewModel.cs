using Xamarin.Forms;
using Xamarin.Essentials;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class HotelCheckOutPageViewModel : BaseViewModel
	{
		#region Constructor.
		public HotelCheckOutPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Yes Please Clicked Command.
		private ICommand yesPleaseClickedCommand;
		public ICommand YesPleaseClickedCommand
		{
			get => yesPleaseClickedCommand ?? (yesPleaseClickedCommand = new Command(() => ExecuteYesPleaseClickedCommand()));
		}
		private void ExecuteYesPleaseClickedCommand()
		{
			if (!IsYesPlease)
			{
				IsYesPlease = true;
				YesPleaseColor = Color.FromHex("#5B5B79");
				YesPleaseOpacity = 0.4;
				VerifyWithQloudIdTextOpacity = 0.3;
				VerifyWithQloudIdButtonBg = Color.FromHex("#363541");
			}
			else
			{
				IsYesPlease = false;
				YesPleaseColor = Color.FromHex("#45C366");
				YesPleaseOpacity = 100;
				VerifyWithQloudIdTextOpacity = 100;
				VerifyWithQloudIdButtonBg = Color.FromHex("#6263ED");
			}
		}
		#endregion

		#region Verify with Qloud ID Command.
		private ICommand verifyWithQloudIdCommand;
		public ICommand VerifyWithQloudIdCommand
		{
			get => verifyWithQloudIdCommand ?? (verifyWithQloudIdCommand = new Command(async() =>await ExecuteVerifyWithQloudIdCommand()));
		}
		private async Task ExecuteVerifyWithQloudIdCommand()
		{
			if (VerifyWithQloudIdTextOpacity == 100)
			{
				if (Device.RuntimePlatform == Device.iOS)
					await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/HotelCheckOut/{Helper.Helper.HotelCheckedIn}");
				else
					await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/HotelCheckOut/{Helper.Helper.HotelCheckedIn}");

				await Navigation.PopToRootAsync();
			}
		}
		#endregion

		#region Properties.
		public Models.HotelCompleteInfoResponse HotelCompleteInfo => Helper.Helper.HotelDetails;
		public bool IsYesPlease { get; set; } = false;

		private Color yesPleaseColor = Color.FromHex("#525388");
		public Color YesPleaseColor
		{
			get => yesPleaseColor;
			set
			{
				yesPleaseColor = value;
				OnPropertyChanged("YesPleaseColor");
			}
		}

		private double yesPleaseOpacity;
		public double YesPleaseOpacity
		{
			get => yesPleaseOpacity;
			set
			{
				yesPleaseOpacity = value;
				OnPropertyChanged("YesPleaseOpacity");
			}
		}

		private double verifyWithQloudIdTextOpacity;
		public double VerifyWithQloudIdTextOpacity
		{
			get => verifyWithQloudIdTextOpacity;
			set
			{
				verifyWithQloudIdTextOpacity = value;
				OnPropertyChanged("VerifyWithQloudIdTextOpacity");
			}
		}

		private Color verifyWithQloudIdButtonBg = Color.FromHex("#363541");
		public Color VerifyWithQloudIdButtonBg
		{
			get => verifyWithQloudIdButtonBg;
			set
			{
				verifyWithQloudIdButtonBg = value;
				OnPropertyChanged("VerifyWithQloudIdButtonBg");
			}
		}
		#endregion
	}
}
