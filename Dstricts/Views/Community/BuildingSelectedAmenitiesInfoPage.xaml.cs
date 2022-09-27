using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Collections.Generic;

namespace Dstricts.Views.Community
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuildingSelectedAmenitiesInfoPage : ContentPage
    {
        BuildingSelectedAmenitiesInfoPageViewModel viewModel;
        public BuildingSelectedAmenitiesInfoPage(List<Models.ApartmentCommunity> communities)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new BuildingSelectedAmenitiesInfoPageViewModel(this.Navigation);
            viewModel.CommunityList = communities;
            viewModel.SelectedCommunityId = communities.FirstOrDefault(x => x.IsSelected).Id;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.BuildingSelectedAmenitiesInfoCommand.Execute(null);
        }

        private void OnCommunityListButtonClicked(object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            Models.ApartmentCommunity community = button.BindingContext as Models.ApartmentCommunity;
            if (!viewModel.SelectedCommunityId.Equals(community.Id))
            {
                foreach (var amenity in viewModel.CommunityList)
                {
                    if (amenity.Id.Equals(community.Id))
                        amenity.IsSelected = true;
                    else
                        amenity.IsSelected = false;
                }
                viewModel.SelectedCommunityId = community.Id;
                viewModel.BuildingSelectedAmenitiesInfoCommand.Execute(null);
            }
        }
    }
}