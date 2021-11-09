using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;

namespace Dstricts.Views.Laundry
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LaundryServicePage : ContentPage
	{
		LaundryServicePageViewModel viewModel;
		public LaundryServicePage(List<Models.SelectedLaundaryCategoriesResponse> selectedLaundary)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new LaundryServicePageViewModel(this.Navigation);
			viewModel.LaundryServiceList = selectedLaundary;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.SelectedDryCleaningServeBasedAppMenuCommand.Execute(null);
		}
		private void OnLaundryServiceClicked(object sender, System.EventArgs e)
		{
			Button button = sender as Button;
			var selected = button.BindingContext as Models.SelectedLaundaryCategoriesResponse;
			if (!selected.IsSelectedRoomService)
			{
				foreach (var item in viewModel.LaundryServiceList)
				{
					item.IsSelectedRoomService = false;
					item.SelectedRoomServiceBg = Color.FromHex("#2A2A31");
				}
				selected.IsSelectedRoomService = true;
				selected.SelectedRoomServiceBg = Color.FromHex("#6263ED");
				viewModel.SelectedDryCleaningServeBasedAppMenuCommand.Execute(null);
			}
		}

		private async void OnGridDryCleaningItemTapped(object sender, System.EventArgs e)
		{
			Grid grid = sender as Grid;
			Models.SelectedDryCleaningServeBasedAppMenuResponse selectedDryCleaning = grid.BindingContext as Models.SelectedDryCleaningServeBasedAppMenuResponse;
			selectedDryCleaning.CallBack = DryCleaningCallBack;
			await Navigation.PushPopupAsync(new PopupPages.AddLaundryItemToCartPopupPage(selectedDryCleaning));
		}

		private void DryCleaningCallBack()
		{
			var service = viewModel.SelectedDryCleaningServeList.FirstOrDefault(x => x.DishQuantity != 0);
			if (service == null)
				viewModel.IsCheckOut = false;
			else
				viewModel.IsCheckOut = true;
		}

		private async void OnFrameDryCleaningItemTapped(object sender, System.EventArgs e)
		{
			Frame frame = sender as Frame;
			Models.SelectedDryCleaningServeBasedAppMenuResponse selectedDryCleaning = frame.BindingContext as Models.SelectedDryCleaningServeBasedAppMenuResponse;
			selectedDryCleaning.CallBack = DryCleaningCallBack;
			await Navigation.PushPopupAsync(new PopupPages.AddLaundryItemToCartPopupPage(selectedDryCleaning));
		}
	}
}