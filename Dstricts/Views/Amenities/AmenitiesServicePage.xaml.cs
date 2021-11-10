using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;

namespace Dstricts.Views.Amenities
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AmenitiesServicePage : ContentPage
	{
		AmenitiesServicePageViewModel viewModel;
		public AmenitiesServicePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AmenitiesServicePageViewModel(this.Navigation);
		}
	}
}