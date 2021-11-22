using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.WaitList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WaitListResturantDetailPage : ContentPage
	{
		WaitListResturantDetailPageViewModel viewModel;
		public WaitListResturantDetailPage(Models.WaitListResturantResponse waitResturants)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new WaitListResturantDetailPageViewModel(this.Navigation);
			viewModel.SelectedWaitResturantInfo = waitResturants;
		}
	}
}