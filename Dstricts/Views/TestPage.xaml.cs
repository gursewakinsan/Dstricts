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
			cardImage.Source = ImageSource.FromUri(new Uri("https://www.gstatic.com/webp/gallery/1.jpg"));
			cardImage1.Source = ImageSource.FromUri(new Uri("https://www.gstatic.com/webp/gallery/4.webp"));
		}
	}
}
public class Test
{
	public string ImageURL { get; set; }
}