using System;
using Xamarin.Forms;
using Dstricts.ViewModels;
using Xamarin.Forms.Xaml;

namespace Dstricts.Views.Community
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CommunityPage : ContentPage
	{
		CommunityPageViewModel viewModel;
		public CommunityPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CommunityPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GetCommunityDetailInfoCommand.Execute(null);
			/*int deviceWidth = App.ScreenWidth - 56;
			int imgWidth = deviceWidth * 90 / 100;

			List<DemoData> demos = new List<DemoData>();
			for (int i = 0; i < 3; i++)
			{
				demos.Add(new DemoData { ItemWidth = imgWidth });
			}

			BindableLayout.SetItemsSource(listWellness, demos);
			BindableLayout.SetItemsSource(listThingsToDo, demos);*/
		}

		private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.QloudIdApartmentDetailsPage(Helper.Helper.ApartmentCheckedIn));

		}

		#region On Children Activities Clicked.
		private void OnChildrenActivitiesImageClicked(object sender, EventArgs e)
		{
			ImageButton control = (ImageButton)sender;
			OnChildrenActivitiesClicked(control.BindingContext as Models.ApartmentCommunity);
		}

		private void OnChildrenActivitiesStackLayoutClicked(object sender, EventArgs e)
		{
			StackLayout control = (StackLayout)sender;
			OnChildrenActivitiesClicked(control.BindingContext as Models.ApartmentCommunity);
		}

		private void OnChildrenActivitiesLabelClicked(object sender, EventArgs e)
		{
			Label control = (Label)sender;
			OnChildrenActivitiesClicked(control.BindingContext as Models.ApartmentCommunity);
		}
		async void OnChildrenActivitiesClicked(Models.ApartmentCommunity community)
		{
			foreach (var amenity in viewModel.CommunityChildrenAmenityList)
			{
				if (amenity.Id.Equals(community.Id))
					amenity.IsSelected = true;
				else
					amenity.IsSelected = false;
			}
			await Navigation.PushAsync(new SelectedAmenityDetailPage(viewModel.CommunityChildrenAmenityList));
		}
		#endregion

		#region On Adult Outdoor Activities Clicked.
		private void OnAdultOutdoorActivitiesImageClicked(object sender, EventArgs e)
		{
			ImageButton control = (ImageButton)sender;
			OnAdultOutdoorActivitiesClicked(control.BindingContext as Models.ApartmentCommunity);
		}

		private void OnAdultOutdoorActivitiesStackLayoutClicked(object sender, EventArgs e)
		{
			StackLayout control = (StackLayout)sender;
			OnAdultOutdoorActivitiesClicked(control.BindingContext as Models.ApartmentCommunity);
		}

		private void OnAdultOutdoorActivitiesLabelClicked(object sender, EventArgs e)
		{
			Label control = (Label)sender;
			OnAdultOutdoorActivitiesClicked(control.BindingContext as Models.ApartmentCommunity);
		}
		async void OnAdultOutdoorActivitiesClicked(Models.ApartmentCommunity community)
		{
			foreach (var amenity in viewModel.CommunityAmenityList)
			{
				if (amenity.Id.Equals(community.Id))
					amenity.IsSelected = true;
				else
					amenity.IsSelected = false;
			}
			await Navigation.PushAsync(new SelectedAmenityDetailPage(viewModel.CommunityAmenityList));
		}
        #endregion

        private void OnHowToContactListButtonClicked(object sender, EventArgs e)
        {
			Button control = sender as Button;
			HowToContact model = control.BindingContext as HowToContact;
			if (model.Id == 1)
				viewModel.GoToTenantsPageCommand.Execute(null);
		}

        private void OnHowToContactListLabelClicked(object sender, EventArgs e)
        {
			Label control = sender as Label;
			HowToContact model = control.BindingContext as HowToContact;
			if (model.Id == 1)
				viewModel.GoToTenantsPageCommand.Execute(null);
		}

		#region On Eat & Drink Image Clicked.
		private void OnEatAndDrinkImageClicked(object sender, EventArgs e)
        {
			ImageButton control = (ImageButton)sender;
			OnEatAndDrinkClicked(control.BindingContext as Models.ApartmentCommunity);
		}

        private void OnEatAndDrinkStackLayoutClicked(object sender, EventArgs e)
        {
			StackLayout control = (StackLayout)sender;
			OnEatAndDrinkClicked(control.BindingContext as Models.ApartmentCommunity);
		}

        private void OnEatAndDrinkLabelClicked(object sender, EventArgs e)
        {
			Label control = (Label)sender;
			OnEatAndDrinkClicked(control.BindingContext as Models.ApartmentCommunity);
		}

		async void OnEatAndDrinkClicked(Models.ApartmentCommunity community)
		{
			foreach (var amenity in viewModel.EatAndDrinkList)
			{
				if (amenity.Id.Equals(community.Id))
					amenity.IsSelected = true;
				else
					amenity.IsSelected = false;
			}
			await Navigation.PushAsync(new SelectedAmenityDetailPage(viewModel.EatAndDrinkList));
		}
		#endregion

		#region On Parkering Image Clicked
		private void OnImageButtonParkeringListClicked(object sender, EventArgs e)
        {
			ImageButton control = (ImageButton)sender;
			OnParkeringClicked(control.BindingContext as Models.ApartmentCommunityParkingsResponse);
		}

        private void OnStackLayoutParkeringListClicked(object sender, EventArgs e)
        {
			StackLayout control = (StackLayout)sender;
			OnParkeringClicked(control.BindingContext as Models.ApartmentCommunityParkingsResponse);
		}

        private void OnLabelParkeringListClicked(object sender, EventArgs e)
        {
			Label control = (Label)sender;
			OnParkeringClicked(control.BindingContext as Models.ApartmentCommunityParkingsResponse);
		}

		async void OnParkeringClicked(Models.ApartmentCommunityParkingsResponse parking)
		{
			foreach (var amenity in viewModel.ParkeringList)
			{
				if (amenity.Id.Equals(parking.Id))
					amenity.IsSelected = true;
				else
					amenity.IsSelected = false;
			}
			await Navigation.PushAsync(new SelectedParkingDetailPage(viewModel.ParkeringList));
		}
		#endregion

		#region On Fitness Center Image Clicked
		private void OnFitnessCenterImageButtonClicked(object sender, EventArgs e)
        {
			ImageButton control = (ImageButton)sender;
			OnFitnessCenterClicked(control.BindingContext as Models.ApartmentCommunity, control.ClassId);
		}

        private void OnFitnessCenterStackLayoutClicked(object sender, EventArgs e)
        {
			StackLayout control = (StackLayout)sender;
			OnFitnessCenterClicked(control.BindingContext as Models.ApartmentCommunity, control.ClassId);
		}

        private void OnFitnessCenterLabelClicked(object sender, EventArgs e)
        {
			Label control = (Label)sender;
			OnFitnessCenterClicked(control.BindingContext as Models.ApartmentCommunity, control.ClassId);
		}

		async void OnFitnessCenterClicked(Models.ApartmentCommunity community, string selectedApartment)
		{
            switch (selectedApartment)
            {
				case "BookAmenities":
					foreach (var amenity in viewModel.ApartmentCommunityBookList)
					{
						if (amenity.Id.Equals(community.Id))
							amenity.IsSelected = true;
						else
							amenity.IsSelected = false;
					}
					await Navigation.PushAsync(new BuildingSelectedAmenitiesInfoPage(viewModel.ApartmentCommunityBookList));
					break;
				case "FitnessCenter":
					foreach (var amenity in viewModel.BuildingAmenityList)
					{
						if (amenity.Id.Equals(community.Id))
							amenity.IsSelected = true;
						else
							amenity.IsSelected = false;
					}
					await Navigation.PushAsync(new BuildingSelectedAmenitiesInfoPage(viewModel.BuildingAmenityList));
					break;
			}
		}
		#endregion
	}
}