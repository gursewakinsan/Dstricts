using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Dstricts.ViewModels
{
    public class KinsUploadPhotosPageViewModel : BaseViewModel
    {
        #region Constructor.
        public KinsUploadPhotosPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Submit Command.
        private ICommand submitCommand;
        public ICommand SubmitCommand
        {
            get => submitCommand ?? (submitCommand = new Command(async () => await ExecuteSubmitCommand()));
        }
        private async Task ExecuteSubmitCommand()
        {
            if (ImageDataInfo==null || ImageDataInfo.Count ==0)
                await Helper.Alert.DisplayAlert("Image is required.");
            else
            {
                DependencyService.Get<IProgressBar>().Show();
                IKinsService service = new KinsService();
                int response = await service.AddMissingPersonInfoAsync(MissingPersonInfo);
                if (response > 0)
                {
                    foreach (var item in ImageDataInfo)
                    {
                        int imgResponse = await service.AddMissingPersonImagesAsync(new Models.AddMissingPersonImageRequest()
                        {
                            Id = response,
                            ImageId = item.ImageId,
                            ImageData = Convert.ToBase64String(item.ImageBytes)
                        });
                    }
                }
                DependencyService.Get<IProgressBar>().Hide();
                Application.Current.MainPage = new NavigationPage(new Views.Hotel.CheckedInListPage());
            }
        }
        #endregion

        #region Skip Command.
        private ICommand skipCommand;
        public ICommand SkipCommand
        {
            get => skipCommand ?? (skipCommand = new Command(async () => await ExecuteSkipCommand()));
        }
        private async Task ExecuteSkipCommand()
        {
            if (ImageDataInfo?.Count < 0)
                await Helper.Alert.DisplayAlert("Image is required.");
            else
            {
                DependencyService.Get<IProgressBar>().Show();
                IKinsService service = new KinsService();
                int response = await service.AddMissingPersonInfoAsync(MissingPersonInfo);
                DependencyService.Get<IProgressBar>().Hide();
                Application.Current.MainPage = new NavigationPage(new Views.Hotel.CheckedInListPage());
            }
        }
        #endregion

        #region Properties.
        public Models.AddMissingPersonInfoRequest MissingPersonInfo => Helper.Helper.MissingPersonInfo;
        public List<ImageData> ImageDataInfo { get; set; }
        #endregion
    }
}
