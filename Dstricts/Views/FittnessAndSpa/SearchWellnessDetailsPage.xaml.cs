using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.FittnessAndSpa
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchWellnessDetailsPage : ContentPage
	{
		SearchWellnessDetailsPageViewModel viewModel;
		public SearchWellnessDetailsPage(Models.SearchUserResponse wellnessSearchInfo)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SearchWellnessDetailsPageViewModel(this.Navigation);
			viewModel.WellnessSearchInfo = wellnessSearchInfo;
			viewModel.IsFollow = System.Convert.ToBoolean(wellnessSearchInfo.IsFollowing);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.WellnessSearchFollowingCountCommand.Execute(null);
		}
	}
}