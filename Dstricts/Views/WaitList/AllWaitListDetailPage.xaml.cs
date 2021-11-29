using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.WaitList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AllWaitListDetailPage : ContentPage
	{
		AllWaitListDetailViewModel viewModel;
		public AllWaitListDetailPage(Models.UserQueueListResponse waitInfo)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AllWaitListDetailViewModel(this.Navigation);
			viewModel.SelectedWaitInfo = waitInfo;
		}
	}
}