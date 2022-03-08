using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InviteAdultsByPhonePage : ContentPage
	{
		InviteAdultsByPhonePageViewModel viewModel;
		public InviteAdultsByPhonePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new InviteAdultsByPhonePageViewModel(this.Navigation);
		}
	}
}