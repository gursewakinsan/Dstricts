using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dstricts.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestPage : ContentPage
	{
		public TestPage()
		{
			InitializeComponent();
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			lblEatDrink.Text = $"Eat & Drink";
			lblFitnessSpa.Text = "Fitness & Spa";

			imgRecommendation.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/1.png";

			imgRoom.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/4.png";
			imgBed.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/5.png";
			imgMedia.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/1.png";
			imgBathroom.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/7.png";
			
			BindRoomServiceInfo();
			BindEatDrinkAtTheHotelInfo();
			BindFitnessSpaInfo();
		}

		void BindRoomServiceInfo()
		{
			int deviceWidth = App.ScreenWidth - 56;
			int w = deviceWidth * 42 / 100;
			int h = w * 97 / 100;

			List<abc> abcs = new List<abc>();
			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/8.png",
				Name = "Breakfast",
				Detail = "32 Item",
				ImgWidth = w,
				ImgHeight = h
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/9.png",
				Name = "Lunch",
				Detail = "15 Item",
				ImgWidth = w,
				ImgHeight = h
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/8.png",
				Name = "Breakfast",
				Detail = "32 Item",
				ImgWidth = w,
				ImgHeight = h
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/9.png",
				Name = "Lunch",
				Detail = "15 Item",
				ImgWidth = w,
				ImgHeight = h
			});
			BindableLayout.SetItemsSource(layoutRoomService, abcs);
		}

		void BindEatDrinkAtTheHotelInfo()
		{
			int deviceWidth = App.ScreenWidth - 56;
			int w = deviceWidth * 80 / 100;
			int h = w * 68 / 100;

			List<abc> abcs = new List<abc>();
			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/11.png",
				Name = "Restaurant 1",
				Detail = "32 Item",
				ImgWidth = w,
				ImgHeight = h
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/12.png",
				Name = "Restaurant 2",
				Detail = "15 Item",
				ImgWidth = w,
				ImgHeight = h
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/11.png",
				Name = "Restaurant 3",
				Detail = "32 Item",
				ImgWidth = w,
				ImgHeight = h
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/12.png",
				Name = "Restaurant 4",
				Detail = "15 Item",
				ImgWidth = w,
				ImgHeight = h
			});
			BindableLayout.SetItemsSource(layoutEatDrinkAtTheHotel, abcs);
		}

		void BindFitnessSpaInfo()
		{
			int deviceWidth = App.ScreenWidth - 56;
			int w = deviceWidth * 80 / 100;
			int h = w * 68 / 100;

			List<abc> abcs = new List<abc>();
			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/13.png",
				Name = "Gym",
				Detail = "32 Item",
				ImgWidth = w,
				ImgHeight = h
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/14.png",
				Name = "Spa",
				Detail = "15 Item",
				ImgWidth = w,
				ImgHeight = h
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/13.png",
				Name = "Gym",
				Detail = "32 Item",
				ImgWidth = w,
				ImgHeight = h
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/14.png",
				Name = "Spa",
				Detail = "15 Item",
				ImgWidth = w,
				ImgHeight = h
			});
			BindableLayout.SetItemsSource(layoutFitnessSpa, abcs);
		}
	}
}

public class abc
{
	public string ImgUrl { get; set; }
	public string Name { get; set; }
	public string Detail { get; set; }
	public double ImgWidth { get; set; }
	public double ImgHeight { get; set; }
}