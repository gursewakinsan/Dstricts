using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Venues
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VenueInfomationDetailPage : ContentPage
	{
		VenueInfomationDetailPageViewModel viewModel;
		public VenueInfomationDetailPage(int venueId)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new VenueInfomationDetailPageViewModel(this.Navigation);
			viewModel.VenueId = venueId;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			lblFoodAndDrinks.Text = "Food & Drinks";
			viewModel.VenueInfomationDetailCommand.Execute(null);
		}
	}
}