using Xamarin.Forms;

namespace Dstricts
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			MainPage = new Views.LoginPage();
		}
	}
}
