using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HotelPage : ContentPage
    {
        HotelPageViewModel viewModel;
        public HotelPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new HotelPageViewModel(this.Navigation);
        }

		#region On Meeting Rooms Clicked.
		private void OnImageMeetingRoomsClicked(object sender, System.EventArgs e)
		{
			ImageButton control = sender as ImageButton;
			OnMeetingRoomsClicked(System.Convert.ToInt32(control.ClassId));
		}

		private void OnLableMeetingRoomsClicked(object sender, System.EventArgs e)
		{
			Label control = sender as Label;
			OnMeetingRoomsClicked(System.Convert.ToInt32(control.ClassId));
		}

		async void OnMeetingRoomsClicked(int id)
		{
			await Navigation.PushAsync(new Venues.VenueInfomationDetailPage(id));
		}
		#endregion
	}
}