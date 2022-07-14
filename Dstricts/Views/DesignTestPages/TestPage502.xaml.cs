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
    public partial class TestPage502 : ContentPage
    {
        public TestPage502()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void TapGestureRecognizer_TappedNext(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DesignTestPages.TestPage503());
        }
    }
}