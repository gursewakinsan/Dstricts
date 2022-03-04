using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UpdateChildrenInfoPage : ContentPage
	{
		UpdateChildrenInfoPageViewModel viewModel;
		public UpdateChildrenInfoPage ()
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new UpdateChildrenInfoPageViewModel(this.Navigation);
		}
	}
}