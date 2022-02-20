using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Dstricts.ViewModels
{
	public class BookServiceListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public BookServiceListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Wellness Service Info Count Command.
		private ICommand wellnessServiceInfoCountCommand;
		public ICommand WellnessServiceInfoCountCommand
		{
			get => wellnessServiceInfoCountCommand ?? (wellnessServiceInfoCountCommand = new Command(async () => await ExecuteWellnessServiceInfoCountCommand()));
		}
		private async Task ExecuteWellnessServiceInfoCountCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IFittnessAndSpaService service = new FittnessAndSpaService();
			WellnessServiceInfoCountInfo = await service.WellnessServiceInfoCountAsync(new Models.WellnessServiceInfoCountRequest()
			{
				DstrictsUserId = Helper.Helper.LoggedInUserId,
				WellnessId = Helper.Helper.WellnessId
			});
			if (WellnessServiceInfoCountInfo.OneToOne)
				OneToOneCommand.Execute(null);
			else if (WellnessServiceInfoCountInfo.PrivateService)
				PrivateServiceCommand.Execute(null);
			else if (WellnessServiceInfoCountInfo.PublicService)
				PublicServiceCommand.Execute(null);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region One To One Command.
		private ICommand oneToOneCommand;
		public ICommand OneToOneCommand
		{
			get => oneToOneCommand ?? (oneToOneCommand = new Command( () =>  ExecuteOneToOneCommand()));
		}
		private void ExecuteOneToOneCommand()
		{
			SelectedServicesType = 1;
			ServiceTypeText = "Perfect for 1 person at the time";
			OneToOneButtonBg = Color.FromHex("#6263ED");
			PrivateServiceButtonBg = Color.FromHex("#2A2A31");
			PublicServiceButtonBg = Color.FromHex("#2A2A31");
			SelectedWellnessCategoriesAndMenuCommand.Execute(null);
		}
		#endregion

		#region Private Service Command.
		private ICommand privateServiceCommand;
		public ICommand PrivateServiceCommand
		{
			get => privateServiceCommand ?? (privateServiceCommand = new Command(() => ExecutePrivateServiceCommand()));
		}
		private void ExecutePrivateServiceCommand()
		{
			SelectedServicesType = 2;
			ServiceTypeText = "Private for a group of people";
			OneToOneButtonBg = Color.FromHex("#2A2A31");
			PrivateServiceButtonBg = Color.FromHex("#6263ED");
			PublicServiceButtonBg = Color.FromHex("#2A2A31");
			SelectedWellnessCategoriesAndMenuCommand.Execute(null);
		}
		#endregion

		#region Public Service Command.
		private ICommand publicServiceCommand;
		public ICommand PublicServiceCommand
		{
			get => publicServiceCommand ?? (publicServiceCommand = new Command(() => ExecutePublicServiceCommand()));
		}
		private void ExecutePublicServiceCommand()
		{
			SelectedServicesType = 3;
			ServiceTypeText = "Join a public events with others";
			OneToOneButtonBg = Color.FromHex("#2A2A31");
			PrivateServiceButtonBg = Color.FromHex("#2A2A31");
			PublicServiceButtonBg = Color.FromHex("#6263ED");
			SelectedWellnessCategoriesAndMenuCommand.Execute(null);
		}
		#endregion

		#region Selected Wellness Categories And Menu Command.
		private ICommand selectedWellnessCategoriesAndMenuCommand;
		public ICommand SelectedWellnessCategoriesAndMenuCommand
		{
			get => selectedWellnessCategoriesAndMenuCommand ?? (selectedWellnessCategoriesAndMenuCommand = new Command(async () => await ExecuteSelectedWellnessCategoriesAndMenuCommand()));
		}
		private async Task ExecuteSelectedWellnessCategoriesAndMenuCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBookService service = new BookService();
			var response = await service.SelectedWellnessCategoriesandMenuAsync(new Models.SelectedWellnessCategoriesandMenuRequest()
			{
				CheckId = 0,
				DstrictsUserId = Helper.Helper.LoggedInUserId,
				WellnessId = Helper.Helper.WellnessId,
				SelectedServicesType = SelectedServicesType
			});
			SelectedWellnessCategoriesAndMenuInfo = new ObservableCollection<Models.SelectedWellnessCategoriesAndMenuResponse>(response);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.SelectedWellnessCategoriesAndMenuResponse> selectedWellnessCategoriesAndMenuInfo;
		public ObservableCollection<Models.SelectedWellnessCategoriesAndMenuResponse> SelectedWellnessCategoriesAndMenuInfo
		{
			get => selectedWellnessCategoriesAndMenuInfo;
			set
			{
				selectedWellnessCategoriesAndMenuInfo = value;
				OnPropertyChanged("SelectedWellnessCategoriesAndMenuInfo");
			}
		}

		private Models.WellnessServiceInfoCountResponse wellnessServiceInfoCountInfo;
		public Models.WellnessServiceInfoCountResponse WellnessServiceInfoCountInfo
		{
			get => wellnessServiceInfoCountInfo;
			set
			{
				wellnessServiceInfoCountInfo = value;
				OnPropertyChanged("WellnessServiceInfoCountInfo");
			}
		}

		private Color oneToOneButtonBg = Color.FromHex("#2A2A31");
		public Color OneToOneButtonBg
		{
			get => oneToOneButtonBg;
			set
			{
				oneToOneButtonBg = value;
				OnPropertyChanged("OneToOneButtonBg");
			}
		}

		private Color privateServiceButtonBg = Color.FromHex("#2A2A31");
		public Color PrivateServiceButtonBg
		{
			get => privateServiceButtonBg;
			set
			{
				privateServiceButtonBg = value;
				OnPropertyChanged("PrivateServiceButtonBg");
			}
		}

		private Color publicServiceButtonBg = Color.FromHex("#2A2A31");
		public Color PublicServiceButtonBg
		{
			get => publicServiceButtonBg;
			set
			{
				publicServiceButtonBg = value;
				OnPropertyChanged("PublicServiceButtonBg");
			}
		}

		private string serviceTypeText;
		public string ServiceTypeText
		{
			get => serviceTypeText;
			set
			{
				serviceTypeText = value;
				OnPropertyChanged("ServiceTypeText");
			}
		}

		public int SelectedServicesType { get; set; }
		#endregion
	}
}
