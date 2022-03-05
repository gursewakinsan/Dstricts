using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class UpdateAdultsInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public UpdateAdultsInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Add Adults Command.
		private ICommand addAdultsCommand;
		public ICommand AddAdultsCommand
		{
			get => addAdultsCommand ?? (addAdultsCommand = new Command(() => ExecuteAddAdultsCommand()));
		}
		private void ExecuteAddAdultsCommand()
		{
			if (AdultCount < VerifyCheckedInInfo.GuestAdult)
				AdultCount = AdultCount + 1;
		}
		#endregion

		#region Remove Adults Command.
		private ICommand removeAdultsCommand;
		public ICommand RemoveAdultsCommand
		{
			get => removeAdultsCommand ?? (removeAdultsCommand = new Command(() => ExecuteAdultsChildrenCommand()));
		}
		private void ExecuteAdultsChildrenCommand()
		{
			if (AdultCount > 1)
				AdultCount = AdultCount - 1;
		}
		#endregion

		#region Properties.
		private int adultCount;
		public int AdultCount
		{
			get => adultCount;
			set
			{
				adultCount = value;
				OnPropertyChanged("AdultCount");
			}
		}
		public Models.VerifyCheckedInCodeResponse VerifyCheckedInInfo { get; set; }
		#endregion
	}
}
