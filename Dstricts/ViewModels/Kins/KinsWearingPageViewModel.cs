using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
    public class KinsWearingPageViewModel : BaseViewModel
    {
        #region Constructor.
        public KinsWearingPageViewModel(INavigation navigation)
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
            if (!string.IsNullOrWhiteSpace(WearingText))
                Helper.Helper.MissingPersonInfo.ClothesWearing = WearingText;
            else
                Helper.Helper.MissingPersonInfo.ClothesWearing = string.Empty;
            await Navigation.PushAsync(new Views.Kins.KinsUploadPhotosPage());
        }
        #endregion

        #region Properties
        private string wearingText;
        public string WearingText
        {
            get => wearingText;
            set
            {
                wearingText = value;
                OnPropertyChanged("WearingText");
            }
        }
        #endregion
    }
}
