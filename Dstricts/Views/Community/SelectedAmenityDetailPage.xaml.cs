using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;

namespace Dstricts.Views.Community
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedAmenityDetailPage : ContentPage
    {
        SelectedAmenityDetailPageViewModel viewModel;
        public SelectedAmenityDetailPage(List<Models.ApartmentCommunity> apartmentCommunities)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new SelectedAmenityDetailPageViewModel(this.Navigation);
            viewModel.CommunityList = apartmentCommunities;
            viewModel.CommunityDetailId = apartmentCommunities.FirstOrDefault(x => x.IsSelected).Id;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.CommunitySelectedInfoCommand.Execute(null);
        }

        private void OnCommunityListButtonClicked(object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            Models.ApartmentCommunity community = button.BindingContext as Models.ApartmentCommunity;
            if (!viewModel.CommunityDetailId.Equals(community.Id))
            {
                foreach (var amenity in viewModel.CommunityList)
                {
                    if (amenity.Id.Equals(community.Id))
                        amenity.IsSelected = true;
                    else
                        amenity.IsSelected = false;
                }
                viewModel.CommunityDetailId = community.Id;
                viewModel.CommunitySelectedInfoCommand.Execute(null);
            }
        }

        private void OnRuleTapped(object sender, System.EventArgs e)
        {
            Label label = sender as Label;
            Models.CommunitySelectedAmenitiesRulesInfoResponse rules = label.BindingContext as Models.CommunitySelectedAmenitiesRulesInfoResponse;
            rules.IsShowSubRules = !rules.IsShowSubRules;
            if (rules.IsShowSubRules)
                rules.RuleBg = Color.FromHex("#242A37");
            else
                rules.RuleBg = Color.FromHex("#181A1F");
        }
    }
}