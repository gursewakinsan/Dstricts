using System;
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
			//if (CheckedInList?.Count > 0) return;
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

			var responseUserQueueListAsync = await service.UserQueueListAsync(new Models.CheckedInRequest()
			{
				UserId = Helper.Helper.LoggedInUserId
			});
			
			if (responseCheckedIn?.Count > 0)
			{
				foreach (var item in responseCheckedIn)
					if (item != null)
						checkedIns.Add(item);
			}

			if (responseCheckedInApartment?.Count > 0)
			{
				foreach (var item in responseCheckedInApartment)
					if (item != null)
						checkedIns.Add(item);
			}

			if (responseUserQueueListAsync?.Count > 0)
			{
				foreach (var item in responseUserQueueListAsync)
					if (item != null)
						checkedIns.Add(item);
			}

			CheckedInList = checkedIns;
			IsListEmpty = CheckedInList?.Count > 0 ? true : false;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Verify QR Code Command.
		private ICommand verifyQrCodeCommand;
		public ICommand VerifyQrCodeCommand
		{
			get => verifyQrCodeCommand ?? (verifyQrCodeCommand = new Command<string>(async (qrCode) => await ExecuteVerifyQrCodeCommand(qrCode)));
		}
		private async Task ExecuteVerifyQrCodeCommand(string qrCode)
		{
			string[] codeInfo = qrCode.Split('/');
			switch (codeInfo[0])
			{
				case "verify_checkin":
					HotelPropertyType = Convert.ToInt32(codeInfo[1]);
					GoToVerifyCheckedInCodePageCommand.Execute(null);
					break;
				case "getQueue":
					Helper.Helper.AvalibleQueueId = codeInfo[1];
					await Navigation.PushAsync(new Views.Queue.AvalibleQueueOnTheLocationPage());
					break;
			}
			await Task.CompletedTask;
		}
		#endregion

		#region Go To Verify Checked In Code Page Command.
		private ICommand goToVerifyCheckedInCodePageCommand;
		public ICommand GoToVerifyCheckedInCodePageCommand
		{
			get => goToVerifyCheckedInCodePageCommand ?? (goToVerifyCheckedInCodePageCommand = new Command(async () => await ExecuteGoToVerifyCheckedInCodePageCommand()));
		}
		private async Task ExecuteGoToVerifyCheckedInCodePageCommand()
		{
			await Navigation.PushAsync(new Views.Hotel.VerifyCheckedInPage(HotelPropertyType));
		}
		#endregion

		#region Hotel Details Command.
		private ICommand hotelDetailsCommand;
		public ICommand HotelDetailsCommand
		{
			get => hotelDetailsCommand ?? (hotelDetailsCommand = new Command(async () => await ExecuteHotelDetailsCommand()));
		}
		private async Task ExecuteHotelDetailsCommand()
		{
			await Navigation.PushAsync(new Views.Hotel.HotelDetailsPage());
		}
		#endregion

		#region Search Command.
		private ICommand searchCommand;
		public ICommand SearchCommand
		{
			get => searchCommand ?? (searchCommand = new Command(async () => await ExecuteSearchCommand()));
		}
		private async Task ExecuteSearchCommand()
		{
			await Navigation.PushAsync(new Views.SearchHotel.SearchHotelByTypePage());
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

		private bool isListEmpty = true;
		public bool IsListEmpty
		{
			get => isListEmpty;
			set
			{
				isListEmpty = value;
				OnPropertyChanged("IsListEmpty");
			}
		}

		public int HotelPropertyType { get; set; }
		#endregion
	}
}

