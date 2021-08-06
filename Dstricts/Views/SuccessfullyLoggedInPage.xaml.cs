using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dstricts.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SuccessfullyLoggedInPage : ContentPage
	{
		public SuccessfullyLoggedInPage(string userName)
		{
			InitializeComponent();
			lblMessage.Text = $"You have successfully logged in as {userName}";
		}

		private void OnCloseButtonClicked(object sender, System.EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new LoginPage());
		}
	}
}