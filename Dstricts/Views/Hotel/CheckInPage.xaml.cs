using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Threading.Tasks;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckInPage : ContentPage
	{
		CheckInPageViewModel viewModel;
		public CheckInPage ()
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CheckInPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GetCheckInCommand.Execute(null);
		}

		private async void OnGridCheckInTapped(object sender, System.EventArgs e)
		{
			Grid grid = sender as Grid;
			Models.CheckedInResponse checkedIn = grid.BindingContext as Models.CheckedInResponse;
			await OnCheckInListClicked(checkedIn);
		}

		private async void OnLabelCheckInTapped(object sender, System.EventArgs e)
		{
			Label label = sender as Label;
			Models.CheckedInResponse checkedIn = label.BindingContext as Models.CheckedInResponse;
			await OnCheckInListClicked(checkedIn);
		}

		private async void OnFrameCheckInTapped(object sender, System.EventArgs e)
		{
			Frame frame = sender as Frame;
			Models.CheckedInResponse checkedIn = frame.BindingContext as Models.CheckedInResponse;
			await OnCheckInListClicked(checkedIn);
		}
		private async Task OnCheckInListClicked(Models.CheckedInResponse checkedIn)
		{
			if (checkedIn.Enc == 0) //Queue
				await Navigation.PushAsync(new Queue.UserQueueWaitingDetailPage(checkedIn.Id));
			else if (checkedIn.Enc == 1) //Hotel
			{
				Helper.Helper.IsRoomService = checkedIn.RoomService;
				Helper.Helper.HotelCheckedIn = checkedIn.QloudCheckOutId;
				viewModel.HotelDetailsCommand.Execute(null);
			}
			else if (checkedIn.Enc == 2) //Apartment
			{
			}
		}
	}
}