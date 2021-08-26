﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HotelDetailsPage : ContentPage
	{
		HotelDetailsPageViewModel viewModel;
		public HotelDetailsPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new HotelDetailsPageViewModel(this.Navigation);
		}
	}
}