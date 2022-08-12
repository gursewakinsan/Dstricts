using Xamarin.Forms;
using Dstricts.Service;
using Xamarin.Essentials;
using Dstricts.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Dstricts.ViewModels
{
    public class TenantInvoiceInfoPageViewModel : BaseViewModel
    {
		#region Constructor.
		public TenantInvoiceInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Tenant Invoice Info Command.
		private ICommand tenantInvoiceInfoCommand;
		public ICommand TenantInvoiceInfoCommand
		{
			get => tenantInvoiceInfoCommand ?? (tenantInvoiceInfoCommand = new Command(async () => await ExecuteTenantInvoiceInfoCommand()));
		}
		private async Task ExecuteTenantInvoiceInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IInvoiceService service = new InvoiceService();
			TenantInvoiceInfo = await service.TenantInvoiceInfoAsync(new Models.TenantInvoiceInfoRequest()
			{
				UserId = Helper.Helper.LoggedInUserId,
				BuildingId = BuildingId
			});
			if(TenantInvoiceInfo.Paid?.Count>0)
				IsPaidListEmpty = true;
			else
				IsPaidListEmpty = false;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Tenant Invoice Pay Now Command.
		private ICommand tenantInvoicePayNowCommand;
		public ICommand TenantInvoicePayNowCommand
		{
			get => tenantInvoicePayNowCommand ?? (tenantInvoicePayNowCommand = new Command<Models.PaidUnpaid>(async (paidUnpaid) => await ExecuteTenantInvoicePayNowCommand(paidUnpaid)));
		}
		private async Task ExecuteTenantInvoicePayNowCommand(Models.PaidUnpaid paidUnpaid)
		{
			Models.TenantInvoicePayNow payNowRequest = new Models.TenantInvoicePayNow()
			{
				PropertyNickName = PropertyNickName,
				InvoiceMonth = paidUnpaid.InvoiceMonth,
				TenantInvoiceInfoId = paidUnpaid.Id,
				TotalAmount = paidUnpaid.TotalAmount
			};
			string payNowJson = Newtonsoft.Json.JsonConvert.SerializeObject(payNowRequest);
			if (Device.RuntimePlatform == Device.iOS)
				await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/DstrictsTenantInvoicePayNow/{payNowJson}");
			else
				await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/DstrictsTenantInvoicePayNow/{payNowJson}");
		}
		#endregion

		#region Properties.
		private Models.TenantInvoiceInfoResponse tenantInvoiceInfo;
		public Models.TenantInvoiceInfoResponse TenantInvoiceInfo
		{
			get => tenantInvoiceInfo;
			set
			{
				tenantInvoiceInfo = value;
				OnPropertyChanged("TenantInvoiceInfo");
			}
		}

		private bool isPaidListEmpty;
		public bool IsPaidListEmpty
		{
			get => isPaidListEmpty;
			set
			{
				isPaidListEmpty = value;
				OnPropertyChanged("IsPaidListEmpty");
			}
		}

		private string propertyNickName;
		public string PropertyNickName
		{
			get => propertyNickName;
			set
			{
				propertyNickName = value;
				OnPropertyChanged("PropertyNickName");
			}
		}

        public int EmptyImageWidth => App.ScreenWidth - 56;
		public int DisplayCurrentYear => System.DateTime.Now.Year;
		public int BuildingId { get; set; }
        #endregion
    }
}
