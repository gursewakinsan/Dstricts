using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.FittnessAndSpa
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WellnessOpenCalenderInfoPage : ContentPage
	{
		#region Variables.
		WellnessOpenCalenderInfoPageViewModel viewModel;
		#endregion

		#region Constructor.
		public WellnessOpenCalenderInfoPage(Models.WellnessSelectedServiceInfoResponse wellnessSelected)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new WellnessOpenCalenderInfoPageViewModel(this.Navigation);
			viewModel.SelectedWellnessServiceInfo = wellnessSelected;
		}
		#endregion

		#region On Appearing.
		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.AvailableDatesForbookingCommand.Execute(null);
		}
		#endregion

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
				viewModel.WellnessOpenCalenderInfoCommand.Execute(null);
			}
		}
		#endregion
	}
}
