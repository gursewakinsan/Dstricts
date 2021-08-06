using AndroidHUD;
using Xamarin.Forms;
using Dstricts.Interfaces;

[assembly: Dependency(typeof(Dstricts.Droid.Services.ProgressBar))]
namespace Dstricts.Droid.Services
{
	public class ProgressBar : IProgressBar
	{
		public void Show()
		{
			AndHUD.Shared.Show(Forms.Context, "Loading...", -1, MaskType.Black);
		}

		public void Hide()
		{
			AndHUD.Shared.Dismiss();
		}
	}
}