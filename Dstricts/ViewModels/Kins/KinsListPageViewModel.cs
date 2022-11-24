using System.Linq;
using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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
            IsLoadData = false;
            DependencyService.Get<IProgressBar>().Show();
            IKinsService service = new KinsService();
            var response = await service.KinsListAsync(new Models.kinsListRequest()
            {
                UserId = Helper.Helper.LoggedInUserId
            });
            IsKinsList = response.Count == 1 ? false : true;
            if (!IsKinsList)
                Kin = response[0];
            else
                KinsList = new ObservableCollection<Models.kinsListResponse>(response);
            IsLoadData = true;
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Update Notification Requirement Command.
        private ICommand updateNotificationRequirementCommand;
        public ICommand UpdateNotificationRequirementCommand
        {
            get => updateNotificationRequirementCommand ?? (updateNotificationRequirementCommand = new Command<Models.kinsListResponse>(async (kin) => await ExecuteUpdateNotificationRequirementCommand(kin)));
        }
        private async Task ExecuteUpdateNotificationRequirementCommand(Models.kinsListResponse kin)
        { 
            DependencyService.Get<IProgressBar>().Show();
            IKinsService service = new KinsService();
            var response = await service.UpdateNotificationRequirementAsync(new Models.UpdateNotificationRequirementRequest()
            {
                Id = kin.Id,
                UpdateInfo = kin.IsNotificationRequired ? 0 : 1
            });
            //KinsListCommand.Execute(null);
            if (KinsList?.Count > 1)
                KinsList.FirstOrDefault(x => x.Id == kin.Id).IsNotificationRequired = !kin.IsNotificationRequired;
            else
                Kin.IsNotificationRequired = !kin.IsNotificationRequired;
            //kin.IsNotificationRequired = !kin.IsNotificationRequired;
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Properties.
        private ObservableCollection<Models.kinsListResponse> kinsList;
        public ObservableCollection<Models.kinsListResponse> KinsList
        {
            get => kinsList;
            set
            {
                kinsList = value;
                OnPropertyChanged("KinsList");
            }
        }

        private Models.kinsListResponse kin;
        public Models.kinsListResponse Kin
        {
            get => kin;
            set
            {
                kin = value;
                OnPropertyChanged("Kin");
            }
        }

        private bool isKinsList;
        public bool IsKinsList
        {
            get => isKinsList;
            set
            {
                isKinsList = value;
                OnPropertyChanged("IsKinsList");
            }
        }

        private bool isLoadData = false;
        public bool IsLoadData
        {
            get => isLoadData;
            set
            {
                isLoadData = value;
                OnPropertyChanged("IsLoadData");
            }
        }
        #endregion
    }
}
