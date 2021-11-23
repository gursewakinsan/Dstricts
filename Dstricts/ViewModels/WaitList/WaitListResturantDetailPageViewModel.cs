using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class WaitListResturantDetailPageViewModel : BaseViewModel
	{
		#region Constructor.
		public WaitListResturantDetailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Selected People In Party Command.
		private ICommand selectedPeopleInPartyCommand;
		public ICommand SelectedPeopleInPartyCommand
		{
			get => selectedPeopleInPartyCommand ?? (selectedPeopleInPartyCommand = new Command<string>((parm) => ExecuteSelectedPeopleInPartyCommand(parm)));
		}
		private void ExecuteSelectedPeopleInPartyCommand(string parm)
		{
			TotalPerson = Convert.ToInt32(parm);
			switch (TotalPerson)
			{
				case 1:
					if (Button1Bg.Equals(ButtonBlackBg))
					{
						Button1Bg = ButtonBlueBg;
						IsSubmit = true;
					}
					else
					{
						Button1Bg = ButtonBlackBg;
						IsSubmit = false;
					}
					Button2Bg = ButtonBlackBg;
					Button3Bg = ButtonBlackBg;
					Button4Bg = ButtonBlackBg;
					Button5Bg = ButtonBlackBg;
					Button6Bg = ButtonBlackBg;
					Button7Bg = ButtonBlackBg;
					Button8Bg = ButtonBlackBg;
					Button9Bg = ButtonBlackBg;
					break;
				case 2:
					if (Button2Bg.Equals(ButtonBlackBg))
					{
						Button2Bg = ButtonBlueBg;
						IsSubmit = true;
					}
					else
					{
						Button2Bg = ButtonBlackBg;
						IsSubmit = false;
					}
					Button1Bg = ButtonBlackBg;
					Button3Bg = ButtonBlackBg;
					Button4Bg = ButtonBlackBg;
					Button5Bg = ButtonBlackBg;
					Button6Bg = ButtonBlackBg;
					Button7Bg = ButtonBlackBg;
					Button8Bg = ButtonBlackBg;
					Button9Bg = ButtonBlackBg;
					break;
				case 3:
					if (Button3Bg.Equals(ButtonBlackBg))
					{
						Button3Bg = ButtonBlueBg;
						IsSubmit = true;
					}
					else
					{
						Button3Bg = ButtonBlackBg;
						IsSubmit = false;
					}
					Button1Bg = ButtonBlackBg;
					Button2Bg = ButtonBlackBg;
					Button4Bg = ButtonBlackBg;
					Button5Bg = ButtonBlackBg;
					Button6Bg = ButtonBlackBg;
					Button7Bg = ButtonBlackBg;
					Button8Bg = ButtonBlackBg;
					Button9Bg = ButtonBlackBg;
					break;
				case 4:
					if (Button4Bg.Equals(ButtonBlackBg))
					{
						Button4Bg = ButtonBlueBg;
						IsSubmit = true;
					}
					else
					{
						Button4Bg = ButtonBlackBg;
						IsSubmit = false;
					}
					Button1Bg = ButtonBlackBg;
					Button2Bg = ButtonBlackBg;
					Button3Bg = ButtonBlackBg;
					Button5Bg = ButtonBlackBg;
					Button6Bg = ButtonBlackBg;
					Button7Bg = ButtonBlackBg;
					Button8Bg = ButtonBlackBg;
					Button9Bg = ButtonBlackBg;
					break;
				case 5:
					if (Button5Bg.Equals(ButtonBlackBg))
					{
						Button5Bg = ButtonBlueBg;
						IsSubmit = true;
					}
					else
					{
						Button5Bg = ButtonBlackBg;
						IsSubmit = false;
					}
					Button1Bg = ButtonBlackBg;
					Button2Bg = ButtonBlackBg;
					Button3Bg = ButtonBlackBg;
					Button4Bg = ButtonBlackBg;
					Button6Bg = ButtonBlackBg;
					Button7Bg = ButtonBlackBg;
					Button8Bg = ButtonBlackBg;
					Button9Bg = ButtonBlackBg;
					break;
				case 6:
					if (Button6Bg.Equals(ButtonBlackBg))
					{
						Button6Bg = ButtonBlueBg;
						IsSubmit = true;
					}
					else
					{
						Button6Bg = ButtonBlackBg;
						IsSubmit = false;
					}
					Button1Bg = ButtonBlackBg;
					Button2Bg = ButtonBlackBg;
					Button3Bg = ButtonBlackBg;
					Button4Bg = ButtonBlackBg;
					Button5Bg = ButtonBlackBg;
					Button7Bg = ButtonBlackBg;
					Button8Bg = ButtonBlackBg;
					Button9Bg = ButtonBlackBg;
					break;
				case 7:
					if (Button7Bg.Equals(ButtonBlackBg))
					{
						Button7Bg = ButtonBlueBg;
						IsSubmit = true;
					}
					else
					{
						Button7Bg = ButtonBlackBg;
						IsSubmit = false;
					}
					Button1Bg = ButtonBlackBg;
					Button2Bg = ButtonBlackBg;
					Button3Bg = ButtonBlackBg;
					Button4Bg = ButtonBlackBg;
					Button5Bg = ButtonBlackBg;
					Button6Bg = ButtonBlackBg;
					Button8Bg = ButtonBlackBg;
					Button9Bg = ButtonBlackBg;
					break;
				case 8:
					if (Button8Bg.Equals(ButtonBlackBg))
					{
						Button8Bg = ButtonBlueBg;
						IsSubmit = true;
					}
					else
					{
						Button8Bg = ButtonBlackBg;
						IsSubmit = false;
					}
					Button1Bg = ButtonBlackBg;
					Button2Bg = ButtonBlackBg;
					Button3Bg = ButtonBlackBg;
					Button4Bg = ButtonBlackBg;
					Button5Bg = ButtonBlackBg;
					Button6Bg = ButtonBlackBg;
					Button7Bg = ButtonBlackBg;
					Button9Bg = ButtonBlackBg;
					break;
				case 9:
					if (Button9Bg.Equals(ButtonBlackBg))
					{
						Button9Bg = ButtonBlueBg;
						IsSubmit = true;
					}
					else
					{
						Button9Bg = ButtonBlackBg;
						IsSubmit = false;
					}
					Button1Bg = ButtonBlackBg;
					Button2Bg = ButtonBlackBg;
					Button3Bg = ButtonBlackBg;
					Button4Bg = ButtonBlackBg;
					Button5Bg = ButtonBlackBg;
					Button6Bg = ButtonBlackBg;
					Button7Bg = ButtonBlackBg;
					Button8Bg = ButtonBlackBg;
					break;
			}
		}
		#endregion

		#region Submit Wait List Resturant Detail Command.
		private ICommand submitWaitListResturantDetailCommand;
		public ICommand SubmitWaitListResturantDetailCommand
		{
			get => submitWaitListResturantDetailCommand ?? (submitWaitListResturantDetailCommand = new Command(async () => await ExecuteSubmitWaitListResturantDetailCommand()));
		}
		private async Task ExecuteSubmitWaitListResturantDetailCommand()
		{
			Models.SubmitWaitListResturantDetail submitRequest = new Models.SubmitWaitListResturantDetail()
			{
				Qid = SelectedWaitResturantInfo.Id,
				UserId = Helper.Helper.LoggedInUserId,
				TotalPerson = TotalPerson,
			};
			string submitJson = Newtonsoft.Json.JsonConvert.SerializeObject(submitRequest);
			if (Device.RuntimePlatform == Device.iOS)
				await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/DstrictsWaitListResturant/{submitJson}");
			else
				await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/DstrictsWaitListResturant/{submitJson}");
		}
		#endregion

		#region Properties.
		private Models.WaitListResturantResponse selectedWaitResturantInfo;
		public Models.WaitListResturantResponse SelectedWaitResturantInfo
		{
			get => selectedWaitResturantInfo;
			set
			{
				selectedWaitResturantInfo = value;
				OnPropertyChanged("SelectedWaitResturantInfo");
			}
		}

		private string button1Bg = ButtonBlackBg;
		public string Button1Bg
		{
			get => button1Bg;
			set
			{
				button1Bg = value;
				OnPropertyChanged("Button1Bg");
			}
		}

		private string button2Bg = ButtonBlackBg;
		public string Button2Bg
		{
			get => button2Bg;
			set
			{
				button2Bg = value;
				OnPropertyChanged("Button2Bg");
			}
		}

		private string button3Bg = ButtonBlackBg;
		public string Button3Bg
		{
			get => button3Bg;
			set
			{
				button3Bg = value;
				OnPropertyChanged("Button3Bg");
			}
		}

		private string button4Bg = ButtonBlackBg;
		public string Button4Bg
		{
			get => button4Bg;
			set
			{
				button4Bg = value;
				OnPropertyChanged("Button4Bg");
			}
		}

		private string button5Bg = ButtonBlackBg;
		public string Button5Bg
		{
			get => button5Bg;
			set
			{
				button5Bg = value;
				OnPropertyChanged("Button5Bg");
			}
		}

		private string button6Bg = ButtonBlackBg;
		public string Button6Bg
		{
			get => button6Bg;
			set
			{
				button6Bg = value;
				OnPropertyChanged("Button6Bg");
			}
		}

		private string button7Bg = ButtonBlackBg;
		public string Button7Bg
		{
			get => button7Bg;
			set
			{
				button7Bg = value;
				OnPropertyChanged("Button7Bg");
			}
		}

		private string button8Bg = ButtonBlackBg;
		public string Button8Bg
		{
			get => button8Bg;
			set
			{
				button8Bg = value;
				OnPropertyChanged("Button8Bg");
			}
		}

		private string button9Bg = ButtonBlackBg;
		public string Button9Bg
		{
			get => button9Bg;
			set
			{
				button9Bg = value;
				OnPropertyChanged("Button9Bg");
			}
		}

		private bool isSubmit = false;
		public bool IsSubmit
		{
			get => isSubmit;
			set
			{
				isSubmit = value;
				OnPropertyChanged("IsSubmit");
			}
		}

		public int TotalPerson { get; set; }
		public static string ButtonBlackBg => "#2A2A31";
		public static string ButtonBlueBg => "#6263ED";
		#endregion
	}
}

