using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.FittnessAndSpa
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchWellnessDetailsPage : ContentPage
	{
		SearchWellnessDetailsPageViewModel viewModel;
		public SearchWellnessDetailsPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SearchWellnessDetailsPageViewModel(this.Navigation);
		}
	}
}