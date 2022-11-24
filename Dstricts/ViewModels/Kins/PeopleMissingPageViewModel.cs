using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace Dstricts.ViewModels
{
    public class PeopleMissingPageViewModel : BaseViewModel
    {
        #region Constructor.
        public PeopleMissingPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Report Person Found Command.
        private ICommand reportPersonFoundCommand;
        public ICommand ReportPersonFoundCommand
        {
            get => reportPersonFoundCommand ?? (reportPersonFoundCommand = new Command<int>(async (missingPersonId) => await ExecuteReportPersonFoundCommand(missingPersonId)));
        }
        private async Task ExecuteReportPersonFoundCommand(int missingPersonId)
        {
            DependencyService.Get<IProgressBar>().Show();
            IKinsService service = new KinsService();
            int response = await service.ReportPersonFoundAsync(new Models.ReportPersonFoundRequest()
            {
                MissingPersonId = missingPersonId
            });
            Application.Current.MainPage = new NavigationPage(new Views.SosHelp.SosHelpPage());
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Properties.
        private List<Models.MissingPersonListResponse> missingPersonList;
        public List<Models.MissingPersonListResponse> MissingPersonList
        {
            get => missingPersonList;
            set
            {
                missingPersonList = value;
                if (value.Count > 1)
                    IsMissingPersonList = true;
                else
                {
                    Kin = value[0];
                    IsMissingPersonList = false;
                }
                OnPropertyChanged("MissingPersonList");
            }
        }

        private Models.MissingPersonListResponse kin;
        public Models.MissingPersonListResponse Kin
        {
            get => kin;
            set
            {
                kin = value;
                OnPropertyChanged("Kin");
            }
        }

        private bool isMissingPersonList = false;
        public bool IsMissingPersonList
        {
            get => isMissingPersonList;
            set
            {
                isMissingPersonList = value;
                OnPropertyChanged("IsMissingPersonList");
            }
        }
        #endregion
    }
}
