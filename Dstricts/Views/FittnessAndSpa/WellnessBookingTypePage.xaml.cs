using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.FittnessAndSpa
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WellnessBookingTypePage : ContentPage
	{
		WellnessBookingTypeViewModel viewModel;
		public WellnessBookingTypePage(Models.WellnessServiceInfoCountResponse wellnessType)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new WellnessBookingTypeViewModel(this.Navigation);
			viewModel.WellnessServiceInfoCount = wellnessType;
		}
	}
}