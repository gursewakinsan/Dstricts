using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
	public class SearchWellnessDetailsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public SearchWellnessDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Wellness Search Following Count Command.
		private ICommand wellnessSearchFollowingCountCommand;
		public ICommand WellnessSearchFollowingCountCommand
		{
			get => wellnessSearchFollowingCountCommand ?? (wellnessSearchFollowingCountCommand = new Command(async () => await ExecuteWellnessSearchFollowingCountCommand()));
		}
		private async Task ExecuteWellnessSearchFollowingCountCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBookService service = new BookService();
			FollowingCount = await service.WellnessSearchFollowingCountAsync(new Models.WellnessSearchFollowingCountRequest()
			{
				WellnessId = WellnessSearchInfo.Id
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Wellness Update Following Command.
		private ICommand wellnessUpdateFollowingCommand;
		public ICommand WellnessUpdateFollowingCommand
		{
			get => wellnessUpdateFollowingCommand ?? (wellnessUpdateFollowingCommand = new Command(async () => await ExecuteWellnessUpdateFollowingCommand()));
		}
		private async Task ExecuteWellnessUpdateFollowingCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBookService service = new BookService();
			FollowingCount = await service.WellnessUpdateFollowingAsync(new Models.WellnessUpdateFollowingRequest()
			{
				WellnessId = WellnessSearchInfo.Id,
				DstrictsUserId = Helper.Helper.LoggedInUserId
			});
			IsFollow = !IsFollow;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Book Service Command.
		private ICommand bookServiceCommand;
		public ICommand BookServiceCommand
		{
			get => bookServiceCommand ?? (bookServiceCommand = new Command(async () => await ExecuteBookServiceCommand()));
		}
		private async Task ExecuteBookServiceCommand()
		{
			Helper.Helper.WellnessId = WellnessSearchInfo.Id;
			await Navigation.PushAsync(new Views.BookService.BookServiceListPage());
		}
		#endregion

		#region Properties.
		private Models.SearchUserResponse wellnessSearchInfo;
		public Models.SearchUserResponse WellnessSearchInfo
		{
			get => wellnessSearchInfo;
			set
			{
				wellnessSearchInfo = value;
				OnPropertyChanged("WellnessSearchInfo");
			}
		}

		private bool isFollow;
		public bool IsFollow
		{
			get => isFollow;
			set
			{
				isFollow = value;
				if (isFollow)
				{
					FollowOrFollowing = "Following";
					FollowOrFollowingButtonBg = Color.FromHex("#363541");
				}
				else
				{
					FollowOrFollowing = "Follow";
					FollowOrFollowingButtonBg = Color.Transparent;
				}
				OnPropertyChanged("IsFollow");
			}
		}

		private string followOrFollowing;
		public string FollowOrFollowing
		{
			get => followOrFollowing;
			set
			{
				followOrFollowing = value;
				OnPropertyChanged("FollowOrFollowing");
			}
		}

		private Color followOrFollowingButtonBg;
		public Color FollowOrFollowingButtonBg
		{
			get => followOrFollowingButtonBg;
			set
			{
				followOrFollowingButtonBg = value;
				OnPropertyChanged("FollowOrFollowingButtonBg");
			}
		}

		private int followingCount;
		public int FollowingCount
		{
			get => followingCount;
			set
			{
				followingCount = value;
				OnPropertyChanged("FollowingCount");
			}
		}

		public string PostsAndVideos => "Posts & Videos";
		public ImageSource Img => ImageSource.FromUri(new System.Uri("https://www.qloudid.com/html/usercontent/images/dstricts/imagesDesign.png"));
		#endregion
	}
}
