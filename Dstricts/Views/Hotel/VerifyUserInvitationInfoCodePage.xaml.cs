using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerifyUserInvitationInfoCodePage : ContentPage
	{
		VerifyUserInvitationInfoCodeViewModel viewModel;
		public VerifyUserInvitationInfoCodePage (int verifyUserInvitationInfoCode)
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new VerifyUserInvitationInfoCodeViewModel(this.Navigation);
			viewModel.VerifyUserInvitationInfoCode = verifyUserInvitationInfoCode;
		}
	}
}