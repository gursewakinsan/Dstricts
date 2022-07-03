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
	public class TestPage1ViewModel : BaseViewModel
	{
		#region Constructor.
		public TestPage1ViewModel(INavigation navigation)
		{
			Navigation = navigation;
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
			int deviceWidth = App.ScreenWidth - 56;
			int imgWidth = deviceWidth * 80 / 100;
			List<Models.UserQueueListResponse> list = new List<Models.UserQueueListResponse>();
			list.Add(new Models.UserQueueListResponse()
			{
				ImgWidth = imgWidth,
				ImagePath = "WaitListImage.png",
				PropertyNickName = "Classical Double Sleep",
				WaitingCount =1
			});

			list.Add(new Models.UserQueueListResponse()
			{
				ImgWidth = imgWidth,
				ImagePath = "WaitListImage.png",
				PropertyNickName = "Classical Double Sleep",
				WaitingCount = 1
			});

			list.Add(new Models.UserQueueListResponse()
			{
				ImgWidth = imgWidth,
				ImagePath = "WaitListImage.png",
				PropertyNickName = "Classical Double Sleep",
				WaitingCount = 1
			});
			AllWaitListInfo = list;
		}
		#endregion

		#region Properties.
		private List<Models.UserQueueListResponse> allWaitListInfo;
		public List<Models.UserQueueListResponse> AllWaitListInfo
		{
			get => allWaitListInfo;
			set
			{
				allWaitListInfo = value;
				OnPropertyChanged("AllWaitListInfo");
			}
		}
		#endregion
	}
}
