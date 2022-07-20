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
    public partial class TestPage476 : ContentPage
    {
        public TestPage476()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            List<Models.CheckedInResponse> listDecorated = new List<Models.CheckedInResponse>();
            int deviceWidth = App.ScreenWidth - 56;
            int imgWidth = deviceWidth * 80 / 100;
            listDecorated.Add(new Models.CheckedInResponse()
            {
                ImgWidth= imgWidth,
                ImagePath= "imgGuestRoom",
                PropertyNickName= "Bedroom",
                BookingOverdate="4"
            });

            listDecorated.Add(new Models.CheckedInResponse()
            {
                ImgWidth = imgWidth,
                ImagePath = "imgBathroom",
                PropertyNickName = "Bathroom",
                BookingOverdate = "4"
            });

            listDecorated.Add(new Models.CheckedInResponse()
            {
                ImgWidth = imgWidth,
                ImagePath = "imgkitchen",
                PropertyNickName = "Kitchen",
                BookingOverdate = "2"
            });

            listDecorated.Add(new Models.CheckedInResponse()
            {
                ImgWidth = imgWidth,
                ImagePath = "imgBalcony",
                PropertyNickName = "Hallway",
                BookingOverdate = "2"
            });

            listDecorated.Add(new Models.CheckedInResponse()
            {
                ImgWidth = imgWidth,
                ImagePath = "imgGuestRoom",
                PropertyNickName = "Livingroom",
                BookingOverdate = "2"
            });

            listDecorated.Add(new Models.CheckedInResponse()
            {
                ImgWidth = imgWidth,
                ImagePath = "imgHotelView",
                PropertyNickName = "Balcony",
                BookingOverdate = "2"
            });

            listDecorated.Add(new Models.CheckedInResponse()
            {
                ImgWidth = imgWidth,
                ImagePath = "imgBalcony",
                PropertyNickName = "Terrace",
                BookingOverdate = "2"
            });
            BindableLayout.SetItemsSource(layoutDecorated, listDecorated);
        }

        private async void TapGestureRecogizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}