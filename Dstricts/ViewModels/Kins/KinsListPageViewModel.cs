using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
    public class KinsListPageViewModel : BaseViewModel
    {
        #region Constructor.
        public KinsListPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Kins List Command.
        private ICommand kinsListCommand;
        public ICommand KinsListCommand
        {
            get => kinsListCommand ?? (kinsListCommand = new Command(async () => await ExecuteKinsListCommand()));
        }
        private async Task ExecuteKinsListCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            IKinsService service = new KinsService();
            var response = await service.KinsListAsync(new Models.kinsListRequest()
            {
                UserId = Helper.Helper.LoggedInUserId
            });
            KinsList = response;
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Properties.
        private List<Models.kinsListResponse> kinsList;
        public List<Models.kinsListResponse> KinsList
        {
            get => kinsList;
            set
            {
                kinsList = value;
                OnPropertyChanged("KinsList");
            }
        }
        #endregion
    }
}
