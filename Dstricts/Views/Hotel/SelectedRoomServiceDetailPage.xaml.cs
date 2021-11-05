using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectedRoomServiceDetailPage : ContentPage
	{
		SelectedRoomServiceDetailPageViewModel viewModel;
		public SelectedRoomServiceDetailPage (List<Models.SelectedRoomServiceAppServesResponse> selectedRoomService)
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SelectedRoomServiceDetailPageViewModel(this.Navigation);
			int deviceWidth = App.ScreenWidth - 56;
			int w = deviceWidth * 26 / 100;
			foreach (var item in selectedRoomService)
				item.ImgWidth = w;
			viewModel.RoomServiceList = selectedRoomService;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.SelectedRoomServiceServeBasedAppMenuCommand.Execute(null);
		}

		private void OnRoomServiceClicked(object sender, System.EventArgs e)
		{
			Button button = sender as Button;
			var selected = button.BindingContext as Models.SelectedRoomServiceAppServesResponse;
			if (!selected.IsSelectedRoomService)
			{
				foreach (var item in viewModel.RoomServiceList)
				{
					item.IsSelectedRoomService = false;
					item.SelectedRoomServiceBg = Color.FromHex("#2A2A31");
				}
				selected.IsSelectedRoomService = true;
				selected.SelectedRoomServiceBg = Color.FromHex("#6263ED");
				viewModel.SelectedRoomServiceServeBasedAppMenuCommand.Execute(null);
			}
		}
	}
}