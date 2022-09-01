using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;

namespace Dstricts.Views.Apartment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SocialPage : ContentPage
    {
        SocialPageViewModel viewModel;
        public SocialPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new SocialPageViewModel(this.Navigation);
			rr();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
		}

        void rr()
		{
			imgUserImage.Source = ImageSource.FromUri(new System.Uri("https://www.qloudid.com/html/usercontent/images/dstricts/ProfileImage1.png"));
			imgCommentImgURL.Source = ImageSource.FromUri(new System.Uri("https://www.qloudid.com/html/usercontent/images/dstricts/ProfileImage2.png"));

            imgUserImage1.Source = ImageSource.FromUri(new System.Uri("https://www.qloudid.com/html/usercontent/images/dstricts/ProfileImage1.png"));
            imgCommentImgURL1.Source = ImageSource.FromUri(new System.Uri("https://www.qloudid.com/html/usercontent/images/dstricts/ProfileImage2.png"));
        }

        private void OnBtnOpenCameraToScanQrCodeClicked(object sender, System.EventArgs e)
        {

        }
    }
}