using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoomServiceMenuPage : ContentPage
	{
		RoomServiceMenuPageViewModel viewModel;
		public RoomServiceMenuPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			imgFood.Source = ImageSource.FromUri(new System.Uri("https://www.qloudid.com/html/usercontent/images/roomserviceImages/heading.jpg"));
			BindingContext = viewModel = new RoomServiceMenuPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.IsProceedToCheckOut = Helper.Helper.IsProceedToCheckOut;
			viewModel.GetRoomServiceMenuCommand.Execute(null);
		}

		private void OnRoomServiceMenuCategoryTapped(object sender, System.EventArgs e)
		{
			Grid categoryGrid = sender as Grid;
			Helper.Helper.SelectedRoomServiceMenuCategory = categoryGrid.BindingContext as CategoryInfo;
			viewModel.SelectedRoomServiceMenuCategoryCommand.Execute(null);
		}
	}
}