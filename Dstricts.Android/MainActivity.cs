using Android.OS;
using Android.App;
using Android.Runtime;
using Android.Content;
using Android.Content.PM;

namespace Dstricts.Droid
{
	[Activity(Label = "Dstricts", Icon = "@drawable/appIcon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
	[IntentFilter(new[] { Intent.ActionView },
				  DataScheme = "https",
				  DataHost = "DstrictsApp.com",
				  DataPathPrefix = "/session",
				  AutoVerify = true,
				  Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable })]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			Xamarin.Forms.Forms.SetFlags(new string[]
			{
				"CarouselView_Experimental",
				"IndicatorView_Experimental",
				"Brush_Experimental"
			});
			Rg.Plugins.Popup.Popup.Init(this);
			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			ZXing.Net.Mobile.Forms.Android.Platform.Init();
			App.ScreenHeight = (int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);
			App.ScreenWidth = (int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density);
			LoadApplication(new App());
		}
		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
		{
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
			global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

		public override void OnBackPressed()
		{
			Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed);
		}
	}
}