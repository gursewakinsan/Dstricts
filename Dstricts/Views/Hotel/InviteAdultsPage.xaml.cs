using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InviteAdultsPage : ContentPage
	{
		InviteAdultsPageViewModel viewModel;
		public InviteAdultsPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new InviteAdultsPageViewModel(this.Navigation);
		}
	}
}