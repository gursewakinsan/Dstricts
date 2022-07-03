using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;

namespace Dstricts.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestPage1 : ContentPage
	{
		TestPage1ViewModel viewModel;
		public TestPage1()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new TestPage1ViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GoToAllWaitCommand.Execute(null);

			int deviceWidth = App.ScreenWidth - 56;
			int imgWidth = deviceWidth * 45 / 100;

			List<DemoData> demos = new List<DemoData>();
			for (int i = 0; i < 3; i++)
			{
				demos.Add(new DemoData { ItemWidth = imgWidth });
			}

			BindableLayout.SetItemsSource(listEatAndDrinks, demos);
			BindableLayout.SetItemsSource(listWellness, demos);
			BindableLayout.SetItemsSource(listMeetingsAndEvents, demos);
		}

		private async void Button_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new TestPage());
		}
	}
}
class DemoData
{
	public int ItemWidth { get; set; }
}