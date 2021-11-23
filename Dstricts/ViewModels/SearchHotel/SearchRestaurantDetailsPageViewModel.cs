using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class SearchRestaurantDetailsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public SearchRestaurantDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Resturant Info by Id Command.
		private ICommand getResturantInfobyIdCommand;
		public ICommand GetResturantInfobyIdCommand
		{
			get => getResturantInfobyIdCommand ?? (getResturantInfobyIdCommand = new Command(async () => await ExecuteGetResturantInfobyIdCommand()));
		}
		private async Task ExecuteGetResturantInfobyIdCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			ResturantProfileInfo = await service.ResturantProfileInfoAsync(new Models.ResturantProfileInfoRequest()
			{
				ResturantId = Helper.Helper.SelectResturantId
			});
			if (ResturantProfileInfo != null)
			{
				List<HotelImages> hotelImages = new List<HotelImages>();
				hotelImages.Add(new HotelImages() { ImageUrl = ResturantProfileInfo.BigImage });
				hotelImages.Add(new HotelImages() { ImageUrl = ResturantProfileInfo.SmallImage });
				hotelImages.Add(new HotelImages() { ImageUrl = ResturantProfileInfo.SmallImage2 });
				ResturantImages = hotelImages;
			}

			var response = await service.ResturantServeInfoAsync(new Models.ResturantServeInfoRequest()
			{
				ResturantId = Helper.Helper.SelectResturantId
			});

			if (response?.Count > 0)
			{
				int deviceWidth = App.ScreenWidth - 56;
				int imgWidth = deviceWidth * 40 / 100;
				int imgHeight = imgWidth * 97 / 100;

				foreach (var item in response)
				{
					item.ImgHeight = imgHeight;
					item.ImgWidth = imgWidth;
				}
			}
			ResturantServeInfo = response;

			IWaitService waitService = new WaitService();
			PublishedResturantInfo = await waitService.PublishedResturantInfoAsync(new Models.PublishedResturantInfoRequest()
			{
				ResturantId = Helper.Helper.SelectResturantId
			});
			if (PublishedResturantInfo.PublishDropIn)
			{
				WaitListResturantInfo = await waitService.WaitListResturantAsync(new Models.WaitListResturantRequest()
				{
					ResturantId = Helper.Helper.SelectResturantId,
					QueueType = 2
				});
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Book Table Command.
		private ICommand bookTableCommand;
		public ICommand BookTableCommand
		{
			get => bookTableCommand ?? (bookTableCommand = new Command(async () => await ExecuteBookTableCommand()));
		}
		private async Task ExecuteBookTableCommand()
		{
			if (PublishedResturantInfo.PublishBookTable)
				await Navigation.PushAsync(new Views.BookTable.BookTablePage());
		}
		#endregion

		#region Wait List Command.
		private ICommand waitListCommand;
		public ICommand WaitListCommand
		{
			get => waitListCommand ?? (waitListCommand = new Command(async () => await ExecuteWaitListCommand()));
		}
		private async Task ExecuteWaitListCommand()
		{
			if (PublishedResturantInfo.PublishDropIn)
			{
				if (WaitListResturantInfo?.Count > 1)
				{
					int index = 0;
					foreach (var waitList in WaitListResturantInfo)
					{
						waitList.QueueFirstLetterBg = Helper.Helper.ListIconBgColorList[index];
						waitList.QueueFirstLetterText = Helper.Helper.ListIconTextColorList[index];
						index = index + 1;
					}
					await Navigation.PushAsync(new Views.WaitList.WaitListResturantPage(WaitListResturantInfo));
				}
				else if (WaitListResturantInfo?.Count == 1)
					await Navigation.PushAsync(new Views.WaitList.WaitListResturantDetailPage(WaitListResturantInfo[0]));
			}
		}
		#endregion

		#region Properties.
		private List<HotelImages> resturantImages;
		public List<HotelImages> ResturantImages
		{
			get => resturantImages;
			set
			{
				resturantImages = value;
				OnPropertyChanged("ResturantImages");
			}
		}

		private Models.ResturantProfileInfoResponse resturantProfileInfo;
		public Models.ResturantProfileInfoResponse ResturantProfileInfo
		{
			get => resturantProfileInfo;
			set
			{
				resturantProfileInfo = value;
				OnPropertyChanged("ResturantProfileInfo");
			}
		}

		private List<Models.ResturantServeInfoResponse> resturantServeInfo;
		public List<Models.ResturantServeInfoResponse> ResturantServeInfo
		{
			get => resturantServeInfo;
			set
			{
				resturantServeInfo = value;
				OnPropertyChanged("ResturantServeInfo");
			}
		}

		private string loggedInUserName = Helper.Helper.LoggedInUserName;
		public string LoggedInUserName
		{
			get => loggedInUserName;
			set
			{
				loggedInUserName = value;
				OnPropertyChanged("LoggedInUserName");
			}
		}

		private Models.PublishedResturantInfoResponse publishedResturantInfo;
		public Models.PublishedResturantInfoResponse PublishedResturantInfo
		{
			get => publishedResturantInfo;
			set
			{
				publishedResturantInfo = value;
				OnPropertyChanged("PublishedResturantInfo");
			}
		}

		private List<Models.WaitListResturantResponse> waitListResturantInfo;
		public List<Models.WaitListResturantResponse> WaitListResturantInfo
		{
			get => waitListResturantInfo;
			set
			{
				waitListResturantInfo = value;
				OnPropertyChanged("WaitListResturantInfo");
			}
		}
		#endregion
	}
}
