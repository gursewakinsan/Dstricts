using System;
using Xamarin.Forms;
using Dstricts.Controls;
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

        #region Arrow Left/Right.
        private void OnArrowLeftTapped(object sender, EventArgs e)
        {
            if (CarouselViewKins.Position > 0)
            {
                CarouselViewKins.Position = CarouselViewKins.Position - 1;

            }
        }

        private void OnArrowRightTapped(object sender, EventArgs e)
        {
            if (CarouselViewKins.Position < viewModel.MissingPersonList.Count)
            {
                CarouselViewKins.Position = CarouselViewKins.Position + 1;
            }
            else
                CarouselViewKins.Position = 0;
        }
        #endregion

        #region Kin Found.
        private void OnKinFoundCustomFrame(object sender, EventArgs e)
        {
            if (viewModel.MissingPersonList.Count > 1)
            {
                CustomFrame control = sender as CustomFrame;
                OnKinFound(control.BindingContext as Models.MissingPersonListResponse);
            }
            else
                OnKinFound(viewModel.Kin);
        }

        private void OnKinFoundStackLayout(object sender, EventArgs e)
        {
            if (viewModel.MissingPersonList.Count > 1)
            {
                StackLayout control = sender as StackLayout;
                OnKinFound(control.BindingContext as Models.MissingPersonListResponse);
            }
            else
                OnKinFound(viewModel.Kin);
        }

        private void OnKinFoundLabel(object sender, EventArgs e)
        {
            if (viewModel.MissingPersonList.Count > 1)
            {
                Label control = sender as Label;
                OnKinFound(control.BindingContext as Models.MissingPersonListResponse);
            }
            else
                OnKinFound(viewModel.Kin);
        }

        void OnKinFound(Models.MissingPersonListResponse foundKin)
        {
            viewModel.ReportPersonFoundCommand.Execute(Convert.ToInt32(foundKin.Id));
        }
        #endregion
    }
}