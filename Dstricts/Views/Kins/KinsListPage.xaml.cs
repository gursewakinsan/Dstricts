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
    }
}