using Android.App;

namespace Dstricts.Droid
{
	[Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
	public class SplashActivity : Activity
	{
		protected override void OnResume()
		{
			base.OnResume();
			StartActivity(typeof(MainActivity));
		}
	}
}