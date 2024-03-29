﻿using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace Dstricts.ViewModels
{
	public class SosHelpPageViewModel : BaseViewModel
	{
		#region Constructor.
		public SosHelpPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Travel App Available Sos Command.
		private ICommand travelAppAvailableSosCommand;
		public ICommand TravelAppAvailableSosCommand
		{
			get => travelAppAvailableSosCommand ?? (travelAppAvailableSosCommand = new Command(async () => await ExecuteTravelAppAvailableSosCommand()));
		}
		private async Task ExecuteTravelAppAvailableSosCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ISosService service = new SosService();
            var myCurrentLocation = await Geolocation.GetLocationAsync();
            Helper.Helper.MyCurrentLocationLatitude = myCurrentLocation.Latitude;
            Helper.Helper.MyCurrentLocationLongitude = myCurrentLocation.Longitude;
			TravelAppAvailableSosList = await service.TravelAppAvailableSosAsync(new Models.TravelAppAvailableSosRequest()
			{
				UserId = Helper.Helper.LoggedInUserId,
				CurrentLatitude = myCurrentLocation.Latitude,
				CurrentLongitude = myCurrentLocation.Longitude
			});
			ListHeightRequest = 200;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Social Command.
		private ICommand socialCommand;
		public ICommand SocialCommand
		{
			get => socialCommand ?? (socialCommand = new Command(() => ExecuteGoToCheckInCommand()));
		}
		private void ExecuteGoToCheckInCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Hotel.CheckedInListPage());
		}
		#endregion

		#region Go To Lost Or Found Command.
		private ICommand goToLostOrFoundCommand;
		public ICommand GoToLostOrFoundCommand
		{
			get => goToLostOrFoundCommand ?? (goToLostOrFoundCommand = new Command(async () => await ExecuteGoToLostOrFoundCommand()));
		}
		private async Task ExecuteGoToLostOrFoundCommand()
		{
			await Navigation.PushAsync(new Views.Kins.KinsLostOrFoundPage());
		}
        #endregion

        #region User Queue List Command.
        private ICommand userQueueListCommand;
        public ICommand UserQueueListCommand
        {
            get => userQueueListCommand ?? (userQueueListCommand = new Command(async () => await ExecuteUserQueueListCommand()));

        }
        private async Task ExecuteUserQueueListCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            IHotelService service = new HotelService();
            var UserQueueList = await service.UserQueueListAsync(new Models.UserQueueListRequest()
            {
                UserId = Helper.Helper.LoggedInUserId
            });
            if (UserQueueList?.Count > 0)
            {
                int deviceWidth = App.ScreenWidth - 56;
                int imgWidth = deviceWidth * 80 / 100;

                foreach (var waitList in UserQueueList)
                {
                    waitList.ImgWidth = imgWidth;
                    waitList.ImagePath = "WaitListImage.png";
                }
                await Navigation.PushAsync(new Views.WaitList.AllWaitListPage(UserQueueList));
            }
            else
                await Navigation.PushAsync(new Views.WaitList.EmptyWaitListPage());
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Go To Search Page Command.
        private ICommand goToSearchPageCommand;
        public ICommand GoToSearchPageCommand
        {
            get => goToSearchPageCommand ?? (goToSearchPageCommand = new Command(async () => await ExecuteGoToSearchPageCommand()));
        }
        private async Task ExecuteGoToSearchPageCommand()
        {
            await Navigation.PushAsync(new Views.Search.SearchPage());
        }
        #endregion

        #region Properties.
        private List<Models.TravelAppAvailableSosResponse> travelAppAvailableSosList;
		public List<Models.TravelAppAvailableSosResponse> TravelAppAvailableSosList
		{
			get => travelAppAvailableSosList;
			set
			{
				travelAppAvailableSosList = value;
				OnPropertyChanged("TravelAppAvailableSosList");
			}
		}

		private double listHeightRequest;
		public double ListHeightRequest
		{
			get => listHeightRequest;
			set
			{
				listHeightRequest = value;
				OnPropertyChanged("ListHeightRequest");
			}
		}
		#endregion
	}
}
