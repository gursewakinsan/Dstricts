using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dstricts.Views.DesignTestPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage499 : ContentPage
    {
        public TestPage499()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DesignTestPages.TestPage502());
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}