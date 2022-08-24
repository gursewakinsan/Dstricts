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
	}
}