using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dstricts.Views.Community
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommunityPage : ContentPage
    {
        public CommunityPage()
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
			BindableLayout.SetItemsSource(listThingsToDo, demos);
		}

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
			await Navigation.PopAsync();
        }
    }
}