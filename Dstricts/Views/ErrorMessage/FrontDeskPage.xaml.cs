using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dstricts.Views.ErrorMessage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FrontDeskPage : ContentPage
	{
		public FrontDeskPage ()
		{
			InitializeComponent ();
		}

		private void OnFrontDeskTapped(object sender, EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new Hotel.CheckedInListPage());
		}
	}
}