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
	public partial class TestPage : ContentPage
	{
		public TestPage()
		{
			InitializeComponent();
			List<Test> list = new List<Test>();
			list.Add(new Test() { ImageURL = "https://www.gstatic.com/webp/gallery/1.jpg" });
			list.Add(new Test() { ImageURL = "https://www.gstatic.com/webp/gallery/2.webp" });
			list.Add(new Test() { ImageURL = "https://www.gstatic.com/webp/gallery/3.jpg" });
			list.Add(new Test() { ImageURL = "https://www.gstatic.com/webp/gallery/4.webp" });
			list.Add(new Test() { ImageURL = "https://www.gstatic.com/webp/gallery/5.webp" });
			list.Add(new Test() { ImageURL = "https://www.gstatic.com/webp/gallery/1.jpg" });
			list.Add(new Test() { ImageURL = "https://www.gstatic.com/webp/gallery/2.webp" });
			list.Add(new Test() { ImageURL = "https://www.gstatic.com/webp/gallery/3.jpg" });
			list.Add(new Test() { ImageURL = "https://www.gstatic.com/webp/gallery/4.webp" });
			list.Add(new Test() { ImageURL = "https://www.gstatic.com/webp/gallery/5.webp" });
			list.Add(new Test() { ImageURL = "https://www.gstatic.com/webp/gallery/1.jpg" });
			list.Add(new Test() { ImageURL = "https://www.gstatic.com/webp/gallery/2.webp" });
			list.Add(new Test() { ImageURL = "https://www.gstatic.com/webp/gallery/3.jpg" });
			list.Add(new Test() { ImageURL = "https://www.gstatic.com/webp/gallery/4.webp" });
			list.Add(new Test() { ImageURL = "https://www.gstatic.com/webp/gallery/5.webp" });
			BindableLayout.SetItemsSource(imageList, list);

			List<DemoCards> demoCardsList = new List<DemoCards>();
			List<Images> CardsImages = new List<Images>();
			CardsImages.Add(new Images() { URL = "https://www.gstatic.com/webp/gallery/2.webp" });
			CardsImages.Add(new Images() { URL = "https://www.gstatic.com/webp/gallery/4.webp" });
			CardsImages.Add(new Images() { URL = "https://www.gstatic.com/webp/gallery/5.webp" });
			CardsImages.Add(new Images() { URL = "https://www.gstatic.com/webp/gallery/2.webp" });

			demoCardsList.Add(new DemoCards()
			{
				UserImage = "https://www.photodoozy.com/uploads/pak-army-handsome-boy-hd-stylish-dp-2020-photodoozy.jpg",
				CardsImage = CardsImages
			});
			demoCardsList.Add(new DemoCards()
			{
				UserImage = "https://images.pexels.com/photos/1190208/pexels-photo-1190208.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
				CardsImage = CardsImages
			});
			BindableLayout.SetItemsSource(cards, demoCardsList);
		}
	}
}
public class Test
{
	public string ImageURL { get; set; }
}
public class DemoCards
{
	public string UserImage { get; set; }
	public List<Images> CardsImage { get; set; }
}
public class Images
{
	public string URL { get; set; }
}
