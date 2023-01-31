using Xamarin.Forms;
using Xamarin.Essentials;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class CompleteSignUpPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CompleteSignUpPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
        #endregion

        #region Skip Command.
        private ICommand skipCommand;
        public ICommand SkipCommand
        {
            get => skipCommand ?? (skipCommand = new Command(() => ExecuteSkipCommand()));
        }
        private void ExecuteSkipCommand()
        {
            Application.Current.MainPage = new NavigationPage(new Views.Hotel.CheckedInListPage());
        }
        #endregion

        #region Pay Command.
        private ICommand payCommand;
        public ICommand PayCommand
        {
            get => payCommand ?? (payCommand = new Command(async () => await ExecutePayCommand()));
        }
        private async Task ExecutePayCommand()
        {
            Models.CompleteSignUpRequest request = new Models.CompleteSignUpRequest()
            {
                CardCount = ApartmentDetailInfo.CardCount,
                PassportCount = ApartmentDetailInfo.PassportCount
            };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(request);
            if (Device.RuntimePlatform == Device.iOS)
                await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/DstrictsAppCompleteSignUp/{json}");
            else
                await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/DstrictsAppCompleteSignUp/{json}");
        }
        #endregion

        #region Passport Command.
        private ICommand passportCommand;
        public ICommand PassportCommand
        {
            get => passportCommand ?? (passportCommand = new Command(async () => await ExecutePassportCommand()));
        }
        private async Task ExecutePassportCommand()
        {
            Models.CompleteSignUpRequest request = new Models.CompleteSignUpRequest()
            {
                CardCount = ApartmentDetailInfo.CardCount,
                PassportCount = ApartmentDetailInfo.PassportCount
            };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(request);
            if (Device.RuntimePlatform == Device.iOS)
                await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/DstrictsAppCompleteSignUp/{json}");
            else
                await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/DstrictsAppCompleteSignUp/{json}");
        }
        #endregion

        #region Start Command.
        private ICommand startCommand;
        public ICommand StartCommand
        {
            get => startCommand ?? (startCommand = new Command(() => ExecuteStartCommand()));
        }
        private void ExecuteStartCommand()
        {
            if (!ApartmentDetailInfo.CardCount)
                PayCommand.Execute(null);
            else if (!ApartmentDetailInfo.PassportCount)
                PassportCommand.Execute(null);
        }
        #endregion

        #region Properties.
        private Models.ApartmentDetailInfoCheckinResponse apartmentDetailInfo;
		public Models.ApartmentDetailInfoCheckinResponse ApartmentDetailInfo
		{
			get => apartmentDetailInfo;
			set
			{
				apartmentDetailInfo = value;
				OnPropertyChanged("ApartmentDetailInfo");
			}
		}
		#endregion
	}
}
