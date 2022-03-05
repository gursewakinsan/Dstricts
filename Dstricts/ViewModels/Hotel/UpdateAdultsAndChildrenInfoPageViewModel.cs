using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class UpdateAdultsAndChildrenInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public UpdateAdultsAndChildrenInfoPageViewModel(INavigation navigation)
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
			if (AdultesCount < VerifyCheckedInInfo.GuestAdult)
				AdultesCount = AdultesCount + 1;
		}
		#endregion

		#region Remove Adults Command.
		private ICommand removeAdultsCommand;
		public ICommand RemoveAdultsCommand
		{
			get => removeAdultsCommand ?? (removeAdultsCommand = new Command(() => ExecuteRemoveAdultsCommand()));
		}
		private void ExecuteRemoveAdultsCommand()
		{
			if (AdultesCount > 1)
				AdultesCount = AdultesCount - 1;
		}
		#endregion

		#region Add Children Command.
		private ICommand addChildrenCommand;
		public ICommand AddChildrenCommand
		{
			get => addChildrenCommand ?? (addChildrenCommand = new Command(() => ExecuteAddChildrenCommand()));
		}
		private void ExecuteAddChildrenCommand()
		{
			if (ChildrenCount < VerifyCheckedInInfo.GuestChildren)
				ChildrenCount = ChildrenCount + 1;
		}
		#endregion

		#region Remove Children Command.
		private ICommand removeChildrenCommand;
		public ICommand RemoveChildrenCommand
		{
			get => removeChildrenCommand ?? (removeChildrenCommand = new Command(() => ExecuteRemoveChildrenCommand()));
		}
		private void ExecuteRemoveChildrenCommand()
		{
			if (ChildrenCount > 1)
				ChildrenCount = ChildrenCount - 1;
		}
		#endregion

		#region Properties.
		private int adultesCount;
		public int AdultesCount
		{
			get => adultesCount;
			set
			{
				adultesCount = value;
				OnPropertyChanged("AdultesCount");
			}
		}

		private int childrenCount;
		public int ChildrenCount
		{
			get => childrenCount;
			set
			{
				childrenCount = value;
				OnPropertyChanged("ChildrenCount");
			}
		}

		public Models.VerifyCheckedInCodeResponse VerifyCheckedInInfo { get; set; }
		#endregion
	}
}
