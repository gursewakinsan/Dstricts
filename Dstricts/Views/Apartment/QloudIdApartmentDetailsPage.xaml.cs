using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using Dstricts.Views.Community;

namespace Dstricts.Views.Apartment
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QloudIdApartmentDetailsPage : ContentPage
	{
		QloudIdApartmentDetailsPageViewModel viewModel;
		public QloudIdApartmentDetailsPage(Models.CheckedInResponse apartmentDetails)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new QloudIdApartmentDetailsPageViewModel(this.Navigation);
			viewModel.ApartmentDetails = apartmentDetails;
			Helper.Helper.IsGuest = apartmentDetails.IsGuest;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.ApartmentDetailInfoCommand.Execute(null);
			/*imgVacation.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/1.png";
			imgRoom.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/4.png";
			imgBed.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/5.png";
			imgMedia.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/1.png";
			imgBathroom.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/7.png";
			lblMedicalAndHealth.Text = "Medical & Health";
			lblGetPhoneAddressHere.Text = "Get phone & address here";*/
		}

		#region On How To Switch Info Item Clicked.
		private async void OnHowToSwitchInfoItemClicked(object sender, System.EventArgs e)
        {
			Button button = sender as Button;
			Models.GetSratedDetailResponse response = button.BindingContext as Models.GetSratedDetailResponse;
            foreach (var switchInfo in viewModel.HowToSwitchInfo)
            {
				if (switchInfo.Id.Equals(response.Id))
					switchInfo.IsSelected = true;
				else
					switchInfo.IsSelected = false;
			}
			await Navigation.PushAsync(new HowToSwitchPage(viewModel.HowToSwitchInfo));
		}

		async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
		{
			Label label = sender as Label;
			Models.GetSratedDetailResponse response = label.BindingContext as Models.GetSratedDetailResponse;
			foreach (var switchInfo in viewModel.HowToSwitchInfo)
			{
				if (switchInfo.Id.Equals(response.Id))
					switchInfo.IsSelected = true;
				else
					switchInfo.IsSelected = false;
			}
			await Navigation.PushAsync(new HowToSwitchPage(viewModel.HowToSwitchInfo));
		}
		#endregion

		#region On How To Use Info Item Clicked.
		private async void OnHowToUseInfoItemClicked(object sender, System.EventArgs e)
        {
			Button imageButton = sender as Button;
			Models.GetSratedDetailResponse response = imageButton.BindingContext as Models.GetSratedDetailResponse;
			foreach (var switchInfo in viewModel.HowToUseInfo)
			{
				if (switchInfo.Id.Equals(response.Id))
					switchInfo.IsSelected = true;
				else
					switchInfo.IsSelected = false;
			}
			await Navigation.PushAsync(new HowToSwitchPage(viewModel.HowToUseInfo));
		}
		#endregion

		#region On Amenities Clicked.
		private void OnAmenitiesImageButtonClicked(object sender, System.EventArgs e)
        {
			ImageButton control = (ImageButton)sender;
			OnAmenitiesClicked(control.BindingContext as Models.ApartmentCommunity, control.ClassId);
		}

        private void OnAmenitiesStackLayoutClicked(object sender, System.EventArgs e)
        {
			StackLayout control = (StackLayout)sender;
			OnAmenitiesClicked(control.BindingContext as Models.ApartmentCommunity, control.ClassId);
		}

        private void OnAmenitiesLabelClicked(object sender, System.EventArgs e)
        {
			Label control = (Label)sender;
			OnAmenitiesClicked(control.BindingContext as Models.ApartmentCommunity, control.ClassId);
		}

		async void OnAmenitiesClicked(Models.ApartmentCommunity community, string selectedCommunity)
		{
            switch (selectedCommunity)
            {
				case "Amenities":
					foreach (var amenity in viewModel.AmenitiesListInfo)
					{
						if (amenity.Id.Equals(community.Id))
							amenity.IsSelected = true;
						else
							amenity.IsSelected = false;
					}
					await Navigation.PushAsync(new BuildingSelectedAmenitiesInfoPage(viewModel.AmenitiesListInfo));
					break;

				case "Storage":
					foreach (var amenity in viewModel.StorageAmenitiesListInfo)
					{
						if (amenity.Id.Equals(community.Id))
							amenity.IsSelected = true;
						else
							amenity.IsSelected = false;
					}
					await Navigation.PushAsync(new BuildingSelectedAmenitiesInfoPage(viewModel.StorageAmenitiesListInfo));
					break;

				case "TrashAndRecycle":
					foreach (var amenity in viewModel.TrashRecycleListInfo)
					{
						if (amenity.Id.Equals(community.Id))
							amenity.IsSelected = true;
						else
							amenity.IsSelected = false;
					}
					await Navigation.PushAsync(new BuildingSelectedAmenitiesInfoPage(viewModel.TrashRecycleListInfo));
					break;
			}
		}
		#endregion

		#region On Parkering Image Clicked
		private void OnImageButtonParkeringListClicked(object sender, System.EventArgs e)
		{
			ImageButton control = (ImageButton)sender;
			OnParkeringClicked(control.BindingContext as Models.ApartmentCommunityParkingsResponse);
		}

		private void OnStackLayoutParkeringListClicked(object sender, System.EventArgs e)
		{
			StackLayout control = (StackLayout)sender;
			OnParkeringClicked(control.BindingContext as Models.ApartmentCommunityParkingsResponse);
		}

		private void OnLabelParkeringListClicked(object sender, System.EventArgs e)
		{
			Label control = (Label)sender;
			OnParkeringClicked(control.BindingContext as Models.ApartmentCommunityParkingsResponse);
		}

		async void OnParkeringClicked(Models.ApartmentCommunityParkingsResponse parking)
		{
			foreach (var amenity in viewModel.ParkeringList)
			{
				if (amenity.Id.Equals(parking.Id))
					amenity.IsSelected = true;
				else
					amenity.IsSelected = false;
			}
			await Navigation.PushAsync(new SelectedParkingDetailPage(viewModel.ParkeringList));
		}
		#endregion
	}
}