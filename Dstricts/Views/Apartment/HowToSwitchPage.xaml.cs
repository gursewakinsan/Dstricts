using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;

namespace Dstricts.Views.Apartment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HowToSwitchPage : ContentPage
    {
        HowToSwitchPageViewModel viewModel;
        public HowToSwitchPage(List<Models.GetSratedDetailResponse> list)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new HowToSwitchPageViewModel(this.Navigation);
            viewModel.SwitchInfo = list;
            viewModel.SelectedSwitchInfo = list.FirstOrDefault(x => x.IsSelected);
            if (viewModel.SelectedSwitchInfo.IsSwitchOn)
            {
                lblTitleText.Text = "How to switch";
                lblSubTitleText.Text = "Instructions for how to switch on";
            }
            else
            {
                lblTitleText.Text = "How to use";
                lblSubTitleText.Text = "How to use instructions";
            }
        }

        private void OnSwitchInfoButtonClicked(object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            Models.GetSratedDetailResponse response = button.BindingContext as Models.GetSratedDetailResponse;
            foreach (var switchInfo in viewModel.SwitchInfo)
            {
                if (switchInfo.Id.Equals(response.Id))
                    switchInfo.IsSelected = true;
                else
                    switchInfo.IsSelected = false;
            }
            viewModel.SelectedSwitchInfo = response;
        }
    }
}