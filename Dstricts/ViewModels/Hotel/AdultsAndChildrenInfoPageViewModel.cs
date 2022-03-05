using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class AdultsAndChildrenInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AdultsAndChildrenInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Properties.
		private int totalCount;
		public int TotalCount
		{
			get => totalCount;
			set
			{
				totalCount = value;
				OnPropertyChanged("TotalCount");
			}
		}
		public string UserName => Helper.Helper.LoggedInUserName;
		public Models.VerifyCheckedInCodeResponse VerifyCheckedInInfo { get; set; }
		#endregion
	}
}
