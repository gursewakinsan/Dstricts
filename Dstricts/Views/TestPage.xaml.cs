using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
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
			//lblEatDrink.Text = $"Eat & Drink";
			//lblFitnessSpa.Text = "Fitness & Spa";

			imgRecommendation.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/1.png";

			//imgRoom.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/4.png";
			//imgBed.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/5.png";
			//imgMedia.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/1.png";
			//imgBathroom.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/7.png";
			
			BindRoomServiceInfo();
			//BindEatDrinkAtTheHotelInfo();
			//BindFitnessSpaInfo();
			BindMenuInfo();
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
			BindableLayout.SetItemsSource(layoutCategory1, abcs);
			BindableLayout.SetItemsSource(layoutCategory2, abcs);
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
			BindableLayout.SetItemsSource(layoutCategory2, abcs);
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
			//BindableLayout.SetItemsSource(layoutFitnessSpa, abcs);
		}

		void BindMenuInfo()
		{
			int deviceWidth = App.ScreenWidth - 56;
			int w = deviceWidth * 26 / 100;

			List<MenuInfo> menuInfos = new List<MenuInfo>();
			menuInfos.Add(new MenuInfo() { Name = "Breakfast", MenuBg = Color.FromHex("#6263ED"), ImgWidth= w });
			menuInfos.Add(new MenuInfo() { Name = "Brunch", MenuBg = Color.FromHex("#2A2A31"), ImgWidth = w });
			menuInfos.Add(new MenuInfo() { Name = "Lunch", MenuBg = Color.FromHex("#2A2A31"), ImgWidth = w });
			menuInfos.Add(new MenuInfo() { Name = "Dinner", MenuBg = Color.FromHex("#2A2A31"), ImgWidth = w });
			BindableLayout.SetItemsSource(layoutMenuInfos, menuInfos);
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			Navigation.PushPopupAsync(new PopupPages.AddLaundryItemToCartPopupPage());
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

public class MenuInfo
{
	public string Name { get; set; }
	public Color MenuBg { get; set; }
	public double ImgWidth { get; set; }
}