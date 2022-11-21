using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
    public class KinsAddressPageViewModel : BaseViewModel
    {
        #region Constructor.
        public KinsAddressPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Next Command.
        private ICommand nextCommand;
        public ICommand NextCommand
        {
            get => nextCommand ?? (nextCommand = new Command(async () => await ExecuteNextCommand()));
        }
        private async Task ExecuteNextCommand()
        {
            if (string.IsNullOrWhiteSpace(Address) && string.IsNullOrWhiteSpace(ClosestAddress))
                await Helper.Alert.DisplayAlert("Address is required.");
            else
            {
                if(!string.IsNullOrWhiteSpace(Address))
                    Helper.Helper.MissingPersonInfo.Address= Address;
                if (!string.IsNullOrWhiteSpace(ClosestAddress))
                    Helper.Helper.MissingPersonInfo.Address = ClosestAddress;
                if (!string.IsNullOrWhiteSpace(Address) && ! string.IsNullOrWhiteSpace(ClosestAddress))
                    Helper.Helper.MissingPersonInfo.Address = Address;
                await Navigation.PushAsync(new Views.Kins.KinsWearingPage());
            }
        }
        #endregion

        #region Properties.
        private string address;
        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private string closestAddress;
        public string ClosestAddress
        {
            get => closestAddress;
            set
            {
                closestAddress = value;
                OnPropertyChanged("ClosestAddress");
            }
        }
        #endregion
    }
}
