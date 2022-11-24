using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using Dstricts.Controls;

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
            if (viewModel.IsKinsList)
            {
                CustomFrame control = sender as CustomFrame;
                GoToKinsTimeAndDurationPage(control.BindingContext as Models.kinsListResponse);
            }
            else
                GoToKinsTimeAndDurationPage(viewModel.Kin);
        }

        private void OnCustomGridTapped(object sender, System.EventArgs e)
        {
            if (viewModel.IsKinsList)
            {
                Grid control = sender as Grid;
                GoToKinsTimeAndDurationPage(control.BindingContext as Models.kinsListResponse);
            }
            else
                GoToKinsTimeAndDurationPage(viewModel.Kin);
        }

        private void OnCustomStackLayoutTapped(object sender, System.EventArgs e)
        {
            if (viewModel.IsKinsList)
            {
                StackLayout control = sender as StackLayout;
                GoToKinsTimeAndDurationPage(control.BindingContext as Models.kinsListResponse);
            }
            else
                GoToKinsTimeAndDurationPage(viewModel.Kin);
        }

        private void OnCustomImageButtonTapped(object sender, System.EventArgs e)
        {
            if (viewModel.IsKinsList)
            {
                ImageButton control = sender as ImageButton;
                GoToKinsTimeAndDurationPage(control.BindingContext as Models.kinsListResponse);
            }
            else
                GoToKinsTimeAndDurationPage(viewModel.Kin);
        }

        private void OnCustomLabelTapped(object sender, System.EventArgs e)
        {
            if (viewModel.IsKinsList)
            {
                Label control = sender as Label;
                GoToKinsTimeAndDurationPage(control.BindingContext as Models.kinsListResponse);
            }
            else
                GoToKinsTimeAndDurationPage(viewModel.Kin);
        }
        async void GoToKinsTimeAndDurationPage(Models.kinsListResponse kins)
        {
            if (Helper.Helper.MissingPersonInfo == null)
                Helper.Helper.MissingPersonInfo = new Models.AddMissingPersonInfoRequest();
            Helper.Helper.MissingPersonInfo.FirstName = kins.FirstName;
            Helper.Helper.MissingPersonInfo.LastName= kins.LastName;
            Helper.Helper.MissingPersonInfo.Uid = kins.Uid;
            Helper.Helper.MissingPersonInfo.UserId = Helper.Helper.LoggedInUserId;
            await Navigation.PushAsync(new KinsTimeAndDurationPage());
        }

        private void OnToggleOnOffTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            viewModel.UpdateNotificationRequirementCommand.Execute(control.BindingContext as Models.kinsListResponse);
        }

        private void OnKinToggleOnOffTapped(object sender, System.EventArgs e)
        {
            viewModel.UpdateNotificationRequirementCommand.Execute(viewModel.Kin);
        }
    }
}