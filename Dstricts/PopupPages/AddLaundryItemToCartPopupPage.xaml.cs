using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using Rg.Plugins.Popup.Pages;

namespace Dstricts.PopupPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddLaundryItemToCartPopupPage : PopupPage
	{
		AddLaundryItemToCartPopupPageViewModel viewModel;
		public AddLaundryItemToCartPopupPage(Models.SelectedDryCleaningServeBasedAppMenuResponse selectedDryCleaningServe)
		{
			InitializeComponent();
			BindingContext = viewModel = new AddLaundryItemToCartPopupPageViewModel(this.Navigation);
			viewModel.SelectedDryCleaningService = selectedDryCleaningServe;
			viewModel.DishQuantity = selectedDryCleaningServe.DishQuantity;
			lblHeading1.Text = $"Please select the number of {selectedDryCleaningServe.DishName} and submit the order to us.";
		}
	}
}