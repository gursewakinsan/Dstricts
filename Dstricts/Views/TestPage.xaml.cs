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
			/*imgVacation.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/1.png";
			imgRoom.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/4.png";
			imgBed.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/5.png";
			imgMedia.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/1.png";
			imgBathroom.Source = "https://www.qloudid.com/html/usercontent/images/dstricts/7.png";
			lblMedicalAndHealth.Text = "Medical & Health";
			lblGetPhoneAddressHere.Text = "Get phone & address here";*/
			//BindableLayout.SetItemsSource(cards, new string[10]);
			//BindableLayout.SetItemsSource(listPickDate, new string[10]);
		}

		private async void Button_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new TestPage3());
		}

		private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
		{
			await Navigation.PopAsync();
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