using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Dstricts.ViewModels
{
	public class AmenitiesServiceCheckOutToPayViewModels : BaseViewModel
	{
		#region Constructor.
		public AmenitiesServiceCheckOutToPayViewModels(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Cart Amenity Info List Command.
		private ICommand cartAmenityInfoListCommand;
		public ICommand CartAmenityInfoListCommand
		{
			get => cartAmenityInfoListCommand ?? (cartAmenityInfoListCommand = new Command(async () => await ExecuteCartAmenityInfoListCommand()));
		}
		private async Task ExecuteCartAmenityInfoListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IAmenitiesService service = new AmenitiesService();
			var amenityCartInfoList = await service.CartAmenityInfoListAsync(new Models.CartAmenityInfoListRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn,
			});
			AmenityCartInfoList = new ObservableCollection<Models.CartAmenityInfoListResponse>(amenityCartInfoList);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Update Amenity Cart Item Count Command.
		private ICommand updateAmenityCartItemCountCommand;
		public ICommand UpdateAmenityCartItemCountCommand
		{
			get => updateAmenityCartItemCountCommand ?? (updateAmenityCartItemCountCommand = new Command<Models.CartAmenityInfoListResponse>(async (amenityCartItem) => await ExecuteUpdateAmenityCartItemCountCommand(amenityCartItem)));
		}
		private async Task ExecuteUpdateAmenityCartItemCountCommand(Models.CartAmenityInfoListResponse amenityCartItem)
		{
			DependencyService.Get<IProgressBar>().Show();
			IAmenitiesService service = new AmenitiesService();
			var response = await service.UpdateAmenityCartItemCountAsync(new Models.UpdateAmenityCartItemCountRequest()
			{
				Id = amenityCartItem.Id,
				Quantity = amenityCartItem.AminityQuantity
			});
			if (AmenityCartInfoList.Count == 0)
				await Navigation.PopAsync();
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Add To Room Command.
		private ICommand addToRoomCommand;
		public ICommand AddToRoomCommand
		{
			get => addToRoomCommand ?? (addToRoomCommand = new Command(async () => await ExecuteAddToRoomCommand()));
		}
		private async Task ExecuteAddToRoomCommand()
		{
			Models.PayOnRequest payOnRequest = new Models.PayOnRequest()
			{
				CheckedInId = Helper.Helper.HotelCheckedIn,
				ServiceType = 3,
				QloudIdPay = 2
			};
			string payJson = Newtonsoft.Json.JsonConvert.SerializeObject(payOnRequest);
			if (Device.RuntimePlatform == Device.iOS)
				await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/DstrictsAppPayOn/{payJson}");
			else
				await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/DstrictsAppPayOn/{payJson}");
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.CartAmenityInfoListResponse> amenityCartInfoList;
		public ObservableCollection<Models.CartAmenityInfoListResponse> AmenityCartInfoList
		{
			get => amenityCartInfoList;
			set
			{
				amenityCartInfoList = value;
				OnPropertyChanged("AmenityCartInfoList");
			}
		}
		#endregion
	}
}
