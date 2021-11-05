using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class ResturantServeBasedMenuPageViewModel : BaseViewModel
	{
		#region Constructor.
		public ResturantServeBasedMenuPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Resturant Serve Based Menu Command.
		private ICommand resturantServeBasedMenuCommand;
		public ICommand ResturantServeBasedMenuCommand
		{
			get => resturantServeBasedMenuCommand ?? (resturantServeBasedMenuCommand = new Command(async () => await ExecuteResturantServeBasedMenuCommand()));
		}
		private async Task ExecuteResturantServeBasedMenuCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();

			int deviceWidth = App.ScreenWidth - 56;
			int imgWidth = deviceWidth * 40 / 100;
			int imgHeight = imgWidth * 97 / 100;

			ResturantServeBasedMenuInfo = await service.ResturantServeBasedMenuAsync(new Models.ResturantServeBasedMenuRequest()
			{
				ResturantId = Helper.Helper.SelectResturantId,
				ServeType = ResturantServeInfo.Id,
				ImgHeight = imgHeight,
				ImgWidth = imgWidth
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.ResturantServeBasedMenuResponse> resturantServeBasedMenuInfo;
		public List<Models.ResturantServeBasedMenuResponse> ResturantServeBasedMenuInfo
		{
			get => resturantServeBasedMenuInfo;
			set
			{
				resturantServeBasedMenuInfo = value;
				OnPropertyChanged("ResturantServeBasedMenuInfo");
			}
		}

		private Models.ResturantServeInfoResponse resturantServeInfo;
		public Models.ResturantServeInfoResponse ResturantServeInfo
		{
			get => resturantServeInfo;
			set
			{
				resturantServeInfo = value;
				OnPropertyChanged("ResturantServeInfo");
			}
		}
		#endregion
	}
}

