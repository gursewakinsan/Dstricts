using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Kins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KinsListPage : ContentPage
    {
        KinsListPageViewModel viewModel;
        public KinsListPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new KinsListPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.KinsListCommand.Execute(null);
        }

        private void OnArrowLeftTapped(object sender, System.EventArgs e)
        {
            if (CarouselViewKins.Position > 0)
            {
                CarouselViewKins.Position = CarouselViewKins.Position - 1;

            }
        }

        private void OnArrowRightTapped(object sender, System.EventArgs e)
        {
            if (CarouselViewKins.Position < viewModel.KinsList.Count)
            {
                CarouselViewKins.Position = CarouselViewKins.Position + 1;
            }
            else
                CarouselViewKins.Position = 0;
        }

        private void OnCustomFrameTapped(object sender, System.EventArgs e)
        {
            GoToKinsTimeAndDurationPage();
        }

        private void OnCustomGridTapped(object sender, System.EventArgs e)
        {
            GoToKinsTimeAndDurationPage();
        }

        private void OnCustomStackLayoutTapped(object sender, System.EventArgs e)
        {
            GoToKinsTimeAndDurationPage();
        }

        private void OnCustomImageButtonTapped(object sender, System.EventArgs e)
        {
            GoToKinsTimeAndDurationPage();
        }

        private void OnCustomLabelTapped(object sender, System.EventArgs e)
        {
            GoToKinsTimeAndDurationPage();
        }
        async void GoToKinsTimeAndDurationPage()
        {
            await Navigation.PushAsync(new KinsTimeAndDurationPage());
        }
    }
}