using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;

namespace Dstricts.Views.WaitList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WaitListResturantPage : ContentPage
	{
		WaitListResturantPageViewModel viewModel;
		public WaitListResturantPage(List<Models.WaitListResturantResponse> waitListResturants)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new WaitListResturantPageViewModel(this.Navigation);
			viewModel.WaitListResturantInfo = waitListResturants;
		}

		private async void OnGridWaitListResturantTapped(object sender, System.EventArgs e)
		{
			Grid grid = sender as Grid;
			Models.WaitListResturantResponse selectedWaitListResturant = grid.BindingContext as Models.WaitListResturantResponse;
			await Navigation.PushAsync(new WaitListResturantDetailPage(selectedWaitListResturant));
		}

		private async void OnFrameWaitListResturantTapped(object sender, System.EventArgs e)
		{
			Frame frame = sender as Frame;
			Models.WaitListResturantResponse selectedWaitListResturant = frame.BindingContext as Models.WaitListResturantResponse;
			await Navigation.PushAsync(new WaitListResturantDetailPage(selectedWaitListResturant));
		}
	}
}