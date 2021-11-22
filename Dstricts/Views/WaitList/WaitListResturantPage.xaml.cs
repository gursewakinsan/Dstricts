using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;

namespace Dstricts.Views.WaitList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WaitListResturantPage : ContentPage
	{
		WaitListResturantPageViewModel viewModel;
		public WaitListResturantPage(List<Models.WaitListResturantResponse> waitListResturants)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new WaitListResturantPageViewModel(this.Navigation);
			viewModel.WaitListResturantInfo = waitListResturants;
		}
	}
}