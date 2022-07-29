using System;
using System.IO;
using Xamarin.Forms;
using Dstricts.Service;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
    public class TicketSubTitleInfoPageViewModel : BaseViewModel
    {
		#region Constructor.
		public TicketSubTitleInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Ticket Sub Title Info Command.
		private ICommand getTicketSubTitleInfoCommand;
		public ICommand GetTicketSubTitleInfoCommand
		{
			get => getTicketSubTitleInfoCommand ?? (getTicketSubTitleInfoCommand = new Command(async () => await ExecuteGetTicketSubTitleInfoCommand()));
		}
		private async Task ExecuteGetTicketSubTitleInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICommunityService service = new CommunityService();
			TicketSubTitleInfoList = await service.GetTicketSubTitleInfoAsync(new Models.TicketSubTitleInfoRequest()
			{
				TicketId = Helper.Helper.TicketTitleInfo.Id
			});
			if (TicketSubTitleInfoList?.Count > 0)
				SelectedTicketSubTitleInfo = TicketSubTitleInfoList[0];
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		private byte[] ReadStream(Stream input)
		{
			byte[] buffer = new byte[16 * 1024];
			using (MemoryStream ms = new MemoryStream())
			{
				int read;
				while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
				{
					ms.Write(buffer, 0, read);
				}
				return ms.ToArray();
			}
		}

		#region Create Ticket Command.
		private ICommand createTicketCommand;
		public ICommand CreateTicketCommand
		{
			get => createTicketCommand ?? (createTicketCommand = new Command(async () => await ExecuteCreateTicketCommand()));
		}
		private async Task ExecuteCreateTicketCommand()
		{
			if (string.IsNullOrWhiteSpace(ProblemDescription))
				await Helper.Alert.DisplayAlert("Description is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				ICommunityService service = new CommunityService();
				int response = await service.CreateCommunityTicketAsync(new Models.CreateCommunityTicketRequest()
				{
					ProblemDescription = ProblemDescription,
					CheckId = Helper.Helper.HotelCheckedIn,
					TicketType = Helper.Helper.TicketType,
					TicketId = Helper.Helper.TicketTitleInfo.Id,
					SubTicketId = SelectedTicketSubTitleInfo.Id,
					CommunityId = Helper.Helper.CommunityId
				});

				if (ImageDataInfo?.Count > 0)
				{
					foreach (var item in ImageDataInfo)
					{
						if (item.ImageId <= 9)
						{
							var imgResponse = await service.AddCommunityTicketImageAsync(new Models.AddCommunityTicketImageRequest()
							{
								ProblemId = response,
								ImageData = Convert.ToBase64String(item.ImageBytes)
							});
						}
					}
				}
				DependencyService.Get<IProgressBar>().Hide();
				Application.Current.MainPage = new NavigationPage(new Views.Apartment.SupportPage());
			}
		}
		#endregion

		#region Properties.
		private List<Models.TicketSubTitleInfoResponse> ticketSubTitleInfoList;
		public List<Models.TicketSubTitleInfoResponse> TicketSubTitleInfoList
		{
			get => ticketSubTitleInfoList;
			set
			{
				ticketSubTitleInfoList = value;
				OnPropertyChanged("TicketSubTitleInfoList");
			}
		}

		private Models.TicketSubTitleInfoResponse selectedTicketSubTitleInfo;
		public Models.TicketSubTitleInfoResponse SelectedTicketSubTitleInfo
		{
			get => selectedTicketSubTitleInfo;
			set
			{
				selectedTicketSubTitleInfo = value;
				OnPropertyChanged("SelectedTicketSubTitleInfo");
			}
		}


		private string problemDescription;
		public string ProblemDescription
		{
			get => problemDescription;
			set
			{
				problemDescription = value;
				OnPropertyChanged("ProblemDescription");
			}
		}

		private bool image_1;
		public bool Image_1
		{
			get => image_1;
			set
			{
				image_1 = value;
				OnPropertyChanged("Image_1");
			}
		}

		private bool image_2;
		public bool Image_2
		{
			get => image_2;
			set
			{
				image_2 = value;
				OnPropertyChanged("Image_2");
			}
		}

		private bool image_3;
		public bool Image_3
		{
			get => image_3;
			set
			{
				image_3 = value;
				OnPropertyChanged("Image_3");
			}
		}

		private bool image_4;
		public bool Image_4
		{
			get => image_4;
			set
			{
				image_4 = value;
				OnPropertyChanged("Image_4");
			}
		}

		private bool image_5;
		public bool Image_5
		{
			get => image_5;
			set
			{
				image_5 = value;
				OnPropertyChanged("Image_5");
			}
		}

		private bool image_6;
		public bool Image_6
		{
			get => image_6;
			set
			{
				image_6 = value;
				OnPropertyChanged("Image_6");
			}
		}

		private bool image_7;
		public bool Image_7
		{
			get => image_7;
			set
			{
				image_7 = value;
				OnPropertyChanged("Image_7");
			}
		}

		private bool image_8;
		public bool Image_8
		{
			get => image_8;
			set
			{
				image_8 = value;
				OnPropertyChanged("Image_8");
			}
		}

		private bool image_9;
		public bool Image_9
		{
			get => image_9;
			set
			{
				image_9 = value;
				OnPropertyChanged("Image_9");
			}
		}
		public string TicketTitle => Helper.Helper.TicketTitleInfo.TicketTitle;
        public List<ImageData> ImageDataInfo { get; set; }
        #endregion
    }
}

public class ImageData
{
    public int ImageId { get; set; }
	public byte[] ImageBytes { get; set; }
}
