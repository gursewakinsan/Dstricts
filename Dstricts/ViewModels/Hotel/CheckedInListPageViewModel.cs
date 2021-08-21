using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class CheckedInListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CheckedInListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Checked In Command.
		private ICommand getCheckedInCommand;
		public ICommand GetCheckedInCommand
		{
			get => getCheckedInCommand ?? (getCheckedInCommand = new Command(async () => await ExecuteGetCheckedInCommand()));
		}
		private async Task ExecuteGetCheckedInCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			List<Models.CheckedInResponse> checkedIns = new List<Models.CheckedInResponse>();
			var responseCheckedIn = await service.CheckedInHotelAsync(new Models.CheckedInRequest()
			{
				UserId = Helper.Helper.LoggedInUserId
			});

			var responseCheckedInApartment = await service.CheckedInApartmentAsync(new Models.CheckedInRequest()
			{
				UserId = Helper.Helper.LoggedInUserId
			});

			if (responseCheckedIn?.Count > 0)
			{
				foreach (var item in responseCheckedIn)
					checkedIns.Add(item);
			}

			if (responseCheckedInApartment?.Count > 0)
			{
				foreach (var item in responseCheckedInApartment)
					checkedIns.Add(item);
			}
			CheckedInList = checkedIns;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Verify Checked In Code Command.
		private ICommand verifyCheckedInCodeCommand;
		public ICommand VerifyCheckedInCodeCommand
		{
			get => verifyCheckedInCodeCommand ?? (verifyCheckedInCodeCommand = new Command(async () => await ExecuteVerifyCheckedInCodeCommand()));
		}
		private async Task ExecuteVerifyCheckedInCodeCommand()
		{
			if (string.IsNullOrWhiteSpace(CheckedInCodeInEmail))
				await Helper.Alert.DisplayAlert("Code is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IHotelService service = new HotelService();
				int response = await service.VerifyCheckedInCodeAsync(new Models.VerifyCheckedInCodeRequest()
				{
					UserId = Helper.Helper.LoggedInUserId,
					Ecode = CheckedInCodeInEmail
				});
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		private List<Models.CheckedInResponse> checkedInList;
		public List<Models.CheckedInResponse> CheckedInList
		{
			get => checkedInList;
			set
			{
				checkedInList = value;
				OnPropertyChanged("CheckedInList");
			}
		}

		private string checkedInCodeInEmail;
		public string CheckedInCodeInEmail
		{
			get => checkedInCodeInEmail;
			set
			{
				checkedInCodeInEmail = value;
				OnPropertyChanged("CheckedInCodeInEmail");
			}
		}
		#endregion
	}
}
