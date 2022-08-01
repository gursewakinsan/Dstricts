﻿using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class QloudIdApartmentDetailsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public QloudIdApartmentDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Apartment Detail Info Command.
		private ICommand apartmentDetailInfoCommand;
		public ICommand ApartmentDetailInfoCommand
		{
			get => apartmentDetailInfoCommand ?? (apartmentDetailInfoCommand = new Command(async () => await ExecuteApartmentDetailInfoCommand()));
		}
		private async Task ExecuteApartmentDetailInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IApartmentService service = new ApartmentService();
			ApartmentDetailInfo = await service.ApartmentDetailInfoAsync(new Models.ApartmentDetailInfoRequest()
			{
				Id = ApartmentDetails.QloudCheckOutId
			});

			ICommunityService communityService = new CommunityService();
			Helper.Helper.CommunityId = await communityService.GetCommunityInfoAsync(new Models.CommunityInfoRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn
			});

			BindListDecorated();
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Go To Community Page Command.
		private ICommand goToCommunityPageCommand;
		public ICommand GoToCommunityPageCommand
		{
			get => goToCommunityPageCommand ?? (goToCommunityPageCommand = new Command(async () => await ExecuteGoToCommunityPageCommand()));
		}
		private async Task ExecuteGoToCommunityPageCommand()
		{
			if (Helper.Helper.CommunityId > 0)
				await Navigation.PushAsync(new Views.Community.CommunityPage());
		}
		#endregion

		#region Go To My Page Command.
		private ICommand goToMyPageCommand;
		public ICommand GoToMyPageCommand
		{
			get => goToMyPageCommand ?? (goToMyPageCommand = new Command(async () => await ExecuteGoToMyPageCommand()));
		}
		private async Task ExecuteGoToMyPageCommand()
		{
			await Navigation.PushAsync(new Views.Apartment.MyPageInfo(ApartmentDetailInfo));
		}
		#endregion

		#region Go To Support Page Command.
		private ICommand goToSupportPageCommand;
		public ICommand GoToSupportPageCommand
		{
			get => goToSupportPageCommand ?? (goToSupportPageCommand = new Command(async () => await ExecuteGoToSupportPageCommand()));
		}
		private async Task ExecuteGoToSupportPageCommand()
		{
			await Navigation.PushAsync(new Views.Apartment.SupportPage());
		}
		#endregion

		#region Socail Click Command.
		private ICommand socailClickCommand;
		public ICommand SocailClickCommand
		{
			get => socailClickCommand ?? (socailClickCommand = new Command(() => ExecuteSocailClickCommand()));
		}
		private void ExecuteSocailClickCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Hotel.CheckedInListPage());
		}
		#endregion

		void BindListDecorated()
		{
			List<Models.CheckedInResponse> listDecorated = new List<Models.CheckedInResponse>();
			int deviceWidth = App.ScreenWidth - 56;
			int imgWidth = deviceWidth * 80 / 100;
			listDecorated.Add(new Models.CheckedInResponse()
			{
				ImgWidth = imgWidth,
				ImagePath = "imgGuestRoom",
				PropertyNickName = "Bedroom " + ApartmentDetailInfo.Bedrooms,
				BookingOverdate = "No window, 18-22 m2"
			});

			listDecorated.Add(new Models.CheckedInResponse()
			{
				ImgWidth = imgWidth,
				ImagePath = "imgBathroom",
				PropertyNickName = "Bathroom " + ApartmentDetailInfo.Bath,
				BookingOverdate = "No window, 18-22 m2"
			});

			listDecorated.Add(new Models.CheckedInResponse()
			{
				ImgWidth = imgWidth,
				ImagePath = "imgkitchen",
				PropertyNickName = "Kitchen 1",
				BookingOverdate = "No window, 18-22 m2"
			});

			listDecorated.Add(new Models.CheckedInResponse()
			{
				ImgWidth = imgWidth,
				ImagePath = "imgBalcony",
				PropertyNickName = "Hallway 1",
				BookingOverdate = "No window, 18-22 m2"
			});

			listDecorated.Add(new Models.CheckedInResponse()
			{
				ImgWidth = imgWidth,
				ImagePath = "imgGuestRoom",
				PropertyNickName = "Livingroom 1",
				BookingOverdate = "No window, 18-22 m2"
			});

			listDecorated.Add(new Models.CheckedInResponse()
			{
				ImgWidth = imgWidth,
				ImagePath = "imgHotelView",
				PropertyNickName = "Balcony 1",
				BookingOverdate = "No window, 18-22 m2"
			});

			listDecorated.Add(new Models.CheckedInResponse()
			{
				ImgWidth = imgWidth,
				ImagePath = "imgBalcony",
				PropertyNickName = "Terrace 1",
				BookingOverdate = "No window, 18-22 m2"
			});
			ListDecorated = listDecorated;
		}

		#region Properties.
		private Models.CheckedInResponse apartmentDetails;
		public Models.CheckedInResponse ApartmentDetails
		{
			get => apartmentDetails;
			set
			{
				apartmentDetails = value;
				OnPropertyChanged("ApartmentDetails");
			}
		}

		private Models.ApartmentDetailInfoResponse apartmentDetailInfo;
		public Models.ApartmentDetailInfoResponse ApartmentDetailInfo
		{
			get => apartmentDetailInfo;
			set
			{
				apartmentDetailInfo = value;
				OnPropertyChanged("ApartmentDetailInfo");
			}
		}

		private List<Models.CheckedInResponse> listDecorated;
		public List<Models.CheckedInResponse> ListDecorated
		{
			get => listDecorated;
			set
			{
				listDecorated = value;
				OnPropertyChanged("ListDecorated");
			}
		}


		public string UserName => Helper.Helper.LoggedInUserName;
		#endregion
	}
}
