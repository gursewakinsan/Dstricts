using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoomServiceMenuDetailsPage : ContentPage
	{
		RoomServiceMenuDetailsPageViewModel viewModel;
		public RoomServiceMenuDetailsPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new RoomServiceMenuDetailsPageViewModel(this.Navigation);
		}
	}
}