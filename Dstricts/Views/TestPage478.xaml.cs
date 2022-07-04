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
	public partial class TestPage478 : ContentPage
	{
		public TestPage478()
		{
			InitializeComponent();
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
		}
		

		private async void Button_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new TestPage484());
		}
	}
}