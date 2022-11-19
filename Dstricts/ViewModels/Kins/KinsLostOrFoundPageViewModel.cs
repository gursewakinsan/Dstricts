using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
    public class KinsLostOrFoundPageViewModel : BaseViewModel
    {
        #region Constructor.
        public KinsLostOrFoundPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Kins Lost Command.
        private ICommand kinsLostCommand;
        public ICommand KinsLostCommand
        {
            get => kinsLostCommand ?? (kinsLostCommand = new Command(async () => await ExecuteKinsLostCommand()));
        }
        private async Task ExecuteKinsLostCommand()
        {
            await Navigation.PushAsync(new Views.Kins.KinsListPage());
        }
        #endregion

        #region Kins Found Command.
        private ICommand kinsFoundCommand;
        public ICommand KinsFoundCommand
        {
            get => kinsFoundCommand ?? (kinsFoundCommand = new Command(async () => await ExecuteKinsFoundCommand()));
        }
        private async Task ExecuteKinsFoundCommand()
        {
            await Task.CompletedTask;
        }
        #endregion
    }
}
