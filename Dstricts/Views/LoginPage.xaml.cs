﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		LoginViewModel loginViewModel;
		public LoginPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = loginViewModel = new LoginViewModel(this.Navigation);
		}
		protected override void OnAppearing()
		{
			if (!string.IsNullOrWhiteSpace(Helper.Helper.SessionId))
				loginViewModel.LoginWithSessionCommand.Execute(null);
			base.OnAppearing();
		}
	}
}