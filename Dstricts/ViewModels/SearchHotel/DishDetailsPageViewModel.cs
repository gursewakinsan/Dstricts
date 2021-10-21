using Xamarin.Forms;

namespace Dstricts.ViewModels
{
	public class DishDetailsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public DishDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Properties.
		private Models.Dish dishDetailsInfo;
		public Models.Dish DishDetailsInfo
		{
			get => dishDetailsInfo;
			set
			{
				dishDetailsInfo = value;
				OnPropertyChanged("DishDetailsInfo");
			}
		}
		#endregion
	}
}
