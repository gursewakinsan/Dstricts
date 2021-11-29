using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.WaitList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AllWaitListDetailInServicingPage : ContentPage
	{
		AllWaitListDetailInServicingPageViewModel viewModel;
		public AllWaitListDetailInServicingPage (Models.UserQueueListResponse waitInfo)
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AllWaitListDetailInServicingPageViewModel(this.Navigation);
			viewModel.SelectedWaitInfo = waitInfo;
		}
	}
}