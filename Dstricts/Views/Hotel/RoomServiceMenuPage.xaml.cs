using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoomServiceMenuPage : ContentPage
	{
		RoomServiceMenuPageViewModel viewModel;
		public RoomServiceMenuPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new RoomServiceMenuPageViewModel(this.Navigation);
		}
	}
}