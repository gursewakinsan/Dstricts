using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DependentsListForCheckinPage : ContentPage
	{
		DependentsListForCheckinPageViewModel viewModel;
		public DependentsListForCheckinPage ()
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new DependentsListForCheckinPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.DependentsListForCheckinDstrictCommand.Execute(null);
		}

		private void OnDependentsForCheckinItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.DependentsListForCheckinDstrictResponse response = e.Item as Models.DependentsListForCheckinDstrictResponse;
			listDependentsForCheckin.SelectedItem = null;
			foreach (var item in viewModel.DependentsListForCheckinInfo)
			{
				if (item.Id.Equals(response.Id))
				{
					item.IsSelect = true;
					if (!btnSubmit.IsVisible)
						btnSubmit.IsVisible = true;
					item.FrameBorderColor = Color.FromHex("#406B4B");
				}
				else
				{
					item.IsSelect = false;
					item.FrameBorderColor = Color.FromHex("#2A2A31");
				}
			}
		}
	}
}