using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Dstricts.ViewModels
{
	public class CartInfoWellnessListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CartInfoWellnessListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Go To services Command.
		private ICommand goToServicesCommand;
		public ICommand GoToServicesCommand
		{
			get => goToServicesCommand ?? (goToServicesCommand = new Command(async () =>await ExecuteGoToServicesCommand()));
		}
		private async Task ExecuteGoToServicesCommand()
		{
			if (!Helper.Helper.IsFromViewCartButtonClicked)
				this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
			else Helper.Helper.IsFromViewCartButtonClicked = false;
			await Navigation.PopAsync();
		}
		#endregion

		#region Update Wellness Cart Item Command.
		private ICommand updateWellnessCartItemCommand;
		public ICommand UpdateWellnessCartItemCommand
		{
			get => updateWellnessCartItemCommand ?? (updateWellnessCartItemCommand = new Command<Models.AddServiceToCartAppResponse>(async (removeItem) => await ExecuteUpdateWellnessCartItemCommand(removeItem)));
		}
		private async Task ExecuteUpdateWellnessCartItemCommand(Models.AddServiceToCartAppResponse removeItem)
		{
			DependencyService.Get<IProgressBar>().Show();
			IFittnessAndSpaService service = new FittnessAndSpaService();
			var response = await service.UpdateWellnessCartItemAsync(new Models.UpdateWellnessCartItemRequest()
			{
				WellnessId = Helper.Helper.WellnessId,
				CheckId = Helper.Helper.HotelCheckedIn,
				DishId = removeItem.DishId,
				ServiceType = 5
			});
			AddedServiceToCartList.Remove(removeItem);
			if (AddedServiceToCartList?.Count == 0)
				GoToServicesCommand.Execute(null);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Book Time Command.
		private ICommand bookTimeCommand;
		public ICommand BookTimeCommand
		{
			get => bookTimeCommand ?? (bookTimeCommand = new Command(async () => await ExecuteBookTimeCommand()));
		}
		private async Task ExecuteBookTimeCommand()
		{
			await Navigation.PushAsync(new Views.FittnessAndSpa.BookTimePage());
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.AddServiceToCartAppResponse> addedServiceToCartList;
		public ObservableCollection<Models.AddServiceToCartAppResponse> AddedServiceToCartList
		{
			get => addedServiceToCartList;
			set
			{
				addedServiceToCartList = value;
				OnPropertyChanged("AddedServiceToCartList");
			}
		}
		#endregion
	}
}
