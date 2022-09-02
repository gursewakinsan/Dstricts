using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

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
			ImageButton imageButton = sender as ImageButton;
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
    }
}