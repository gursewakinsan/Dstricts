using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Views.Community
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketSubTitleInfoPage : ContentPage
    {
        #region Variables.
        TicketSubTitleInfoPageViewModel viewModel;
        #endregion

        #region Constructor.
        public TicketSubTitleInfoPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new TicketSubTitleInfoPageViewModel(this.Navigation);
        }
        #endregion

        #region On Appearing.
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.GetTicketSubTitleInfoCommand.Execute(null);
        }
        #endregion

        #region Pick Multiple Images.
        private async Task SelectImages(int selectedImage)
        {
            try
            {
                var result = await FilePicker.PickMultipleAsync(new PickOptions()
                {
                    FileTypes = FilePickerFileType.Images
                });
                if (result != null)
                {
                    List<ImageSource> list = new List<ImageSource>();
                    foreach (var item in result)
                    {
                        var stream = await item.OpenReadAsync();
                        list.Add(ImageSource.FromStream(() => stream));
                    }

                    switch (selectedImage)
                    {
                        case 1:
                            switch (list.Count())
                            {
                                case 1:
                                    img1.Source = list[0];
                                    viewModel.Image_1 = true;
                                    break;
                                case 2:
                                    img1.Source = list[0];
                                    img2.Source = list[1];
                                    viewModel.Image_1 = true;
                                    viewModel.Image_2 = true;
                                    break;
                                case 3:
                                    img1.Source = list[0];
                                    img2.Source = list[1];
                                    img3.Source = list[2];
                                    viewModel.Image_1 = true;
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    break;
                                case 4:
                                    img1.Source = list[0];
                                    img2.Source = list[1];
                                    img3.Source = list[2];
                                    img4.Source = list[3];
                                    viewModel.Image_1 = true;
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    break;
                                case 5:
                                    img1.Source = list[0];
                                    img2.Source = list[1];
                                    img3.Source = list[2];
                                    img4.Source = list[3];
                                    img5.Source = list[4];
                                    viewModel.Image_1 = true;
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    break;
                                case 6:
                                    img1.Source = list[0];
                                    img2.Source = list[1];
                                    img3.Source = list[2];
                                    img4.Source = list[3];
                                    img5.Source = list[4];
                                    img6.Source = list[5];
                                    viewModel.Image_1 = true;
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    break;
                                case 7:
                                    img1.Source = list[0];
                                    img2.Source = list[1];
                                    img3.Source = list[2];
                                    img4.Source = list[3];
                                    img5.Source = list[4];
                                    img6.Source = list[5];
                                    img7.Source = list[6];
                                    viewModel.Image_1 = true;
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    break;
                                case 8:
                                    img1.Source = list[0];
                                    img2.Source = list[1];
                                    img3.Source = list[2];
                                    img4.Source = list[3];
                                    img5.Source = list[4];
                                    img6.Source = list[5];
                                    img7.Source = list[6];
                                    img8.Source = list[7];
                                    viewModel.Image_1 = true;
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    break;
                                case 9:
                                    img1.Source = list[0];
                                    img2.Source = list[1];
                                    img3.Source = list[2];
                                    img4.Source = list[3];
                                    img5.Source = list[4];
                                    img6.Source = list[5];
                                    img7.Source = list[6];
                                    img8.Source = list[7];
                                    img9.Source = list[8];
                                    viewModel.Image_1 = true;
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                                default:
                                    img1.Source = list[0];
                                    img2.Source = list[1];
                                    img3.Source = list[2];
                                    img4.Source = list[3];
                                    img5.Source = list[4];
                                    img6.Source = list[5];
                                    img7.Source = list[6];
                                    img8.Source = list[7];
                                    img9.Source = list[8];
                                    viewModel.Image_1 = true;
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                            }
                            break;
                        case 2:
                            switch (list.Count())
                            {
                                case 1:
                                    img2.Source = list[0];
                                    viewModel.Image_2 = true;
                                    break;
                                case 2:
                                    img2.Source = list[0];
                                    img3.Source = list[1];
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    break;
                                case 3:
                                    img2.Source = list[0];
                                    img3.Source = list[1];
                                    img4.Source = list[2];
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    break;
                                case 4:
                                    img2.Source = list[0];
                                    img3.Source = list[1];
                                    img4.Source = list[2];
                                    img5.Source = list[3];
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    break;
                                case 5:
                                    img2.Source = list[0];
                                    img3.Source = list[1];
                                    img4.Source = list[2];
                                    img5.Source = list[3];
                                    img6.Source = list[4];
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    break;
                                case 6:
                                    img2.Source = list[0];
                                    img3.Source = list[1];
                                    img4.Source = list[2];
                                    img5.Source = list[3];
                                    img6.Source = list[4];
                                    img7.Source = list[5];
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    break;
                                case 7:
                                    img2.Source = list[0];
                                    img3.Source = list[1];
                                    img4.Source = list[2];
                                    img5.Source = list[3];
                                    img6.Source = list[4];
                                    img7.Source = list[5];
                                    img8.Source = list[6];
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    break;
                                case 8:
                                    img2.Source = list[0];
                                    img3.Source = list[1];
                                    img4.Source = list[2];
                                    img5.Source = list[3];
                                    img6.Source = list[4];
                                    img7.Source = list[5];
                                    img8.Source = list[6];
                                    img9.Source = list[7];
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                                default:
                                    img2.Source = list[0];
                                    img3.Source = list[1];
                                    img4.Source = list[2];
                                    img5.Source = list[3];
                                    img6.Source = list[4];
                                    img7.Source = list[5];
                                    img8.Source = list[6];
                                    img9.Source = list[7];
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                            }
                            break;
                        case 3:
                            switch (list.Count())
                            {
                                case 1:
                                    img3.Source = list[0];
                                    viewModel.Image_3 = true;
                                    break;
                                case 2:
                                    img3.Source = list[0];
                                    img4.Source = list[1];
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    break;
                                case 3:
                                    img3.Source = list[0];
                                    img4.Source = list[1];
                                    img5.Source = list[2];
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    break;
                                case 4:
                                    img3.Source = list[0];
                                    img4.Source = list[1];
                                    img5.Source = list[2];
                                    img6.Source = list[3];
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    break;
                                case 5:
                                    img3.Source = list[0];
                                    img4.Source = list[1];
                                    img5.Source = list[2];
                                    img6.Source = list[3];
                                    img7.Source = list[4];
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    break;
                                case 6:
                                    img3.Source = list[0];
                                    img4.Source = list[1];
                                    img5.Source = list[2];
                                    img6.Source = list[3];
                                    img7.Source = list[4];
                                    img8.Source = list[5];
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    break;
                                case 7:
                                    img3.Source = list[0];
                                    img4.Source = list[1];
                                    img5.Source = list[2];
                                    img6.Source = list[3];
                                    img7.Source = list[4];
                                    img8.Source = list[5];
                                    img9.Source = list[6];
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                                default:
                                    img3.Source = list[0];
                                    img4.Source = list[1];
                                    img5.Source = list[2];
                                    img6.Source = list[3];
                                    img7.Source = list[4];
                                    img8.Source = list[5];
                                    img9.Source = list[6];
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                            }
                            break;
                        case 4:
                            switch (list.Count())
                            {
                                case 1:
                                    img4.Source = list[0];
                                    viewModel.Image_4 = true;
                                    break;
                                case 2:
                                    img4.Source = list[0];
                                    img5.Source = list[1];
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    break;
                                case 3:
                                    img4.Source = list[0];
                                    img5.Source = list[1];
                                    img6.Source = list[2];
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    break;
                                case 4:
                                    img4.Source = list[0];
                                    img5.Source = list[1];
                                    img6.Source = list[2];
                                    img7.Source = list[3];
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    break;
                                case 5:
                                    img5.Source = list[1];
                                    img6.Source = list[2];
                                    img7.Source = list[3];
                                    img8.Source = list[4];
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    break;
                                case 6:
                                    img4.Source = list[0];
                                    img5.Source = list[1];
                                    img6.Source = list[2];
                                    img7.Source = list[3];
                                    img8.Source = list[4];
                                    img9.Source = list[5];
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                                default:
                                    img4.Source = list[0];
                                    img5.Source = list[1];
                                    img6.Source = list[2];
                                    img7.Source = list[3];
                                    img8.Source = list[4];
                                    img9.Source = list[5];
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                            }
                            break;
                        case 5:
                            switch (list.Count())
                            {
                                case 1:
                                    img5.Source = list[0];
                                    viewModel.Image_5 = true;
                                    break;
                                case 2:
                                    img5.Source = list[0];
                                    img6.Source = list[1];
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    break;
                                case 3:
                                    img5.Source = list[0];
                                    img6.Source = list[1];
                                    img7.Source = list[2];
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    break;
                                case 4:
                                    img5.Source = list[0];
                                    img6.Source = list[1];
                                    img7.Source = list[2];
                                    img8.Source = list[3];
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    break;
                                case 5:
                                    img5.Source = list[0];
                                    img6.Source = list[1];
                                    img7.Source = list[2];
                                    img8.Source = list[3];
                                    img9.Source = list[4];
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                                default:
                                    img5.Source = list[0];
                                    img6.Source = list[1];
                                    img7.Source = list[2];
                                    img8.Source = list[3];
                                    img9.Source = list[4];
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                            }
                            break;
                        case 6:
                            switch (list.Count())
                            {
                                case 1:
                                    img6.Source = list[0];
                                    viewModel.Image_6 = true;
                                    break;
                                case 2:
                                    img6.Source = list[0];
                                    img7.Source = list[1];
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    break;
                                case 3:
                                    img6.Source = list[0];
                                    img7.Source = list[1];
                                    img8.Source = list[2];
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    break;
                                case 4:
                                    img6.Source = list[0];
                                    img7.Source = list[1];
                                    img8.Source = list[2];
                                    img9.Source = list[3];
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                                default:
                                    img6.Source = list[0];
                                    img7.Source = list[1];
                                    img8.Source = list[2];
                                    img9.Source = list[3];
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                            }
                            break;
                        case 7:
                            switch (list.Count())
                            {
                                case 1:
                                    img7.Source = list[0];
                                    viewModel.Image_7 = true;
                                    break;
                                case 2:
                                    img7.Source = list[0];
                                    img8.Source = list[1];
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    break;
                                case 3:
                                    img7.Source = list[0];
                                    img8.Source = list[1];
                                    img9.Source = list[2];
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                                default:
                                    img7.Source = list[0];
                                    img8.Source = list[1];
                                    img9.Source = list[2];
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                            }
                            break;
                        case 8:
                            switch (list.Count())
                            {
                                case 1:
                                    img8.Source = list[0];
                                    viewModel.Image_8 = true;
                                    break;
                                case 2:
                                    img8.Source = list[0];
                                    img9.Source = list[1];
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                                default:
                                    img8.Source = list[0];
                                    img9.Source = list[1];
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                            }
                            break;
                        case 9:
                            switch (list.Count())
                            {
                                case 1:
                                    img9.Source = list[0];
                                    viewModel.Image_9 = true;
                                    break;
                                default:
                                    img9.Source = list[0];
                                    viewModel.Image_9 = true;
                                    break;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }
        }
        #endregion

        #region On Image Clicked.
        private async void OnImg1Clicked(object sender, EventArgs e)
        {
            await SelectImages(1);
        }

        private async void OnImg2Clicked(object sender, EventArgs e)
        {
            await SelectImages(2);
        }

        private async void OnImg3Clicked(object sender, EventArgs e)
        {
            await SelectImages(3);
        }

        private async void OnImg4Clicked(object sender, EventArgs e)
        {
            await SelectImages(4);
        }

        private async void OnImg5Clicked(object sender, EventArgs e)
        {
            await SelectImages(5);
        }

        private async void OnImg6Clicked(object sender, EventArgs e)
        {
            await SelectImages(6);
        }

        private async void OnImg7Clicked(object sender, EventArgs e)
        {
            await SelectImages(7);
        }

        private async void OnImg8Clicked(object sender, EventArgs e)
        {
            await SelectImages(8);
        }

        private async void OnImg9Clicked(object sender, EventArgs e)
        {
            await SelectImages(9);
        }
        #endregion

        #region Selected Image Remove.
        private void OnImg1RemovedTapped(object sender, EventArgs e)
        {
            img1.Source = null;
            viewModel.Image_1 = false;
        }

        private void OnImg2RemovedTapped(object sender, EventArgs e)
        {
            img2.Source = null;
            viewModel.Image_2 = false;
        }

        private void OnImg3RemovedTapped(object sender, EventArgs e)
        {
            img3.Source = null;
            viewModel.Image_3 = false;
        }

        private void OnImg4RemovedTapped(object sender, EventArgs e)
        {
            img4.Source = null;
            viewModel.Image_4 = false;
        }

        private void OnImg5RemovedTapped(object sender, EventArgs e)
        {
            img5.Source = null;
            viewModel.Image_5 = false;
        }

        private void OnImg6RemovedTapped(object sender, EventArgs e)
        {
            img6.Source = null;
            viewModel.Image_6 = false;
        }

        private void OnImg7RemovedTapped(object sender, EventArgs e)
        {
            img7.Source = null;
            viewModel.Image_7 = false;
        }

        private void OnImg8RemovedTapped(object sender, EventArgs e)
        {
            img8.Source = null;
            viewModel.Image_8 = false;
        }

        private void OnImg9RemovedTapped(object sender, EventArgs e)
        {
            img9.Source = null;
            viewModel.Image_9 = false;
        }
        #endregion

    }
}