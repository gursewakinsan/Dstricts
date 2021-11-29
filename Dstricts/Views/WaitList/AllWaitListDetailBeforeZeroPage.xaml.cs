using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.WaitList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AllWaitListDetailBeforeZeroPage : ContentPage
	{
		AllWaitListDetailBeforeZeroViewModel viewModel;
		public AllWaitListDetailBeforeZeroPage(Models.UserQueueListResponse waitInfo)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AllWaitListDetailBeforeZeroViewModel(this.Navigation);
			viewModel.SelectedWaitInfo = waitInfo;
		}
	}
}