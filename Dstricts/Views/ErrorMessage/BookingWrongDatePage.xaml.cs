using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dstricts.Views.ErrorMessage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookingWrongDatePage : ContentPage
	{
		public BookingWrongDatePage ()
		{
			InitializeComponent ();
		}

		private async void OnWrongDateTapped(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}
}