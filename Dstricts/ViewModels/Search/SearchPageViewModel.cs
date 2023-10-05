using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace Dstricts.ViewModels
{
    public class SearchPageViewModel : BaseViewModel
    {
        #region Constructor.
        public SearchPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region People & Business Command.
        private ICommand peopleAndBusinessCommand;
        public ICommand PeopleAndBusinessCommand
        {
            get => peopleAndBusinessCommand ?? (peopleAndBusinessCommand = new Command(async () => await ExecutePeopleAndBusinessCommand()));
        }
        private async Task ExecutePeopleAndBusinessCommand()
        {
            await Task.CompletedTask;
        }
        #endregion

        #region Hotel & Apartments Command.
        private ICommand hotelAndApartmentsCommand;
        public ICommand HotelAndApartmentsCommand
        {
            get => hotelAndApartmentsCommand ?? (hotelAndApartmentsCommand = new Command(async () => await ExecuteHotelAndApartmentsCommand()));
        }
        private async Task ExecuteHotelAndApartmentsCommand()
        {
            await Task.CompletedTask;
        }
        #endregion

        #region Cars & Boats Command.
        private ICommand carsAndBoatsCommand;
        public ICommand CarsAndBoatsCommand
        {
            get => carsAndBoatsCommand ?? (carsAndBoatsCommand = new Command(async () => await ExecuteCarsAndBoatsCommand()));
        }
        private async Task ExecuteCarsAndBoatsCommand()
        {
            await Task.CompletedTask;
        }
        #endregion

        #region Eat & Drinks Command.
        private ICommand eatAndDrinksCommand;
        public ICommand EatAndDrinksCommand
        {
            get => eatAndDrinksCommand ?? (eatAndDrinksCommand = new Command(async () => await ExecuteEatAndDrinksCommand()));
        }
        private async Task ExecuteEatAndDrinksCommand()
        {
            await Task.CompletedTask;
        }
        #endregion

        #region Beauty Treatments Command.
        private ICommand beautyTreatmentsCommand;
        public ICommand BeautyTreatmentsCommand
        {
            get => beautyTreatmentsCommand ?? (beautyTreatmentsCommand = new Command(async () => await ExecuteBeautyTreatmentsCommand()));
        }
        private async Task ExecuteBeautyTreatmentsCommand()
        {
            await Task.CompletedTask;
        }
        #endregion

        #region Handyman For Home Command.
        private ICommand handymanForHomeCommand;
        public ICommand HandymanForHomeCommand
        {
            get => handymanForHomeCommand ?? (handymanForHomeCommand = new Command(async () => await ExecuteHandymanForHomeCommand()));
        }
        private async Task ExecuteHandymanForHomeCommand()
        {
            await Task.CompletedTask;
        }
        #endregion

        #region Community Services Command.
        private ICommand communityServicesCommand;
        public ICommand CommunityServicesCommand
        {
            get => communityServicesCommand ?? (communityServicesCommand = new Command(async () => await ExecuteCommunityServicesCommand()));
        }
        private async Task ExecuteCommunityServicesCommand()
        {
            await Task.CompletedTask;
        }
        #endregion

        #region Real Estate Agency Command.
        private ICommand realEstateAgencyCommand;
        public ICommand RealEstateAgencyCommand
        {
            get => realEstateAgencyCommand ?? (realEstateAgencyCommand = new Command(async () => await ExecuteRealEstateAgencyCommand()));
        }
        private async Task ExecuteRealEstateAgencyCommand()
        {
            await Task.CompletedTask;
        }
        #endregion

        #region Baby Sitter Command.
        private ICommand babySitterCommand;
        public ICommand BabySitterCommand
        {
            get => babySitterCommand ?? (babySitterCommand = new Command(async () => await ExecuteBabySitterCommand()));
        }
        private async Task ExecuteBabySitterCommand()
        {
            await Task.CompletedTask;
        }
        #endregion

        #region Verify QR Code Command.
        private ICommand verifyQrCodeCommand;
        public ICommand VerifyQrCodeCommand
        {
            get => verifyQrCodeCommand ?? (verifyQrCodeCommand = new Command<string>(async (qrCode) => await ExecuteVerifyQrCodeCommand(qrCode)));
        }
        private async Task ExecuteVerifyQrCodeCommand(string qrCode)
        {
            VerifyCheckinId = string.Empty;
            string[] codeInfo = qrCode.Split('/');
            switch (codeInfo[0])
            {
                case "verify_checkin":
                    HotelPropertyType = Convert.ToInt32(codeInfo[1]);
                    Helper.Helper.HotelPropertyType = HotelPropertyType;
                    if (codeInfo.Length == 3)
                    {
                        if (codeInfo[1] == "1")
                        {
                            VerifyCheckinId = codeInfo[2];
                            GoToVerifyCheckedInCodePageCommand.Execute(null);
                        }
                        else
                        {
                            VerifyCheckinId = codeInfo[2];
                            //VerifyBookingCheckinCommand.Execute(codeInfo[2]);
                            Helper.Helper.VerifyCheckinId = VerifyCheckinId;
                            await Navigation.PushAsync(new Views.Apartment.ApartmentDetailInfoCheckinPage());
                        }
                    }
                    break;
                case "getQueue":
                    Helper.Helper.AvalibleQueueId = codeInfo[1];
                    await Navigation.PushAsync(new Views.Queue.AvalibleQueueOnTheLocationPage());
                    break;
                case "verify_adult_checkin":
                    VerifyUserInvitationInfoCommand.Execute(codeInfo[2]);
                    break;
                case "verify_visitor":
                    InvitedVisitorsMeetingListCommand.Execute(codeInfo[2]);
                    break;
            }
            await Task.CompletedTask;
        }
        #endregion

        #region Invited Visitors Meeting List Command.
        private ICommand invitedVisitorsMeetingListCommand;
        public ICommand InvitedVisitorsMeetingListCommand
        {
            get => invitedVisitorsMeetingListCommand ?? (invitedVisitorsMeetingListCommand = new Command<string>(async (locationId) => await ExecuteInvitedVisitorsMeetingListCommand(locationId)));
        }
        private async Task ExecuteInvitedVisitorsMeetingListCommand(string locationId)
        {
            DependencyService.Get<IProgressBar>().Show();
            IVisitorsService service = new VisitorsService();
            var response = await service.InvitedVisitorsMeetingListAsync(new Models.InvitedVisitorsMeetingListRequest()
            {
                LocationId = locationId,
                UserId = Helper.Helper.LoggedInUserId,
            });
            if (response?.Count > 0)
            {
                foreach (var visitors in response)
                {
                    visitors.IsSelectedVisitors = false;
                    visitors.VisitorsCardBorderColor = Color.FromHex("#363541");
                    visitors.VisitorsNameTextOpacity = 0.4;
                }
                await Navigation.PushAsync(new Views.Visitors.InvitedVisitorsMeetingListPage(response));
            }
            else
                await Navigation.PushAsync(new Views.ErrorMessage.InvitedVisitorsMeetingListNotAvailablePage());
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Verify User Invitation Info Command.
        private ICommand verifyUserInvitationInfoCommand;
        public ICommand VerifyUserInvitationInfoCommand
        {
            get => verifyUserInvitationInfoCommand ?? (verifyUserInvitationInfoCommand = new Command<string>(async (id) => await ExecuteVerifyUserInvitationInfoCommand(id)));
        }
        private async Task ExecuteVerifyUserInvitationInfoCommand(string id)
        {
            DependencyService.Get<IProgressBar>().Show();
            IHotelService hotelService = new HotelService();
            int code = await hotelService.VerifyUserInvitationInfoAsync(new Models.VerifyUserInvitationInfoRequest()
            {
                Id = id,
                UserId = Helper.Helper.LoggedInUserId
            });
            if (code == 0) //Not authorized page
                Application.Current.MainPage = new NavigationPage(new Views.ErrorMessage.NotAuthorizedForHotelCheckInPage());
            else if (code == 1) // Already checked-in page
                Application.Current.MainPage = new NavigationPage(new Views.ErrorMessage.AlreadyCheckedInForHotelPage());
            else if (code == 2) // Wrong date page
                Application.Current.MainPage = new NavigationPage(new Views.ErrorMessage.WrongDateForHotelCheckInPage());
            else if (code == 4)
            {
                //Missing some info go to qloudid app.
                if (Device.RuntimePlatform == Device.iOS)
                    await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/ShowMissingPreCheckInInfoPage/{id}");
                else
                    await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/ShowMissingPreCheckInInfoPage/{id}");
            }
            else
            {
                Helper.Helper.VerifyUserInvitationInfoId = id;
                await Navigation.PushAsync(new Views.Hotel.VerifyUserInvitationInfoCodePage(code));
            }
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Go To Verify Checked In Code Page Command.
        private ICommand goToVerifyCheckedInCodePageCommand;
        public ICommand GoToVerifyCheckedInCodePageCommand
        {
            get => goToVerifyCheckedInCodePageCommand ?? (goToVerifyCheckedInCodePageCommand = new Command(async () => await ExecuteGoToVerifyCheckedInCodePageCommand()));
        }
        private async Task ExecuteGoToVerifyCheckedInCodePageCommand()
        {
            await Navigation.PushAsync(new Views.Hotel.VerifyCheckedInPage(HotelPropertyType, VerifyCheckinId));
        }
        #endregion

        #region Go To Test Design Pages Command.
        private ICommand goToTestDesignPagesCommand;
        public ICommand GoToTestDesignPagesCommand
        {
            get => goToTestDesignPagesCommand ?? (goToTestDesignPagesCommand = new Command(async () => await ExecuteGoToTestDesignPagesCommand()));
        }
        private async Task ExecuteGoToTestDesignPagesCommand()
        {
            await Navigation.PushAsync(new Views.TestPage478());
        }
        #endregion

        #region Go To Check In Command.
        private ICommand goToCheckInCommand;
        public ICommand GoToCheckInCommand
        {
            get => goToCheckInCommand ?? (goToCheckInCommand = new Command(async () => await ExecuteGoToCheckInCommand()));
        }
        private async Task ExecuteGoToCheckInCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            IHotelService service = new HotelService();
            List<Models.CheckedInResponse> checkIns = new List<Models.CheckedInResponse>();
            var responseCheckedIn = await service.CheckedInHotelAsync(new Models.CheckedInRequest()
            {
                UserId = Helper.Helper.LoggedInUserId
            });

            var responseCheckedInApartment = await service.CheckedInApartmentAsync(new Models.CheckedInRequest()
            {
                UserId = Helper.Helper.LoggedInUserId
            });

            var responseCheckedInOwnerApartment = await service.CheckedInOwnerApartmentAsync(new Models.CheckedInRequest()
            {
                UserId = Helper.Helper.LoggedInUserId
            });


            if (responseCheckedIn?.Count > 0)
            {
                foreach (var item in responseCheckedIn)
                    if (item != null)
                        checkIns.Add(item);
            }

            if (responseCheckedInApartment?.Count > 0)
            {
                foreach (var item in responseCheckedInApartment)
                    if (item != null)
                        checkIns.Add(item);
            }

            if (responseCheckedInOwnerApartment?.Count > 0)
            {
                foreach (var item in responseCheckedInOwnerApartment)
                    if (item != null)
                        checkIns.Add(item);
            }
            if (checkIns?.Count > 0)
                await Navigation.PushAsync(new Views.Hotel.CheckInPage());
            else
                await Navigation.PushAsync(new Views.Hotel.NoCheckInPage());
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Go To All Wait Command.
        private ICommand goToAllWaitCommand;
        public ICommand GoToAllWaitCommand
        {
            get => goToAllWaitCommand ?? (goToAllWaitCommand = new Command(async () => await ExecuteGoToAllWaitCommand()));
        }
        private async Task ExecuteGoToAllWaitCommand()
        {
            if (UserQueueList?.Count > 0)
            {
                int deviceWidth = App.ScreenWidth - 56;
                int imgWidth = deviceWidth * 80 / 100;

                foreach (var waitList in UserQueueList)
                {
                    waitList.ImgWidth = imgWidth;
                    waitList.ImagePath = "WaitListImage.png";
                }

                /*int index = 0;
                foreach (var waitList in UserQueueList)
                {
                    waitList.FirstLetterBg = Helper.Helper.ListIconBgColorList[index];
                    waitList.FirstLetterText = Helper.Helper.ListIconTextColorList[index];
                    index = index + 1;
                }*/
                await Navigation.PushAsync(new Views.WaitList.AllWaitListPage(UserQueueList));
            }
            else
                await Navigation.PushAsync(new Views.WaitList.EmptyWaitListPage());
        }
        #endregion

        #region Sos Help Command.
        private ICommand sosHelpCommand;
        public ICommand SosHelpCommand
        {
            get => sosHelpCommand ?? (sosHelpCommand = new Command(async () => await ExecuteSosHelpCommand()));
        }
        private async Task ExecuteSosHelpCommand()
        {
            await Navigation.PushAsync(new Views.SosHelp.SosHelpPage());
        }
        #endregion

        #region Social Command.
        private ICommand socialCommand;
        public ICommand SocialCommand
        {
            get => socialCommand ?? (socialCommand = new Command(() => ExecuteSocialCommand()));
        }
        private void ExecuteSocialCommand()
        {
            Application.Current.MainPage = new NavigationPage(new Views.Hotel.CheckedInListPage());
        }
        #endregion

        #region Go To Happenings Page Command.
        private ICommand goToHappeningsPageCommand;
        public ICommand GoToHappeningsPageCommand
        {
            get => goToHappeningsPageCommand ?? (goToHappeningsPageCommand = new Command(async () => await ExecuteGoToHappeningsPageCommand()));
        }
        private async Task ExecuteGoToHappeningsPageCommand()
        {
            await Navigation.PushAsync(new Views.Happening.HappeningsPage());
        }
        #endregion

        #region Search Hotel By User Command.
        private ICommand searchHotelByUserCommand;
        public ICommand SearchHotelByUserCommand
        {
            get => searchHotelByUserCommand ?? (searchHotelByUserCommand = new Command(async () => await ExecuteSearchHotelByUserCommand()));
        }
        private async Task ExecuteSearchHotelByUserCommand()
        {
            Helper.Helper.SelectSearchType = 1;
            await Navigation.PushAsync(new Views.SearchHotel.SearchWithHintsPage());
        }
        #endregion

        #region Search Hotel By Company Command.
        private ICommand searchHotelByCompanyCommand;
        public ICommand SearchHotelByCompanyCommand
        {
            get => searchHotelByCompanyCommand ?? (searchHotelByCompanyCommand = new Command(async () => await ExecuteSearchHotelByCompanyCommand()));
        }
        private async Task ExecuteSearchHotelByCompanyCommand()
        {
            Helper.Helper.SelectSearchType = 2;
            await Navigation.PushAsync(new Views.SearchHotel.SearchWithHintsPage());
        }
        #endregion

        #region Search Hotel By Eat & Drink Command.
        private ICommand searchHotelByEatAndDrinkCommand;
        public ICommand SearchHotelByEatAndDrinkCommand
        {
            get => searchHotelByEatAndDrinkCommand ?? (searchHotelByEatAndDrinkCommand = new Command(async () => await ExecuteSearchHotelByEatAndDrinkCommand()));
        }
        private async Task ExecuteSearchHotelByEatAndDrinkCommand()
        {
            Helper.Helper.SelectSearchType = 3;
            await Navigation.PushAsync(new Views.SearchHotel.SearchWithHintsPage());
        }
        #endregion

        #region Search Hotel By Wellness Command.
        private ICommand searchHotelByWellnessCommand;
        public ICommand SearchHotelByWellnessCommand
        {
            get => searchHotelByWellnessCommand ?? (searchHotelByWellnessCommand = new Command(async () => await ExecuteSearchHotelByWellnessCommand()));
        }
        private async Task ExecuteSearchHotelByWellnessCommand()
        {
            Helper.Helper.SelectSearchType = 4;
            await Navigation.PushAsync(new Views.SearchHotel.SearchWithHintsPage());
        }
        #endregion

        #region Properties.
        public List<Models.UserQueueListResponse> UserQueueList { get; set; }
        public int HotelPropertyType { get; set; }
        public string VerifyCheckinId { get; set; } = string.Empty;
        #endregion
    }
}
