using Xamarin.Forms;
using Dstricts.Interfaces;

[assembly: Dependency(typeof(Dstricts.iOS.Services.ProgressBar))]
namespace Dstricts.iOS.Services
{
	public class ProgressBar : IProgressBar
	{
		public void Show()
		{
			BigTed.BTProgressHUD.Show("Loading...", -1, BigTed.ProgressHUD.MaskType.Black);
		}

		public void Hide()
		{
			BigTed.BTProgressHUD.Dismiss();
		}
	}
}