using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Queue
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AvalibleQueueOnTheLocationPage : ContentPage
	{
		AvalibleQueueOnTheLocationPageViewModel viewModel;
		public AvalibleQueueOnTheLocationPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AvalibleQueueOnTheLocationPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GetAvalibleQueueOnTheLocationCommand.Execute(null);
		}

		private void OnAvalibleQueueOnTheLocationTapped(object sender, ItemTappedEventArgs e)
		{
			Models.AvalibleQueueOnTheLocationResponse avalibleQueueOnTheLocation = e.Item as Models.AvalibleQueueOnTheLocationResponse;
			listAvalibleQueueOnTheLocation.SelectedItem = null;
			viewModel.AddPersonToDesiredQueueCommand.Execute(avalibleQueueOnTheLocation.Id);
		}
	}
}