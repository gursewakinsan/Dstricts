using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class UpdateChildrenInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public UpdateChildrenInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Add Children Command.
		private ICommand addChildrenCommand;
		public ICommand AddChildrenCommand
		{
			get => addChildrenCommand ?? (addChildrenCommand = new Command( () =>  ExecuteAddChildrenCommand()));
		}
		private void ExecuteAddChildrenCommand()
		{
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
		private int childrenCount = 1;
		public int ChildrenCount
		{
			get => childrenCount;
			set
			{
				childrenCount = value;
				OnPropertyChanged("ChildrenCount");
			}
		}
		#endregion
	}
}
