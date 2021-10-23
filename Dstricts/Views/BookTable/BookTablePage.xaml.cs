using Xamarin.Forms;
using Dstricts.Controls;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.BookTable
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookTablePage : ContentPage
	{
		BookTablePageViewModel viewModel;
		public BookTablePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new BookTablePageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.ResturantWorkInfoCommand.Execute(null);
		}

		private void OnTypeSelectedIndexChanged(object sender, System.EventArgs e)
		{
			CustomPicker picker = sender as CustomPicker;
			if (picker.SelectedIndex == -1)
				return; 
			else
				viewModel.ResturantTableAvailableCommand.Execute(null);
		}

		private void OnBookTableDateSelected(object sender, DateChangedEventArgs e)
		{
			viewModel.ResturantTableAvailableCommand.Execute(null);
		}

		private void OnWorkTimeClicked(object sender, System.EventArgs e)
		{
			Button button = sender as Button;
			Models.ResturantTableAvailableResponse resturant = button.BindingContext as Models.ResturantTableAvailableResponse;
			foreach (var item in viewModel.ResturantTableAvailableInfo)
			{
				if (item.Id.Equals(resturant.Id))
				{
					if (item.IsSelected)
					{
						viewModel.IsVisibleSubmit = false;
						item.IsSelected = false;
						item.SelectedWorkTimeBg = Color.FromHex("#2A2B30");
					}
					else
					{
						viewModel.SelectedTimeDetail = item.Id;
						viewModel.IsVisibleSubmit = true;
						item.IsSelected = true;
						item.SelectedWorkTimeBg = Color.FromHex("#6263ED");
					}
				}
				else
				{
					item.IsSelected = false;
					item.SelectedWorkTimeBg = Color.FromHex("#2A2B30");
				}
			}
		}

		private void listView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
		{
			listView.SelectedItem = null;
		}
	}
}