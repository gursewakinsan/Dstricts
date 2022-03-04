using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UpdateAdultsAndChildrenInfoPage : ContentPage
	{
		UpdateAdultsAndChildrenInfoPageViewModel viewModel;
		public UpdateAdultsAndChildrenInfoPage ()
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new UpdateAdultsAndChildrenInfoPageViewModel(this.Navigation);
		}
	}
}