using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dstricts.ViewModels;

namespace Dstricts.Views.Apartment
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyPageInfo : ContentPage
	{
		MyPageInfoViewModel viewModel;
		public MyPageInfo(Models.ApartmentDetailInfoResponse apartmentDetailInfo)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new MyPageInfoViewModel(this.Navigation);
			viewModel.ApartmentDetailInfo = apartmentDetailInfo;
		}
	}
}