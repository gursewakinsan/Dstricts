using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerifyCheckedInPage : ContentPage
	{
		VerifyCheckedInPageViewModel viewModel;
		public VerifyCheckedInPage(int hotelPropertyType)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new VerifyCheckedInPageViewModel(this.Navigation);
			viewModel.HotelPropertyType = hotelPropertyType;
		}
	}
}