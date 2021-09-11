using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Queue
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserQueueWaitingDetailPage : ContentPage
	{
		UserQueueWaitingDetailPageViewModel viewModel;
		public UserQueueWaitingDetailPage (int id)
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new UserQueueWaitingDetailPageViewModel(this.Navigation);
			viewModel.SelectedUserQueueId = id;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.UserQueueWaitingDetailCommand.Execute(null);
		}
	}
}