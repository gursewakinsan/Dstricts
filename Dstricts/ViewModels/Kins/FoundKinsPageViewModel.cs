using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
    public class FoundKinsPageViewModel : BaseViewModel
    {
        #region Constructor.
        public FoundKinsPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Missing Person Emergency Command.
        private ICommand missingPersonEmergencyCommand;
        public ICommand MissingPersonEmergencyCommand
        {
            get => missingPersonEmergencyCommand ?? (missingPersonEmergencyCommand = new Command(async () => await ExecuteMissingPersonEmergencyCommand()));
        }
        private async Task ExecuteMissingPersonEmergencyCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            IKinsService service = new KinsService();
            MissingPersonEmergencyList = await service.MissingPersonEmergencyListAsync(new Models.MissingPersonEmergencyListRequest()
            {
                UserId = Helper.Helper.LoggedInUserId
            });
            IsMissingPersonEmergency = MissingPersonEmergencyList?.Count > 0 ? true : false;
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Properties.
        private List<Models.MissingPersonEmergencyListResponse> missingPersonEmergencyList;
        public List<Models.MissingPersonEmergencyListResponse> MissingPersonEmergencyList
        {
            get => missingPersonEmergencyList;
            set
            {
                missingPersonEmergencyList = value;
                OnPropertyChanged("MissingPersonEmergencyList");
            }
        }

        private List<Models.MissingPersonListResponse> missingPersonList;
        public List<Models.MissingPersonListResponse> MissingPersonList
        {
            get => missingPersonList;
            set
            {
                missingPersonList = value;
                MissingPersonCount = value.Count;
                OnPropertyChanged("MissingPersonList");
            }
        }

        private int missingPersonCount;
        public int MissingPersonCount
        {
            get => missingPersonCount;
            set
            {
                missingPersonCount = value;
                OnPropertyChanged("MissingPersonCount");
            }
        }

        private bool isMissingPersonEmergency = false;
        public bool IsMissingPersonEmergency
        {
            get => isMissingPersonEmergency;
            set
            {
                isMissingPersonEmergency = value;
                OnPropertyChanged("IsMissingPersonEmergency");
            }
        }
        #endregion
    }
}
