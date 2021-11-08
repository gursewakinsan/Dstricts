using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;

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
	}
}