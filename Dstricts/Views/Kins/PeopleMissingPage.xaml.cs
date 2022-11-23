using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;

namespace Dstricts.Views.Kins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeopleMissingPage : ContentPage
    {
        PeopleMissingPageViewModel viewModel;
        public PeopleMissingPage(List<Models.MissingPersonListResponse> missings)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new PeopleMissingPageViewModel(this.Navigation);
            viewModel.MissingPersonList = missings;
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
            if (CarouselViewKins.Position < viewModel.MissingPersonList.Count)
            {
                CarouselViewKins.Position = CarouselViewKins.Position + 1;
            }
            else
                CarouselViewKins.Position = 0;
        }
    }
}