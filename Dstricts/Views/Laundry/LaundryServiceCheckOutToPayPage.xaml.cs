using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Laundry
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LaundryServiceCheckOutToPayPage : ContentPage
	{
		LaundryServiceCheckOutToPayViewModel viewModel;
		public LaundryServiceCheckOutToPayPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new LaundryServiceCheckOutToPayViewModel(this.Navigation);
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.LaundryCartInfoListCommand.Execute(null);
		}
	}
}