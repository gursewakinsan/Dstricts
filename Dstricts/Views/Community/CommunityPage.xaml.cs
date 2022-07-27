using System;
using System.Collections.Generic;
using Dstricts.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dstricts.Views.Community
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommunityPage : ContentPage
    {
		CommunityPageViewModel viewModel;
		public CommunityPage()
        {
            InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CommunityPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			int deviceWidth = App.ScreenWidth - 56;
			int imgWidth = deviceWidth * 90 / 100;

			List<DemoData> demos = new List<DemoData>();
			for (int i = 0; i < 3; i++)
			{
				demos.Add(new DemoData { ItemWidth = imgWidth });
			}

			BindableLayout.SetItemsSource(layoutImages, demos);
			BindableLayout.SetItemsSource(listWellness, demos);
			BindableLayout.SetItemsSource(listThingsToDo, demos);
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.QloudIdApartmentDetailsPage(Helper.Helper.ApartmentCheckedIn));

		}
	}
}