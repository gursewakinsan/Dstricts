using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class UpdateAdultsAndChildrenInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public UpdateAdultsAndChildrenInfoPageViewModel(INavigation navigation)
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
			if (AdultesCount < VerifyCheckedInInfo.GuestAdult)
			{
				AdultesCount = AdultesCount + 1;
				TotalCount = TotalCount + 1;
			}
		}
		#endregion

		#region Remove Adults Command.
		private ICommand removeAdultsCommand;
		public ICommand RemoveAdultsCommand
		{
			get => removeAdultsCommand ?? (removeAdultsCommand = new Command(() => ExecuteRemoveAdultsCommand()));
		}
		private void ExecuteRemoveAdultsCommand()
		{
			if (AdultesCount > 1)
			{
				AdultesCount = AdultesCount - 1;
				TotalCount = TotalCount - 1;
			}
		}
		#endregion

		#region Add Children Command.
		private ICommand addChildrenCommand;
		public ICommand AddChildrenCommand
		{
			get => addChildrenCommand ?? (addChildrenCommand = new Command(() => ExecuteAddChildrenCommand()));
		}
		private void ExecuteAddChildrenCommand()
		{
			if (ChildrenCount < VerifyCheckedInInfo.GuestChildren)
			{
				ChildrenCount = ChildrenCount + 1;
				TotalCount = TotalCount + 1;
			}
		}
		#endregion

		#region Remove Children Command.
		private ICommand removeChildrenCommand;
		public ICommand RemoveChildrenCommand
		{
			get => removeChildrenCommand ?? (removeChildrenCommand = new Command(() => ExecuteRemoveChildrenCommand()));
		}
		private void ExecuteRemoveChildrenCommand()
		{
			if (ChildrenCount > 0)
			{
				ChildrenCount = ChildrenCount - 1;
				TotalCount = TotalCount - 1;
			}
		}
		#endregion

		#region Update Guest Record Command.
		private ICommand updateGuestRecordCommand;
		public ICommand UpdateGuestRecordCommand
		{
			get => updateGuestRecordCommand ?? (updateGuestRecordCommand = new Command(async() =>await ExecuteUpdateGuestRecordCommand()));
		}
		private async Task ExecuteUpdateGuestRecordCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			int response = await service.UpdateGuestRecordAsync(new Models.UpdateGuestRecordRequest()
			{
				DstrictsUserId = Helper.Helper.LoggedInUserId,
				GuestAdult = AdultesCount,
				GuestChildren = ChildrenCount,
				CheckId = VerifyCheckedInInfo.Id
			});

			if (AdultesCount == 1 && ChildrenCount == 0)
			{
				if (Device.RuntimePlatform == Device.iOS)
					await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/CheckedInHotelId/{VerifyCheckedInInfo.Id}");
				else
					await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/CheckedInHotelId/{VerifyCheckedInInfo.Id}");
			}
			else
			{
				VerifyCheckedInInfo.GuestAdult = AdultesCount;
				VerifyCheckedInInfo.GuestChildren = ChildrenCount;
				await Navigation.PushAsync(new Views.Hotel.AdultsAndChildrenInfoPage(VerifyCheckedInInfo));
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private int adultesCount;
		public int AdultesCount
		{
			get => adultesCount;
			set
			{
				adultesCount = value;
				OnPropertyChanged("AdultesCount");
			}
		}

		private int childrenCount;
		public int ChildrenCount
		{
			get => childrenCount;
			set
			{
				childrenCount = value;
				OnPropertyChanged("ChildrenCount");
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
