using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.FittnessAndSpa
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WellnessSelectedServiceInfoPage : ContentPage
	{
		WellnessSelectedServiceInfoPageViewModel viewModel;
		public WellnessSelectedServiceInfoPage(int dishId)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new WellnessSelectedServiceInfoPageViewModel(this.Navigation);
			viewModel.DishId = dishId;
			viewModel.WellnessSelectedServiceInfoCommand.Execute(null);
		}
	}
}