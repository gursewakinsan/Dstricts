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

        #region Properties.
        private List<Models.MissingPersonListResponse> missingPersonList;
        public List<Models.MissingPersonListResponse> MissingPersonList
        {
            get => missingPersonList;
            set
            {
                missingPersonList = value;
                if (value.Count > 0)
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
