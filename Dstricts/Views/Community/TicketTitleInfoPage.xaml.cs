using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Community
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketTitleInfoPage : ContentPage
    {
        TicketTitleInfoPageViewModel viewModel;
        public TicketTitleInfoPage(string ticketType)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new TicketTitleInfoPageViewModel(this.Navigation);
            Helper.Helper.TicketType = Convert.ToInt32(ticketType);
            if (Helper.Helper.TicketType == 1) lblTitle.Text = "Apartment";
            else lblTitle.Text = "Community";
            viewModel.GetTicketTitleInfoCommand.Execute(null);
        }

        private void OnFrameTapped(object sender, EventArgs e)
        {
            Frame control = sender as Frame;
            OnItemTapped(control.BindingContext as Models.TicketTitleInfoResponse);
        }

        private void OnGridTapped(object sender, EventArgs e)
        {
            Grid control = sender as Grid;
            OnItemTapped(control.BindingContext as Models.TicketTitleInfoResponse);
        }

        private void OnLabelTapped(object sender, EventArgs e)
        {
            Label control = sender as Label;
            OnItemTapped(control.BindingContext as Models.TicketTitleInfoResponse);
        }

        private void OnBoxViewTapped(object sender, EventArgs e)
        {
            BoxView control = sender as BoxView;
            OnItemTapped(control.BindingContext as Models.TicketTitleInfoResponse);
        }

        async void OnItemTapped(Models.TicketTitleInfoResponse ticketTitle)
        {
            Helper.Helper.TicketTitleInfo = ticketTitle;
            await Navigation.PushAsync(new TicketSubTitleInfoPage());
        }
    }
}