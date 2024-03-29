﻿using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class AdultsAndChildrenInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AdultsAndChildrenInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Dependents Checked In List Command.
		private ICommand dependentsCheckedInListCommand;
		public ICommand DependentsCheckedInListCommand
		{
			get => dependentsCheckedInListCommand ?? (dependentsCheckedInListCommand = new Command(async () => await ExecuteDependentsCheckedInListCommand()));
		}
		private async Task ExecuteDependentsCheckedInListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			var adultsCheckedInList = await service.AdultsCheckedInListAsync(new Models.AdultsCheckedInListRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn
			});
			if (adultsCheckedInList?.Count > 0)
			{
				foreach (var item in adultsCheckedInList)
				{
					if (item.IsConfirmed)
						item.FrameBorderColor = Color.FromHex("#406B4B");
					else
						item.FrameBorderColor = Color.FromHex("#E53614");
				}
			}
			AdultsCheckedInList = adultsCheckedInList;

			var dependentsCheckedIn = await service.DependentsCheckedInListAsync(new Models.DependentsCheckedInListRequest()
			{
				CheckId = Helper.Helper.HotelCheckedIn
			});
			if (dependentsCheckedIn?.Count > 0)
				if (!IsGuestChildren) IsGuestChildren = true;
			DependentsCheckedInList = dependentsCheckedIn;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Resend Invitation Command.
		private ICommand resendInvitationCommand;
		public ICommand ResendInvitationCommand
		{
			get => resendInvitationCommand ?? (resendInvitationCommand = new Command<int>(async (id) => await ExecuteResendInvitationCommand(id)));
		}
		private async Task ExecuteResendInvitationCommand(int id)
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			var adultsCheckedInList = await service.ResendInvitationAsync(new Models.ResendInvitationRequest()
			{
				Id = id
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private int totalCount;
		public int TotalCount
		{
			get => totalCount;
			set
			{
				totalCount = value;
				OnPropertyChanged("TotalCount");
			}
		}

		private bool isGuestChildren;
		public bool IsGuestChildren
		{
			get => isGuestChildren;
			set
			{
				isGuestChildren = value;
				OnPropertyChanged("IsGuestChildren");
			}
		}

		private List<Models.AdultsCheckedInListResponse> adultsCheckedInList;
		public List<Models.AdultsCheckedInListResponse> AdultsCheckedInList
		{
			get => adultsCheckedInList;
			set
			{
				adultsCheckedInList = value;
				OnPropertyChanged("AdultsCheckedInList");
			}
		}

		private List<Models.DependentsCheckedInListResponse> dependentsCheckedInList;
		public List<Models.DependentsCheckedInListResponse> DependentsCheckedInList
		{
			get => dependentsCheckedInList;
			set
			{
				dependentsCheckedInList = value;
				OnPropertyChanged("DependentsCheckedInList");
			}
		}
		
		public string UserName => Helper.Helper.LoggedInUserName;
		#endregion
	}
}
