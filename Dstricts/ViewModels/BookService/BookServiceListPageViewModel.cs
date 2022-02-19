using System;
using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
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
	}
}
