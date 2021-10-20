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
			imgRecommendation.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/1.png";
			BindInfo();

			img0.Source = "https://www.qloudid.com/html/usercontent/images/roomserviceImages/Breakfast.jpg";
			img1.Source = "https://www.qloudid.com/html/usercontent/images/roomserviceImages/Brunch.jpg";
			img2.Source = "https://www.qloudid.com/html/usercontent/images/roomserviceImages/lunch.jpg";
			img3.Source = "https://www.qloudid.com/html/usercontent/images/roomserviceImages/Beverage.jpg";

			img4.Source = "https://www.qloudid.com/html/usercontent/images/roomserviceImages/Breakfast.jpg";
			img5.Source = "https://www.qloudid.com/html/usercontent/images/roomserviceImages/Brunch.jpg";
			img6.Source = "https://www.qloudid.com/html/usercontent/images/roomserviceImages/lunch.jpg";
			img7.Source = "https://www.qloudid.com/html/usercontent/images/roomserviceImages/Beverage.jpg";

			img8.Source = "https://www.qloudid.com/html/usercontent/images/roomserviceImages/Breakfast.jpg";
			img9.Source = "https://www.qloudid.com/html/usercontent/images/roomserviceImages/Brunch.jpg";
			img10.Source = "https://www.qloudid.com/html/usercontent/images/roomserviceImages/lunch.jpg";
			img11.Source = "https://www.qloudid.com/html/usercontent/images/roomserviceImages/Beverage.jpg";


			img12.Source = "https://www.qloudid.com/html/usercontent/images/roomserviceImages/Breakfast.jpg";
			img13.Source = "https://www.qloudid.com/html/usercontent/images/roomserviceImages/Brunch.jpg";
			img14.Source = "https://www.qloudid.com/html/usercontent/images/roomserviceImages/lunch.jpg";
			img15.Source = "https://www.qloudid.com/html/usercontent/images/roomserviceImages/Beverage.jpg";

		}

		void BindInfo()
		{
			List<abc> abcs = new List<abc>();
			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/2.png",
				Name = "Faux Leather",
				Detail = "32 Item"
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/3.png",
				Name = "Ultraburn",
				Detail = "15 Item"
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/2.png",
				Name = "Faux Leather",
				Detail = "32 Item"
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/3.png",
				Name = "Ultraburn",
				Detail = "15 Item"
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/2.png",
				Name = "Faux Leather",
				Detail = "32 Item"
			});

			abcs.Add(new abc()
			{
				ImgUrl = "https://www.qloudid.com/html/usercontent/images/dstricts/3.png",
				Name = "Ultraburn",
				Detail = "15 Item"
			});
			BindableLayout.SetItemsSource(layoutMenu, abcs);
		}
	}
}

public class abc
{
	public string ImgUrl { get; set; }
	public string Name { get; set; }
	public string Detail { get; set; }
}