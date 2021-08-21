using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckedInListPage : ContentPage
	{
		CheckedInListPageViewModel loginViewModel;
		public CheckedInListPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = loginViewModel = new CheckedInListPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			Helper.Helper.LoggedInUserId = 229;
			loginViewModel.GetCheckedInCommand.Execute(null);
		}

		private void OnCheckedInItemTapped(object sender, ItemTappedEventArgs e)
		{
			listCheckedIn.SelectedItem = null;
		}
	}
}