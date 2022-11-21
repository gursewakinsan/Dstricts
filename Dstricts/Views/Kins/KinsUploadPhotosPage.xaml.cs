using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using Plugin.Media.Abstractions;
using Plugin.Media;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Linq;
using Xamarin.Essentials;

namespace Dstricts.Views.Kins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KinsUploadPhotosPage : ContentPage
    {
        #region Variables.
        private IMedia _mediaPicker;
        ImageSource _imageSource;
        KinsUploadPhotosPageViewModel viewModel;
        #endregion

        #region Constructor.
        public KinsUploadPhotosPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new KinsUploadPhotosPageViewModel(this.Navigation);
        }
        #endregion

        #region Setup.
        private async void Setup()
        {
            if (_mediaPicker != null) return;
            await CrossMedia.Current.Initialize();
            _mediaPicker = CrossMedia.Current;
        }
        #endregion

        #region On Image Clicked.
        private void OnImage0Clicked(object sender, EventArgs e)
        {
            TakeOrPickPhoto(0);
        }
        private void OnImage1Clicked(object sender, EventArgs e)
        {
            TakeOrPickPhoto(1);
        }
        private void OnImage2Clicked(object sender, EventArgs e)
        {
            TakeOrPickPhoto(2);
        }
        private void OnImage3Clicked(object sender, EventArgs e)
        {
            TakeOrPickPhoto(3);
        }
        private void OnImage4Clicked(object sender, EventArgs e)
        {
            TakeOrPickPhoto(4);
        }
        private void OnImage5Clicked(object sender, EventArgs e)
        {
            TakeOrPickPhoto(5);
        }
        #endregion

        #region Take Or Pick Photo.
        private async void TakeOrPickPhoto(int index)
        {
            string result = await DisplayActionSheet("Select", "Cancel", null, "Take Photo", "Pick Photo");
            switch (result)
            {
                case "Take Photo":
                    await TakePhoto(index);
                    break;
                case "Pick Photo":
                    await PickPhoto(index);
                    break;
            }
        }
        #endregion

        #region Take Photo.
        private async Task TakePhoto(int selectedImage)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return;
            }
            Setup();
            _imageSource = null;
            try
            {
                var mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    PhotoSize = PhotoSize.Medium,
                    CompressionQuality = 90,
                });

                if (mediaFile != null)
                {
                    switch (selectedImage)
                    {
                        case 0:
                            imageButton0.Source = ImageSource.FromStream(mediaFile.GetStream);
                            button0.IsVisible = false;
                            lbl0.IsVisible = boxView0.IsVisible = true;
                            break;
                        case 1:
                            imageButton1.Source = ImageSource.FromStream(mediaFile.GetStream);
                            button1.IsVisible = false;
                            lbl1.IsVisible = boxView1.IsVisible = true;
                            break;
                        case 2:
                            imageButton2.Source = ImageSource.FromStream(mediaFile.GetStream);
                            button2.IsVisible = false;
                            lbl2.IsVisible = boxView2.IsVisible = true;
                            break;
                        case 3:
                            imageButton3.Source = ImageSource.FromStream(mediaFile.GetStream);
                            button3.IsVisible = false;
                            lbl3.IsVisible = boxView3.IsVisible = true;
                            break;
                        case 4:
                            imageButton4.Source = ImageSource.FromStream(mediaFile.GetStream);
                            button4.IsVisible = false;
                            lbl4.IsVisible = boxView4.IsVisible = true;
                            break;
                        case 5:
                            imageButton5.Source = ImageSource.FromStream(mediaFile.GetStream);
                            button5.IsVisible = false;
                            lbl5.IsVisible = boxView5.IsVisible = true;
                            break;
                    }

                    var stream = mediaFile.GetStream();
                    using (var memoryStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memoryStream);
                        byte[] imageAsByte = memoryStream.ToArray();
                        byte[] aa = await DependencyService.Get<Interfaces.IImageResizerService>().ResizeImage(imageAsByte, 600, 500);
                        /*if (viewModel.ImageDataInfo == null)
                            viewModel.ImageDataInfo = new List<ImageData>();
                        var data = viewModel.ImageDataInfo.FirstOrDefault(x => x.ImageId.Equals(selectedImage));
                        if (data != null)
                        {
                            data.ImageBytes = aa;
                        }
                        else
                        {
                            viewModel.ImageDataInfo.Add(new ImageData()
                            {
                                ImageBytes = aa,
                                ImageId = selectedImage,
                            });
                        }*/
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Pick Photo.
        private async Task PickPhoto(int selectedImage)
        {
            Setup();
            _imageSource = null;
            try
            {
                var mediaFile = await this._mediaPicker.PickPhotoAsync(new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Small,
                    CompressionQuality = 80
                    //CustomPhotoSize = 50
                });
                if (mediaFile != null)
                {
                    switch (selectedImage)
                    {
                        case 0:
                            imageButton0.Source = ImageSource.FromStream(mediaFile.GetStream);
                            button0.IsVisible = false;
                            lbl0.IsVisible = boxView0.IsVisible = true;
                            break;
                        case 1:
                            imageButton1.Source = ImageSource.FromStream(mediaFile.GetStream);
                            button1.IsVisible = false;
                            lbl1.IsVisible = boxView1.IsVisible = true;
                            break;
                        case 2:
                            imageButton2.Source = ImageSource.FromStream(mediaFile.GetStream);
                            button2.IsVisible = false;
                            lbl2.IsVisible = boxView2.IsVisible = true;
                            break;
                        case 3:
                            imageButton3.Source = ImageSource.FromStream(mediaFile.GetStream);
                            button3.IsVisible = false;
                            lbl3.IsVisible = boxView3.IsVisible = true;
                            break;
                        case 4:
                            imageButton4.Source = ImageSource.FromStream(mediaFile.GetStream);
                            button4.IsVisible = false;
                            lbl4.IsVisible = boxView4.IsVisible = true;
                            break;
                        case 5:
                            imageButton5.Source = ImageSource.FromStream(mediaFile.GetStream);
                            button5.IsVisible = false;
                            lbl5.IsVisible = boxView5.IsVisible = true;
                            break;
                    }


                    //var memoryStream = new MemoryStream();
                    //await mediaFile.GetStream().CopyToAsync(memoryStream);
                    //byte[] imageAsByte = memoryStream.ToArray();
                    //viewModel.UserImageData = imageAsByte;

                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Clear Image.
        private void OnImage0CloseClicked(object sender, EventArgs e)
        {
            ClearImage(0);
        }
        private void OnImage1CloseClicked(object sender, EventArgs e)
        {
            ClearImage(1);
        }

        private void OnImage2CloseClicked(object sender, EventArgs e)
        {
            ClearImage(2);
        }

        private void OnImage3CloseClicked(object sender, EventArgs e)
        {
            ClearImage(3);
        }

        private void OnImage4CloseClicked(object sender, EventArgs e)
        {
            ClearImage(4);
        }

        private void OnImage5CloseClicked(object sender, EventArgs e)
        {
            ClearImage(5);
        }

        void ClearImage(int index)
        {
            switch (index)
            {
                case 0:
                    imageButton0.Source = null;
                    button0.IsVisible = true;
                    lbl0.IsVisible = boxView0.IsVisible = false;
                    break;
                case 1:
                    imageButton1.Source = null;
                    button1.IsVisible = true;
                    lbl1.IsVisible = boxView1.IsVisible = false;
                    break;
                case 2:
                    imageButton2.Source = null;
                    button2.IsVisible = true;
                    lbl2.IsVisible = boxView2.IsVisible = false;
                    break;
                case 3:
                    imageButton3.Source = null;
                    button3.IsVisible = true;
                    lbl3.IsVisible = boxView3.IsVisible = false;
                    break;
                case 4:
                    imageButton4.Source = null;
                    button4.IsVisible = true;
                    lbl4.IsVisible = boxView4.IsVisible = false;
                    break;
                case 5:
                    imageButton5.Source = null;
                    button5.IsVisible = true;
                    lbl5.IsVisible = boxView5.IsVisible = false;
                    break;
            }
        }
        #endregion
    }
}