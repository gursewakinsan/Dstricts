using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dstricts.Views.ErrorMessage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InvitedVisitorsMeetingListNotAvailablePage : ContentPage
	{
		public InvitedVisitorsMeetingListNotAvailablePage()
		{
			InitializeComponent();
		}

		private void OnNotAvailableTapped(object sender, System.EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new Hotel.CheckedInListPage());
		}
	}
}