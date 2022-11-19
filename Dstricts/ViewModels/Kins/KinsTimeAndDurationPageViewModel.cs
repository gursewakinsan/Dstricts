using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
    public class KinsTimeAndDurationPageViewModel : BaseViewModel
    {
        #region Constructor.
        public KinsTimeAndDurationPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            DurationList = new List<int>
            {
                1, 2, 3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,
                21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,
                41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60
            };
            SelectedDuration = DurationList[0];
            TimeList = new List<string> { "Minutes", "Hours", "Days", "Week", "Month" };
            SelectedTime = TimeList[0];
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

        #region Properties.
        private List<int> durationList;
        public List<int> DurationList
        {
            get => durationList;
            set
            {
                durationList = value;
                OnPropertyChanged("DurationList");
            }
        }

        private int selectedDuration;
        public int SelectedDuration
        {
            get => selectedDuration;
            set
            {
                selectedDuration = value;
                OnPropertyChanged("SelectedDuration");
            }
        }

        private List<string> timeList;
        public List<string> TimeList
        {
            get => timeList;
            set
            {
                timeList = value;
                OnPropertyChanged("TimeList");
            }
        }

        private string selectedTime;
        public string SelectedTime
        {
            get => selectedTime;
            set
            {
                selectedTime = value;
                OnPropertyChanged("SelectedTime");
            }
        }
        #endregion
    }
}
