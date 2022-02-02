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

		#region Add services Command.
		private ICommand addServicesCommand;
		public ICommand AddServicesCommand
		{
			get => addServicesCommand ?? (addServicesCommand = new Command( () => ExecuteAddServicesCommand()));
		}
		private void ExecuteAddServicesCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.FittnessAndSpa.FittnessAndSpaDetailsPage());
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
				DishId = removeItem.DishId
			});
			AddedServiceToCartList.Remove(removeItem);
			if (AddedServiceToCartList?.Count == 0)
				Application.Current.MainPage = new NavigationPage(new Views.FittnessAndSpa.FittnessAndSpaDetailsPage());
				
			DependencyService.Get<IProgressBar>().Hide();
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
