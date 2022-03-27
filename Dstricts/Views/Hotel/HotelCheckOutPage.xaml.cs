using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HotelCheckOutPage : ContentPage
	{
		HotelCheckOutPageViewModel viewModel;
		public HotelCheckOutPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new HotelCheckOutPageViewModel(this.Navigation);
			viewModel.YesPleaseClickedCommand.Execute(null);
		}
	}
}