using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class UpdateAdultsInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public UpdateAdultsInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Add Adults Command.
		private ICommand addAdultsCommand;
		public ICommand AddAdultsCommand
		{
			get => addAdultsCommand ?? (addAdultsCommand = new Command(() => ExecuteAddAdultsCommand()));
		}
		private void ExecuteAddAdultsCommand()
		{
			if (AdultCount < VerifyCheckedInInfo.GuestAdult)
			{
				AdultCount = AdultCount + 1;
				TotalCount = TotalCount + 1;
			}
		}
		#endregion

		#region Remove Adults Command.
		private ICommand removeAdultsCommand;
		public ICommand RemoveAdultsCommand
		{
			get => removeAdultsCommand ?? (removeAdultsCommand = new Command(() => ExecuteAdultsChildrenCommand()));
		}
		private void ExecuteAdultsChildrenCommand()
		{
			if (AdultCount > 1)
			{
				AdultCount = AdultCount - 1;
				TotalCount = TotalCount - 1;
			}
		}
		#endregion

		#region Update Guest Record Command.
		private ICommand updateGuestRecordCommand;
		public ICommand UpdateGuestRecordCommand
		{
			get => updateGuestRecordCommand ?? (updateGuestRecordCommand = new Command(async () => await ExecuteUpdateGuestRecordCommand()));
		}
		private async Task ExecuteUpdateGuestRecordCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			int response = await service.UpdateGuestRecordAsync(new Models.UpdateGuestRecordRequest()
			{
				DstrictsUserId = Helper.Helper.LoggedInUserId,
				GuestAdult = AdultCount,
				GuestChildren = 0,
				CheckId = VerifyCheckedInInfo.Id
			});

			if (AdultCount == 1)
			{
				if (Device.RuntimePlatform == Device.iOS)
					await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/CheckedInHotelId/{VerifyCheckedInInfo.Id}");
				else
					await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/CheckedInHotelId/{VerifyCheckedInInfo.Id}");
			}
			else
			{
				VerifyCheckedInInfo.GuestAdult = AdultCount;
				VerifyCheckedInInfo.GuestChildren = 0;
				await Navigation.PushAsync(new Views.Hotel.AdultsAndChildrenInfoPage(VerifyCheckedInInfo));
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private int adultCount;
		public int AdultCount
		{
			get => adultCount;
			set
			{
				adultCount = value;
				OnPropertyChanged("AdultCount");
			}
		}

		private int totalCount;
		public int TotalCount
		{
			get => totalCount;
			set
			{
				totalCount = value;
				OnPropertyChanged("TotalCount");
			}
		}
		public Models.VerifyCheckedInCodeResponse VerifyCheckedInInfo { get; set; }
		#endregion
	}
}
