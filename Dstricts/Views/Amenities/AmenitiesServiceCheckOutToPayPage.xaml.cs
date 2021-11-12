using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Amenities
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AmenitiesServiceCheckOutToPayPage : ContentPage
	{
		AmenitiesServiceCheckOutToPayViewModels viewModel;
		public AmenitiesServiceCheckOutToPayPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AmenitiesServiceCheckOutToPayViewModels(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.CartAmenityInfoListCommand.Execute(null);
		}

		private void OnDecreaseAmenityCartItemCountClicked(object sender, System.EventArgs e)
		{
			Button buttonDecreaseCount = sender as Button;
			var amenityItem = buttonDecreaseCount.BindingContext as Models.CartAmenityInfoListResponse;
			if (amenityItem.AminityQuantity == 1)
				viewModel.AmenityCartInfoList.Remove(amenityItem);

			amenityItem.AminityQuantity = amenityItem.AminityQuantity - 1;
			viewModel.UpdateAmenityCartItemCountCommand.Execute(amenityItem);
		}

		private void OnIncreaseAmenityCartItemCountClicked(object sender, System.EventArgs e)
		{
			Button buttonIncreaseCount = sender as Button;
			var amenityItem = buttonIncreaseCount.BindingContext as Models.CartAmenityInfoListResponse;
			amenityItem.AminityQuantity = amenityItem.AminityQuantity + 1;
			viewModel.UpdateAmenityCartItemCountCommand.Execute(amenityItem);
		}

		private void OnRemoveAmenityCartItemClicked(object sender, System.EventArgs e)
		{
			Button buttonDecreaseCount = sender as Button;
			var amenityItem = buttonDecreaseCount.BindingContext as Models.CartAmenityInfoListResponse;
			viewModel.AmenityCartInfoList.Remove(amenityItem);
			amenityItem.AminityQuantity = 0;
			viewModel.UpdateAmenityCartItemCountCommand.Execute(amenityItem);
		}
	}
}