using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using Rg.Plugins.Popup.Pages;

namespace Dstricts.PopupPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddAmenitiesItemToCartPopupPage : PopupPage
	{
		AddAmenitiesItemToCartPopupPageViewModel viewModel;
		public AddAmenitiesItemToCartPopupPage(Models.AmenitiesResponse selectedAmenities)
		{
			InitializeComponent();
			BindingContext = viewModel = new AddAmenitiesItemToCartPopupPageViewModel(this.Navigation);
			viewModel.SelectedAmenitiesService = selectedAmenities;
			if (selectedAmenities.IsOrder == 1)
			{
				lblHeading1.Text = "Please select the number of sewing kits and";
				lblHeading2.Text = "submit the order to us.";

				frameDecreaseAmenities.IsVisible = true;
				btnDecreaseAmenities.IsVisible = true;

				frameIncreaseAmenities.IsVisible = true;
				btnIncreaseAmenities.IsVisible = true;

				viewModel.Quantity = selectedAmenities.Quantity;
			}
			else
			{
				lblHeading1.Text = "Please cofirm the Espresson Maching and";
				lblHeading2.Text = "submit the order to us.";

				frameDecreaseAmenities.IsVisible = false;
				btnDecreaseAmenities.IsVisible = false;

				frameIncreaseAmenities.IsVisible = false;
				btnIncreaseAmenities.IsVisible = false;

				viewModel.Quantity = 1;
			}
		}
	}
}