using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;

namespace Dstricts.Views.Kins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoundKinsPage : ContentPage
    {
        FoundKinsPageViewModel viewModel;
        public FoundKinsPage(List<Models.MissingPersonListResponse> missings)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new FoundKinsPageViewModel(this.Navigation);
            viewModel.MissingPersonList = missings;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.MissingPersonEmergencyCommand.Execute(null);
        }
    }
}