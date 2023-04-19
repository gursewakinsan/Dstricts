using System;
using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
    public class NoCheckInPageViewModel : BaseViewModel
    {
        #region Constructor.
        public NoCheckInPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
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
                            GoToVerifyCheckedInCodePageCommand.Execute(null);
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

        #region Properties.
        public int HotelPropertyType { get; set; }
        public string VerifyCheckinId { get; set; } = string.Empty;
        #endregion
    }
}
