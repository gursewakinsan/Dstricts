using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InviteAdultsByPhonePage : ContentPage
	{
		InviteAdultsByPhonePageViewModel viewModel;
		public InviteAdultsByPhonePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new InviteAdultsByPhonePageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.CountryCodeListCommand.Execute(null);
		}

		private void OnCountryCodeSelectedIndexChanged(object sender, System.EventArgs e)
		{
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (picker.SelectedIndex == -1)
				return;
		}
	}
}