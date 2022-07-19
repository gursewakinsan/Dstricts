using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dstricts.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestPage3 : ContentPage
	{
		public TestPage3()
		{
			InitializeComponent();
		}

		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
			await Navigation.PushAsync(new DesignTestPages.TestPage499());
        }
    }
}