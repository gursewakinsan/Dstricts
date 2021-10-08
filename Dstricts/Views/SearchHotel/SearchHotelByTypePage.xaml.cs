using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.SearchHotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchHotelByTypePage : ContentPage
	{
		SearchHotelByTypeViewModel viewModel;
		public SearchHotelByTypePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SearchHotelByTypeViewModel(this.Navigation);
		}
	}
}