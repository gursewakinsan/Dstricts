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
            await Task.CompletedTask;
        }
        #endregion
    }
}
