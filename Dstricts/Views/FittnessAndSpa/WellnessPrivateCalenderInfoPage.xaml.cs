using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.FittnessAndSpa
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WellnessPrivateCalenderInfoPage : ContentPage
	{
		WellnessPrivateCalenderInfoViewModel viewModel;
		public WellnessPrivateCalenderInfoPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new WellnessPrivateCalenderInfoViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.SelectEmployeeForSelectedServicesCommand.Execute(null);
		}

		#region Pick a date clicked.
		private void PickDateFrameTapped(object sender, System.EventArgs e)
		{
			Frame frame = sender as Frame;
			Models.AvailableDatesForbookingResponse available = frame.BindingContext as Models.AvailableDatesForbookingResponse;
			SelectedDate(available);
		}

		private void PickDateStackLayoutTapped(object sender, System.EventArgs e)
		{
			StackLayout layout = sender as StackLayout;
			Models.AvailableDatesForbookingResponse available = layout.BindingContext as Models.AvailableDatesForbookingResponse;
			SelectedDate(available);
		}

		private void PickDateLabelTapped(object sender, System.EventArgs e)
		{
			Label label = sender as Label;
			Models.AvailableDatesForbookingResponse available = label.BindingContext as Models.AvailableDatesForbookingResponse;
			SelectedDate(available);
		}

		private void SelectedDate(Models.AvailableDatesForbookingResponse available)
		{
			if (available != null)
			{
				foreach (var availableDates in viewModel.AvailableDatesForbookingList)
				{
					if (availableDates.DateId.Equals(available.DateId))
					{
						availableDates.PickDateBorderColor = Color.FromHex("#6263ED");
						availableDates.DisplayDateColor = Color.FromHex("#6263ED");
						availableDates.DisplayMonthColor = Color.FromHex("#6263ED");
					}
					else
					{
						availableDates.PickDateBorderColor = Color.FromHex("#2A2A31");
						availableDates.DisplayDateColor = Color.White;
						availableDates.DisplayMonthColor = Color.FromHex("#2A2A31");
					}
				}
				viewModel.DateId = available.DateId;
				viewModel.EmployeeBookingCalenderInfoAppCommand.Execute(null);
			}
		}
		#endregion

		#region Pick a calendar clicked.
		private void OnUserImageClicked(object sender, System.EventArgs e)
		{
			ImageButton imageButton = sender as ImageButton;
			Models.SelectEmployeeForSelectedServicesResponse select = imageButton.BindingContext as Models.SelectEmployeeForSelectedServicesResponse;
			UserSelected(select);
		}
		private void OnUserNameTapped(object sender, System.EventArgs e)
		{
			Label label = sender as Label;
			Models.SelectEmployeeForSelectedServicesResponse select = label.BindingContext as Models.SelectEmployeeForSelectedServicesResponse;
			UserSelected(select);
		}
		private void UserSelected(Models.SelectEmployeeForSelectedServicesResponse select)
		{
			if (select != null)
			{
				foreach (var selectedItem in viewModel.SelectEmployeeForSelectedServicesList)
				{
					if (selectedItem.Id.Equals(select.Id))
						selectedItem.UserImageBorderColor = Color.FromHex("#2A2A31");
					else
						selectedItem.UserImageBorderColor = Color.Transparent;
				}
				viewModel.EmployeeId = select.Id;
				viewModel.EmployeeBookingCalenderInfoAppCommand.Execute(null);
			}
		}

		private void OnAllUserClicked(object sender, System.EventArgs e)
		{
			foreach (var selectedItem in viewModel.SelectEmployeeForSelectedServicesList)
				selectedItem.UserImageBorderColor = Color.Transparent;
			viewModel.EmployeeId = 0;
			viewModel.EmployeeBookingCalenderInfoAppCommand.Execute(null);
		}
		#endregion

		#region On List View Item Tapped.
		private void OnListViewItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
		{
			listView.SelectedItem = null;
			listView.BackgroundColor = Color.FromHex("#181A1F");
		}
		#endregion

		#region On Pick Time Clicked.
		private void OnPickTimeClicked(object sender, System.EventArgs e)
		{
			Button button = sender as Button;
			Models.EmployeeBookingCalenderInfoAppResponse bookTime = button.BindingContext as Models.EmployeeBookingCalenderInfoAppResponse;
			foreach (var item in viewModel.EmployeeBookingCalenderInfo)
			{
				if (item.Id.Equals(bookTime.Id))
				{
					if (item.IsSelected)
					{
						item.IsSelected = false;
						item.SelectedTimeBg = Color.FromHex("#2A2B30");
						viewModel.SelectedBookingTime = null;
					}
					else
					{
						item.IsSelected = true;
						item.SelectedTimeBg = Color.FromHex("#6263ED");
						viewModel.SelectedBookingTime = bookTime;
					}
				}
				else
				{
					item.IsSelected = false;
					item.SelectedTimeBg = Color.FromHex("#2A2B30");
				}
			}
		}
		#endregion
	}
}