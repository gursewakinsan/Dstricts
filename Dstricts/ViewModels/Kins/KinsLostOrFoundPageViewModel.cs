using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

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
            DependencyService.Get<IProgressBar>().Show();
            IKinsService service = new KinsService();
            var response = await service.MissingPersonListAsync(new Models.MissingPersonListRequest()
            {
                UserId = Helper.Helper.LoggedInUserId
            });
            if (response?.Count > 0)
                await Navigation.PushAsync(new Views.Kins.FoundKinsPage(response));
            else
                await Navigation.PushAsync(new Views.Kins.NoMissingPersonFoundPage());
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion
    }
}
