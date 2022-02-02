using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.FittnessAndSpa
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddServiceToCartAppPage : ContentPage
	{
		AddServiceToCartAppPageViewModel viewModel;
		public AddServiceToCartAppPage(Models.FittnessAndSpaSelectedCategoryResponse fittnessAndSpaInfo)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AddServiceToCartAppPageViewModel(this.Navigation);
			viewModel.SelectedFittnessAndSpaInfo = fittnessAndSpaInfo;
		}
	}
}