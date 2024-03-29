﻿using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.ViewModels
{
	public class InviteAdultsByPhonePageViewModel : BaseViewModel
	{
		#region Constructor.
		public InviteAdultsByPhonePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Country Code List Command.
		private ICommand countryCodeListCommand;
		public ICommand CountryCodeListCommand
		{
			get => countryCodeListCommand ?? (countryCodeListCommand = new Command(async () => await ExecuteCountryCodeListCommand()));
		}
		private async Task ExecuteCountryCodeListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			CountryCodeList = await service.CountryCodeListAsync();
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Save Mobile Number Command.
		private ICommand saveMobileNumberCommand;
		public ICommand SaveMobileNumberCommand
		{
			get => saveMobileNumberCommand ?? (saveMobileNumberCommand = new Command(async () => await ExecuteSaveMobileNumberCommand()));
		}
		private async Task ExecuteSaveMobileNumberCommand()
		{
			if (SelectedCountryCode == null)
				await Helper.Alert.DisplayAlert("Please select country code.");
			else if (string.IsNullOrWhiteSpace(MobileNumber))
				await Helper.Alert.DisplayAlert("Mobile number is required.");
			else if (MobileNumber.StartsWith("0"))
				await Helper.Alert.DisplayAlert("First digit cannot be zero.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IHotelService service = new HotelService();
				int id = await service.PhoneIinviteAdultForCheckinAsync(new Models.PhoneIinviteAdultForCheckinRequest()
				{
					CheckId = Helper.Helper.HotelCheckedIn,
					UserId = Helper.Helper.LoggedInUserId,
					PhoneNumber = MobileNumber,
					CountryId = SelectedCountryCode.Id
				});
				if (id == 0)
					await Helper.Alert.DisplayAlert("You can't invite your self.");
				else
				{
					Models.VerifyDependent verify = new Models.VerifyDependent()
					{
						Id = id,
						VerificationInfo = 2,
						CheckId = Helper.Helper.HotelCheckedIn,
					};
					string verifyDependentChekIn = Newtonsoft.Json.JsonConvert.SerializeObject(verify);
					if (Device.RuntimePlatform == Device.iOS)
						await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/VerifyDependentChekIn/{verifyDependentChekIn}");
					else
						await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/VerifyDependentChekIn/{verifyDependentChekIn}");

					await Navigation.PopToRootAsync();
				}
				DependencyService.Get<IProgressBar>().Hide();
			}
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		public string MobileNumber { get; set; }

		private List<Models.CountryCodeListResponse> countryCodeList;
		public List<Models.CountryCodeListResponse> CountryCodeList
		{
			get => countryCodeList;
			set
			{
				countryCodeList = value;
				OnPropertyChanged("CountryCodeList");
			}
		}

		private Models.CountryCodeListResponse selectedCountryCode;
		public Models.CountryCodeListResponse SelectedCountryCode
		{
			get => selectedCountryCode;
			set
			{
				selectedCountryCode = value;
				OnPropertyChanged("SelectedCountryCode");
			}
		}
		#endregion
	}
}
